namespace Infrastructure.Repositories;

using Application.Repositories;
using Domain;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

public class PropertyRepo: IPropertyRepo
{
    private readonly ApplicationDbContext _context;

    public PropertyRepo(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddNewAsync(Property property)
    {
        await _context.Properties.AddAsync(property);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Property property)
    {
        _context.Properties.Remove(property);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Property>> GetAllAsync()
    {
        return await _context.Properties.ToListAsync();
    }

    public async Task UpdateAsync(Property property)
    {
        _context.Properties.Update(property);
        await _context.SaveChangesAsync();
    }

    public async Task<Property> GetByIdAsync(int id)
    {
        var property = await _context.Properties.FirstOrDefaultAsync(x => x.Id == id);
        return property;
    }
}
