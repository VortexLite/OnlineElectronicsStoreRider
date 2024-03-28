using Microsoft.EntityFrameworkCore;
using OnlineElectronicsStore.DAL.Interfaces;
using OnlineElectronicsStore.Domain.Entity;
using OnlineElectronicsStore.Domain.ViewModels.Product;

namespace OnlineElectronicsStore.DAL.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _db;

    public ProductRepository(ApplicationDbContext db)
    {
        _db = db;
    }
    
    public async Task<bool> Create(Product entity)
    {
        await _db.Products.AddAsync(entity);
        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<Product> Get(int id)
    {
        return await _db.Products.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Product>> Select()
    {
        return await _db.Products.ToListAsync();
    }

    public async Task<bool> Delete(Product entity)
    {
        _db.Products.Remove(entity);
        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<Product> Update(Product entity)
    {
        _db.Products.Update(entity);
        await _db.SaveChangesAsync();

        return entity;
    }

    public async Task<Product> GetByName(string name)
    {
        return await _db.Products.FirstOrDefaultAsync(x => x.Name == name);
    }

    public async Task<List<ProductViewModel>> GetProductWithImages()
    {
        var products = await _db.Products.ToListAsync();
        
        var viewModels = new List<ProductViewModel>();
        foreach (var product in products)
        {
            var image = await _db.Images.FirstOrDefaultAsync(i => i.Id == product.Id);
            
            var viewModel = new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                ImageBase64 = image.ImageData
            };
            
            viewModels.Add(viewModel);
        }
        
        return viewModels;
    }

    public async Task<List<ProductViewModel>> GetsByName(string name)
    {
        var products = await _db.Products
            .Where(p => EF.Functions.Like(p.Name, "%" + name + "%"))
            .ToListAsync();
        
        var viewModels = new List<ProductViewModel>();
        foreach (var product in products)
        {
            var image = await _db.Images.FirstOrDefaultAsync(i => i.Id == product.Id);
            
            var viewModel = new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                ImageBase64 = image.ImageData
            };
            
            viewModels.Add(viewModel);
        }
        
        return viewModels;
    }

    public async Task<Product> GetProdutWithImageById(int id)
    {
        var product = await _db.Products.
            Include(i => i.Images).
            FirstOrDefaultAsync(x => x.Id == id);

        return product;
    }

    public async Task<ProductDetailViewModel> GetProductDetail(int id)
    {
        var product = await _db.Products
            .FirstOrDefaultAsync(i => i.Id == id);

        var images = await _db.Images
            .Where(i => i.IdProduct == id)
            .ToListAsync();

        var details = await _db.ProductCharacteristics
            .Where(i => i.IdProduct == id)
            .ToListAsync();
        
        var viewModel = new ProductDetailViewModel()
        {
            Name = product.Name,
            ShortDescription = product.ShortDescription,
            LongDescription = product.LongDescription,
            Price = product.Price,
            Amount = product.Amount,
            ProductCharacteristics = details,
            Images = images
        };
        
        return viewModel;
    }
}