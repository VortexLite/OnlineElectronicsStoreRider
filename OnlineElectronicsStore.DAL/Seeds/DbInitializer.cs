using OnlineElectronicsStore.Domain.Entity;
namespace OnlineElectronicsStore.DAL.Seeds;

public class DbInitializer
{
    private readonly ApplicationDbContext _context;
    public DbInitializer(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task SeedCategories()
    {
        if (!_context.Categories.Any())
        {
            var categories = new List<Category>()
            {
                new Category
                {
                    Name = "Ноутбуки"
                },
                new Category
                {
                    Name = "Смартфони"
                },
                new Category
                {
                    Name = "Навушники"
                },
                new Category
                {
                    Name = "Power Bank"
                },
                new Category
                {
                    Name = "Телевізори"
                },
                new Category
                {
                    Name = "Фото і відео техніка"
                },
                new Category
                {
                    Name = "Планшети"
                },
                new Category
                {
                    Name = "Комп'ютери"
                },
                new Category
                {
                    Name = "Монітори"
                },
                new Category
                {
                    Name = "Відеокарти"
                },
                new Category
                {
                    Name = "Процесори"
                },
                new Category
                {
                    Name = "Оперативна пам'ять"
                },
                new Category
                {
                    Name = "SSD"
                },
                new Category
                {
                    Name = "Материнська плата"
                }
            };
            await _context.AddRangeAsync(categories);
            await _context.SaveChangesAsync();
        }
        
        
    }

    public async Task SeedDeliveryTypes()
    {
        if (!_context.DeliveryTypes.Any())
        {
            var deliveryTypes = new List<DeliveryType>()
            {
                new DeliveryType
                {
                    Name = "Нова пошта"
                },
                new DeliveryType
                {
                    Name = "Укр пошта"
                },
                new DeliveryType
                {
                    Name = "На відділення"
                }
            };
            await _context.AddRangeAsync(deliveryTypes);
            await _context.SaveChangesAsync();
        }
    }
    
    public async Task SeedProducers()
    {
        if (!_context.Producers.Any())
        {
            var producers = new List<Producer>()
            {
                new Producer
                {
                    Name = "Samsung"
                },
                new Producer
                {
                    Name = "MSI"
                },
                new Producer
                {
                    Name = "Lenovo"
                },
                new Producer
                {
                    Name = "Acer"
                },
                new Producer
                {
                    Name = "Xiaomi"
                },
                new Producer
                {
                    Name = "Apple"
                },
                new Producer
                {
                    Name = "Google"
                },
                new Producer
                {
                    Name = "ASUS"
                },
                new Producer
                {
                    Name = "LG"
                },
                new Producer
                {
                    Name = "Sony"
                },
                new Producer
                {
                    Name = "Philips"
                },
                new Producer
                {
                    Name = "Marshall"
                },
                new Producer
                {
                    Name = "Logitech"
                },
                new Producer
                {
                    Name = "Baseus"
                },
                new Producer
                {
                    Name = "Panasonic"
                },
                new Producer
                {
                    Name = "Canon"
                },
                new Producer
                {
                    Name = "Nikon"
                },
                
                new Producer
                {
                    Name = "Fujifilm"
                },
                new Producer
                {
                    Name = "Realme"
                },
                new Producer
                {
                    Name = "Pixel"
                },
                new Producer
                {
                    Name = "ASRock"
                },
                new Producer
                {
                    Name = "Dell"
                },
                new Producer
                {
                    Name = "Gigabyte"
                },
                new Producer
                {
                    Name = "Sapphire"
                },
                new Producer
                {
                    Name = "Kingston"
                },
                new Producer
                {
                    Name = "Intel"
                },
                new Producer
                {
                    Name = "AMD"
                }
            };
            await _context.AddRangeAsync(producers);
            await _context.SaveChangesAsync();
        }
    }
    
    public async Task SeedNavigations()
    {
        if (!_context.Navigations.Any())
        {
            var navigations = new List<Navigation>()
            {
                new Navigation
                {
                    IdCategory = 1,
                    IdProducer = 1
                },
                new Navigation
                {
                    IdCategory = 1,
                    IdProducer = 2
                },
                new Navigation
                {
                    IdCategory = 1,
                    IdProducer = 3
                },
                new Navigation
                {
                    IdCategory = 1,
                    IdProducer = 4
                },
                new Navigation
                {
                    IdCategory = 1,
                    IdProducer = 5
                },
                new Navigation
                {
                    IdCategory = 1,
                    IdProducer = 6
                },
                new Navigation
                {
                    IdCategory = 1,
                    IdProducer = 8
                },
                new Navigation
                {
                    IdCategory = 1,
                    IdProducer = 22
                },
                new Navigation
                {
                    IdCategory = 1,
                    IdProducer = 23
                },
                new Navigation
                {
                    IdCategory = 2,
                    IdProducer = 1
                },
                new Navigation
                {
                    IdCategory = 2,
                    IdProducer = 2
                },
                new Navigation
                {
                    IdCategory = 2,
                    IdProducer = 3
                },
                new Navigation
                {
                    IdCategory = 2,
                    IdProducer = 5
                },
                new Navigation
                {
                    IdCategory = 2,
                    IdProducer = 6
                },
                new Navigation
                {
                    IdCategory = 2,
                    IdProducer = 7
                },
                new Navigation
                {
                    IdCategory = 2,
                    IdProducer = 8
                },
                new Navigation
                {
                    IdCategory = 2,
                    IdProducer = 9
                },
                new Navigation
                {
                    IdCategory = 2,
                    IdProducer = 10
                },
                new Navigation
                {
                    IdCategory = 2,
                    IdProducer = 19
                },
                new Navigation
                {
                    IdCategory = 2,
                    IdProducer = 20
                },
                new Navigation
                {
                    IdCategory = 3,
                    IdProducer = 1
                },
                new Navigation
                {
                    IdCategory = 3,
                    IdProducer = 2
                },
                new Navigation
                {
                    IdCategory = 3,
                    IdProducer = 3
                },
                new Navigation
                {
                    IdCategory = 3,
                    IdProducer = 4
                },
                new Navigation
                {
                    IdCategory = 3,
                    IdProducer = 5
                },
                new Navigation
                {
                    IdCategory = 3,
                    IdProducer = 6
                },
                new Navigation
                {
                    IdCategory = 3,
                    IdProducer = 7
                },
                new Navigation
                {
                    IdCategory = 3,
                    IdProducer = 8
                },
                new Navigation
                {
                    IdCategory = 3,
                    IdProducer = 9
                },
                new Navigation
                {
                    IdCategory = 3,
                    IdProducer = 10
                },
                new Navigation
                {
                    IdCategory = 3,
                    IdProducer = 11
                },
                new Navigation
                {
                    IdCategory = 3,
                    IdProducer = 12
                },
                new Navigation
                {
                    IdCategory = 3,
                    IdProducer = 13
                },
                new Navigation
                {
                    IdCategory = 3,
                    IdProducer = 14
                },
                new Navigation
                {
                    IdCategory = 3,
                    IdProducer = 15
                },
                new Navigation
                {
                    IdCategory = 3,
                    IdProducer = 19
                },
                new Navigation
                {
                    IdCategory = 3,
                    IdProducer = 20
                },
                new Navigation
                {
                    IdCategory = 3,
                    IdProducer = 23
                },
                new Navigation
                {
                    IdCategory = 4,
                    IdProducer = 1
                },
                new Navigation
                {
                    IdCategory = 4,
                    IdProducer = 3
                },
                new Navigation
                {
                    IdCategory = 4,
                    IdProducer = 5
                },
                new Navigation
                {
                    IdCategory = 4,
                    IdProducer = 11
                },
                new Navigation
                {
                    IdCategory = 4,
                    IdProducer = 15
                },
                new Navigation
                {
                    IdCategory = 5,
                    IdProducer = 1
                },
                new Navigation
                {
                    IdCategory = 5,
                    IdProducer = 2
                },
                new Navigation
                {
                    IdCategory = 5,
                    IdProducer = 3
                },
                new Navigation
                {
                    IdCategory = 5,
                    IdProducer = 5
                },
                new Navigation
                {
                    IdCategory = 5,
                    IdProducer = 8
                },
                new Navigation
                {
                    IdCategory = 5,
                    IdProducer = 9
                },
                new Navigation
                {
                    IdCategory = 5,
                    IdProducer = 22
                },
                new Navigation
                {
                    IdCategory = 6,
                    IdProducer = 1
                },
                new Navigation
                {
                    IdCategory = 6,
                    IdProducer = 9
                },
                new Navigation
                {
                    IdCategory = 6,
                    IdProducer = 10
                },
                new Navigation
                {
                    IdCategory = 6,
                    IdProducer = 15
                },
                new Navigation
                {
                    IdCategory = 6,
                    IdProducer = 16
                },
                new Navigation
                {
                    IdCategory = 6,
                    IdProducer = 17
                },
                new Navigation
                {
                    IdCategory = 6,
                    IdProducer = 18
                },
                new Navigation
                {
                    IdCategory = 7,
                    IdProducer = 1
                },
                new Navigation
                {
                    IdCategory = 7,
                    IdProducer = 5
                },
                new Navigation
                {
                    IdCategory = 7,
                    IdProducer = 6
                },
                new Navigation
                {
                    IdCategory = 7,
                    IdProducer = 7
                },
                new Navigation
                {
                    IdCategory = 7,
                    IdProducer = 8
                },
                new Navigation
                {
                    IdCategory = 7,
                    IdProducer = 9
                },
                new Navigation
                {
                    IdCategory = 7,
                    IdProducer = 10
                },
                new Navigation
                {
                    IdCategory = 7,
                    IdProducer = 19
                },
                new Navigation
                {
                    IdCategory = 8,
                    IdProducer = 2
                },
                new Navigation
                {
                    IdCategory = 8,
                    IdProducer = 3
                },
                new Navigation
                {
                    IdCategory = 8,
                    IdProducer = 4
                },
                new Navigation
                {
                    IdCategory = 8,
                    IdProducer = 6
                },
                new Navigation
                {
                    IdCategory = 8,
                    IdProducer = 8
                },
                new Navigation
                {
                    IdCategory = 8,
                    IdProducer = 10
                },
                new Navigation
                {
                    IdCategory = 8,
                    IdProducer = 21
                },
                new Navigation
                {
                    IdCategory = 8,
                    IdProducer = 22
                },
                new Navigation
                {
                    IdCategory = 8,
                    IdProducer = 23
                },
                new Navigation
                {
                    IdCategory = 9,
                    IdProducer = 1
                },
                new Navigation
                {
                    IdCategory = 9,
                    IdProducer = 2
                },
                new Navigation
                {
                    IdCategory = 9,
                    IdProducer = 3
                },
                new Navigation
                {
                    IdCategory = 9,
                    IdProducer = 4
                },
                new Navigation
                {
                    IdCategory = 9,
                    IdProducer = 5
                },
                new Navigation
                {
                    IdCategory = 9,
                    IdProducer = 8
                },
                new Navigation
                {
                    IdCategory = 9,
                    IdProducer = 9
                },
                new Navigation
                {
                    IdCategory = 9,
                    IdProducer = 22
                },
                new Navigation
                {
                    IdCategory = 10,
                    IdProducer = 2
                },
                new Navigation
                {
                    IdCategory = 10,
                    IdProducer = 8
                },
                new Navigation
                {
                    IdCategory = 10,
                    IdProducer = 21
                },
                new Navigation
                {
                    IdCategory = 10,
                    IdProducer = 23
                },
                new Navigation
                {
                    IdCategory = 10,
                    IdProducer = 24
                },
                new Navigation
                {
                    IdCategory = 11,
                    IdProducer = 26
                },
                new Navigation
                {
                    IdCategory = 11,
                    IdProducer = 27
                },
                new Navigation
                {
                    IdCategory = 12,
                    IdProducer = 1
                },
                new Navigation
                {
                    IdCategory = 12,
                    IdProducer = 2
                },
                new Navigation
                {
                    IdCategory = 12,
                    IdProducer = 25
                },
                new Navigation
                {
                    IdCategory = 13,
                    IdProducer = 1
                },
                new Navigation
                {
                    IdCategory = 13,
                    IdProducer = 2
                },
                new Navigation
                {
                    IdCategory = 13,
                    IdProducer = 4
                },
                new Navigation
                {
                    IdCategory = 13,
                    IdProducer = 25
                },
                new Navigation
                {
                    IdCategory = 14,
                    IdProducer = 2
                },
                new Navigation
                {
                    IdCategory = 14,
                    IdProducer = 4
                },
                new Navigation
                {
                    IdCategory = 14,
                    IdProducer = 8
                },
                new Navigation
                {
                    IdCategory = 14,
                    IdProducer = 23
                },
                new Navigation
                {
                    IdCategory = 14,
                    IdProducer = 24
                }
            };
            await _context.AddRangeAsync(navigations);
            await _context.SaveChangesAsync();
        }
    }
    
    public async Task SeedStatusDeliveries()
    {
        if (!_context.StatusDeliveries.Any())
        {
            var statusDelivery = new List<StatusDelivery>()
            {
                new StatusDelivery
                {
                    Name = "Очікується"
                },
                new StatusDelivery
                {
                    Name = "Обробляється"
                },
                new StatusDelivery
                {
                    Name = "Доставляєтся"
                },
                new StatusDelivery
                {
                    Name = "Доставлено"
                },
                new StatusDelivery
                {
                    Name = "Повернуто"
                }
            };
            await _context.AddRangeAsync(statusDelivery);
            await _context.SaveChangesAsync();
        }
    }
    
    public async Task SeedCategoryReviews()
    {
        if (!_context.CategoryReviews.Any())
        {
            var categoryReviews = new List<CategoryReview>()
            {
                new CategoryReview
                {
                    Name = "User"
                },
                new CategoryReview
                {
                    Name = "Order"
                },
                new CategoryReview
                {
                    Name = "Product"
                }
            };
            await _context.AddRangeAsync(categoryReviews);
            await _context.SaveChangesAsync();
        }
    }
    
    public async Task SeedProducts()
    {
        if (!_context.Products.Any())
        {
            var products = new List<Product>()
            {
                new Product
                {
                    Name = "Xiaomi 14 12/512GB Black",
                    ShortDescription = "test",
                    Price = 4499,
                    Amount = 1,
                    IdCategory = 2,
                    IdProducer = 5
                },
                new Product
                {
                    Name = "Телевізор Xiaomi TV A2 32",
                    ShortDescription = "test",
                    Price = 8499,
                    Amount = 1,
                    IdCategory = 5,
                    IdProducer = 5
                },
                new Product
                {
                    Name = "Навушники Apple AirPods with Charging Case 2 gen (MV7N2RU/A) White",
                    ShortDescription = "test",
                    Price = 4999,
                    Amount = 1,
                    IdCategory = 3,
                    IdProducer = 6
                },
                new Product
                {
                    Name = "Планшет Xiaomi Redmi Pad SE 4/128GB Graphite Gray (VHU4448EU)",
                    ShortDescription = "test",
                    Price = 7999,
                    Amount = 1,
                    IdCategory = 7,
                    IdProducer = 5
                },
                new Product
                {
                    Name = "Монітор 23.8\\ Xiaomi Mi Monitor 1C (BHR4510GL) Black",
                    ShortDescription = "test",
                    Price = 3999,
                    Amount = 1,
                    IdCategory = 5,
                    IdProducer = 5
                }
            };
            await _context.AddRangeAsync(products);
            await _context.SaveChangesAsync();
        }
    }
}

