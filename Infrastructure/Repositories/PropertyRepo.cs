namespace Infrastructure.Repositories;

using Application.Repositories;
using Domain;
using Infrastructure.Contexts;

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

    public Task DeleteAsync(Property property)
    {
        throw new NotImplementedException();
    }

    public Task<List<Property>> GetAllAsync() => throw new NotImplementedException();

    public Task UpdateAsync(Property property) => throw new NotImplementedException();

    public Task<Property> GetByIdAsync(int id) => throw new NotImplementedException();
}