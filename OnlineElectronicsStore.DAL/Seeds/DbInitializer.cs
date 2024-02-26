using OnlineElectronicsStore.Domain.Entity;

namespace OnlineElectronicsStore.DAL.Seeds;

public class DbInitializer
{
    private readonly ApplicationDbContext _context;
    public DbInitializer(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task Seed()
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
                    Name = "Звук. обладнання"
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
                    Name = "Комп'ютери"
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
        }

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
        }

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
            };
            await _context.AddRangeAsync(producers);
        }
        
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
        }
        
        await _context.SaveChangesAsync();
    }
    
}