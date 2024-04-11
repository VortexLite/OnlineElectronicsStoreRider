using Microsoft.EntityFrameworkCore;
using OnlineElectronicsStore.DAL;
using OnlineElectronicsStore.DAL.Repositories;
using OnlineElectronicsStore.Domain.Entity;

namespace Repositories;

public class RepositoryTests : IDisposable
{
    private readonly DbContextOptions<ApplicationDbContext> _options;
    private readonly ApplicationDbContext _context;
    public RepositoryTests()
    {
        _options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;
        _context = new ApplicationDbContext(_options);
    }

    [Fact]
    public async Task AuthenticateLoginPasswordUser_ValidCredentials_ReturnsUser()
    {
        await _context.Users.AddAsync(new User { Id = 1, Login = "testuser", Password = "testpassword" });
        await _context.SaveChangesAsync();

        var repository = new AuthenticateRepository(_context);

        var user = await repository.AuthenticateLoginPasswordUserAsync("testuser", "testpassword");

        Assert.NotNull(user);
        Assert.Equal("testuser", user.Login);
    }

    [Fact]
    public async Task Create_Should_Add_Category_To_Database()
    {
        using (var context = new ApplicationDbContext(_options))
        {
            var repository = new CategoryRepository(context);
            var category = new Category { Name = "Test Category" };

            // Act
            var result = await repository.CreateAsync(category);

            // Assert
            Assert.True(result);

            var addedCategory = await context.Categories.FirstOrDefaultAsync(c => c.Name == "Test Category");
            Assert.NotNull(addedCategory);
            Assert.Equal("Test Category", addedCategory.Name);
        }
    }

    [Fact]
    public async Task Create_Should_Add_Order_To_Database()
    {
        // Arrange
        using (var context = new ApplicationDbContext(_options))
        {
            var repository = new OrderRepository(context);
            var order = new Order
            {
                Id = 1,
                DateOrder = DateTime.Now,
                TotalCost = 30000,
                Address = "Вулиця густинська 69А",
                IdProfile = 1,
                IdDeliveryType = 1,
                IdStatusDelivery = 1
            };

            // Act
            var result = await repository.CreateAsync(order);

            // Assert
            Assert.True(result);

            var addedOrder = await context.Orders.FirstOrDefaultAsync(o => o.Id == order.Id);
            Assert.NotNull(addedOrder);
            // Add more assertions as per your requirements
        }
    }

    [Fact]
    public async Task Get_Should_Retrieve_Order_From_Database()
    {
        // Arrange
        using (var context = new ApplicationDbContext(_options))
        {
            var repository = new OrderRepository(context);
            var order = new Order
            {
                Id = 1,
                DateOrder = DateTime.Now,
                TotalCost = 30000,
                Address = "Вулиця густинська 69А",
                IdProfile = 1,
                IdDeliveryType = 1,
                IdStatusDelivery = 1
            };
            await context.Orders.AddAsync(order);
            await context.SaveChangesAsync();

            // Act
            var result = await repository.GetAsync(order.Id);

            // Assert
            Assert.NotNull(result);
            // Add more assertions as per your requirements
        }
    }
    
    [Fact]
    public async Task Select_Should_Return_All_OrderDetails()
    {
        // Arrange
        using (var context = new ApplicationDbContext(_options))
        {
            var repository = new OrderDetailsRepository(context);
            var orderDetails = new List<OrderDetail>
            {
                new OrderDetail
                {
                    Id = 1,
                    IdOrder = 1,
                    IdProduct = 1,
                    Quantity = 3,
                    Price = 2312
                },
                new OrderDetail
                {
                    Id = 2,
                    IdOrder = 2,
                    IdProduct = 2,
                    Quantity = 7,
                    Price = 6453
                },
                new OrderDetail
                {
                    Id = 3,
                    IdOrder = 3,
                    IdProduct = 3,
                    Quantity = 86,
                    Price = 42355
                }
            };
            await context.OrderDetails.AddRangeAsync(orderDetails);
            await context.SaveChangesAsync();

            // Act
            var result = await repository.SelectAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count);
        }
    }
    
    [Fact]
    public async Task Delete_Should_Remove_OrderDetail_From_Database()
    {
        // Arrange
        using (var context = new ApplicationDbContext(_options))
        {
            var repository = new OrderDetailsRepository(context);
            var orderDetail = new OrderDetail
            {
                Id = 1,
                IdOrder = 1,
                IdProduct = 1,
                Quantity = 3,
                Price = 2312
            };
            await context.OrderDetails.AddAsync(orderDetail);
            await context.SaveChangesAsync();

            // Act
            var result = await repository.DeleteAsync(orderDetail);

            // Assert
            Assert.True(result);

            var deletedOrderDetail = await context.OrderDetails.FirstOrDefaultAsync(od => od.Id == orderDetail.Id);
            Assert.Null(deletedOrderDetail);
        }
    }
    
    [Fact]
    public async Task Create_Should_Add_User_To_Database()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "InMemoryDb")
            .Options;

        using (var context = new ApplicationDbContext(options))
        {
            var repository = new UserRepository(context);
            var user = new User
            {
                Id = 1,
                Login = "test1",
                Password = "123456789",
                IdProfile = 1,
                IdRole = 1
            };

            // Act
            var result = await repository.CreateAsync(user);

            // Assert
            Assert.True(result);

            var addedUser = await context.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
            Assert.NotNull(addedUser);
            // Add more assertions as per your requirements
        } 
    }
    [Fact]
        public async Task Create_Should_Add_WishList_To_Database()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDb")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                var repository = new WishListRepository(context);
                var wishList = new WishList
                {
                    Id = 1,
                    IdProfile = 1
                };

                // Act
                var result = await repository.CreateAsync(wishList);

                // Assert
                Assert.True(result);

                var addedWishList = await context.WishLists.FirstOrDefaultAsync(w => w.Id == wishList.Id);
                Assert.NotNull(addedWishList);
                // Add more assertions as per your requirements
            }
        }

        [Fact]
        public async Task Get_Should_Retrieve_WishList_From_Database()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDb")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                var repository = new WishListRepository(context);
                var wishList = new WishList
                {
                    IdProfile = 1
                };
                await context.WishLists.AddAsync(wishList);
                await context.SaveChangesAsync();

                // Act
                var result = await repository.GetAsync(wishList.Id);

                // Assert
                Assert.NotNull(result);
                // Add more assertions as per your requirements
            }
        }
        

        [Fact]
        public async Task Delete_Should_Remove_WishList_From_Database()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDb")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                var repository = new WishListRepository(context);
                var wishList = new WishList
                {
                    IdProfile = 1
                };
                await context.WishLists.AddAsync(wishList);
                await context.SaveChangesAsync();

                // Act
                var result = await repository.DeleteAsync(wishList);

                // Assert
                Assert.True(result);

                var deletedWishList = await context.WishLists.FirstOrDefaultAsync(w => w.Id == wishList.Id);
                Assert.Null(deletedWishList);
                // Add more assertions as per your requirements
            }
        }

    public void Dispose()
    {
        _context.Database.EnsureDeleted();
        _context.Dispose();
    }
}