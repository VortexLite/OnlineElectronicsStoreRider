using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OnlineElectronicsStore.DAL.Interfaces;
using OnlineElectronicsStore.Domain.Entity;
using OnlineElectronicsStore.Domain.ViewModels.Menu;
using OnlineElectronicsStore.Domain.ViewModels.Product;

namespace OnlineElectronicsStore.DAL.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _db;

    public ProductRepository(ApplicationDbContext db)
    {
        _db = db;
    }
    
    public async Task<bool> CreateAsync(Product entity)
    {
        await _db.Products.AddAsync(entity);
        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<Product> GetAsync(int id)
    {
        return await _db.Products.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Product>> SelectAsync()
    {
        return await _db.Products.ToListAsync();
    }

    public async Task<bool> DeleteAsync(Product entity)
    {
        _db.Products.Remove(entity);
        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<Product> UpdateAsync(Product entity)
    {
        _db.Products.Update(entity);
        await _db.SaveChangesAsync();

        return entity;
    }

    public async Task<Product> GetByNameAsync(string name)
    {
        return await _db.Products.FirstOrDefaultAsync(x => x.Name == name);
    }

    public async Task<List<ProductViewModel>> GetProductWithImagesAsync()
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

    public async Task<List<ProductViewModel>> GetsByNameAsync(string name)
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

    public async Task<Product> GetProdutWithImageByIdAsync(int id)
    {
        var product = await _db.Products.
            Include(i => i.Images).
            FirstOrDefaultAsync(x => x.Id == id);

        return product;
    }

    public async Task<ProductDetailViewModel> GetProductDetailAsync(int id)
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

    public async Task<bool> CreateProductWithImageAsync(CreateProductViewModel viewModel)
    {
        var product = new Product
        {
            Name = viewModel.Name,
            ShortDescription = viewModel.ShortDescription,
            LongDescription = viewModel.LongDescription,
            Price = viewModel.Price,
            Amount = viewModel.Amount,
            IdCategory = viewModel.IdCategory,
            IdProducer = viewModel.IdProducer
        };

        await CreateAsync(product);
        
        var images = new List<IFormFile>();
        images = viewModel.Images;
        await ConvertFileAsync(images, product.Id);
        
        return true;
    }
    
    public async Task<bool> ConvertFileAsync(List<IFormFile> entities, int idProduct)
    {
        var images = new List<Image>();

        foreach (var formFile in entities)
        {
            if (formFile.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await formFile.CopyToAsync(memoryStream);
                    var image = new Image
                    {
                        ImageData = memoryStream.ToArray(),
                        IdProduct = idProduct
                    };
                    images.Add(image);
                }
            }
        }

        await CreateObjectsAsync(images);
        
        return true;
    }

    public async Task<bool> CreateObjectsAsync(List<Image> entities)
    {
        await _db.AddRangeAsync(entities);
        await _db.SaveChangesAsync();

        return true;
    }
}