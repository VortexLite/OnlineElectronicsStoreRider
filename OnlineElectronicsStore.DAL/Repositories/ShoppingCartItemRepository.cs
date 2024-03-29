using Microsoft.EntityFrameworkCore;
using OnlineElectronicsStore.DAL.Interfaces;
using OnlineElectronicsStore.Domain.Entity;

namespace OnlineElectronicsStore.DAL.Repositories;

public class ShoppingCartItemRepository : IShoppingCartItemRepository
{
    private readonly ApplicationDbContext _db;
    public ShoppingCartItemRepository(ApplicationDbContext db)
    {
        _db = db;
    }
    
    public async Task<bool> Create(ShoppingCartItem entity)
    {
        await _db.ShoppingCartItems.AddAsync(entity);
        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<ShoppingCartItem> Get(int id)
    {
        return await _db.ShoppingCartItems.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<ShoppingCartItem>> Select()
    {
        return await _db.ShoppingCartItems.ToListAsync();
    }

    public async Task<bool> Delete(ShoppingCartItem entity)
    {
        _db.ShoppingCartItems.Remove(entity);
        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<ShoppingCartItem> Update(ShoppingCartItem entity)
    {
        _db.ShoppingCartItems.Update(entity);
        await _db.SaveChangesAsync();

        return entity;
    }

    public Task<List<ShoppingCartItem>> GetShoppingCartBy(string name)
    {
        throw new NotImplementedException();
    }

    public async Task<List<ShoppingCartItem>> GetShoppingCartBy(int idProfile)
    {
        var shoppingCartItems = await _db.ShoppingCartItems
            .Where(i => i.IdProfile == idProfile)
            .Include(i => i.Product)
            .ThenInclude(i => i.Images)
            .ToListAsync();

        return shoppingCartItems;
    }

    public async Task<bool> AddProductInCart(int idProduct, int idProfile)
    {
        var shoppingcart = await _db.ShoppingCartItems
            .Include(i => i.Product)
            .FirstOrDefaultAsync(i => i.IdProduct == idProduct && i.IdProfile == idProfile);
        if (shoppingcart != null)
        {
            shoppingcart.Quantity++;
            await _db.SaveChangesAsync();
            return true;
        }
        else
        {
            var product = await _db.Products
                .FirstOrDefaultAsync(i => i.Id == idProduct);
            var item = new ShoppingCartItem()
            {
                IdProfile = idProfile,
                IdProduct = idProduct,
                Quantity = 1,
                Price = product.Price
            };

            await Create(item);
            return true;
        }
    }
}