using Microsoft.EntityFrameworkCore;
using OnlineElectronicsStore.DAL.Interfaces;
using OnlineElectronicsStore.Domain.Entity;

namespace OnlineElectronicsStore.DAL.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _context;
    public CategoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public bool Create(Category entity)
    {
        throw new NotImplementedException();
    }

    public Category Get(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Category>> Select()
    {
        return await _context.Categories.ToListAsync();
    }

    public bool Delete(Category entity)
    {
        throw new NotImplementedException();
    }

    public Category GetByName(string name)
    {
        throw new NotImplementedException();
    }
}