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
        var images = await _db.Images.ToListAsync();
            
        // Створюємо список ViewModel для продуктів
        var viewModels = new List<ProductViewModel>();
        foreach (var product in products)
        {
            // Отримуємо перше зображення для кожного продукту
            var firstImage = images.FirstOrDefault(i => i.Id == product.Id);
            
            // Створюємо ViewModel для продукту
            var viewModel = new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                // Конвертуємо зображення у формат base64
                ImageBase64 = firstImage.ImageData
            };
            // Додаємо ViewModel до списку
            viewModels.Add(viewModel);
        }

        // Передаємо список ViewModel у представлення для відображення
        return viewModels;
    }
}