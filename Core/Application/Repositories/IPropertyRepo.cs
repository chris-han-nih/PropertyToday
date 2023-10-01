namespace Application.Repositories;

using Domain;

public interface IPropertyRepo
{
    Task AddNewAsync(Property property);
    Task DeleteAsync(Property property);
    Task<List<Property>> GetAllAsync();
    Task UpdateAsync(Property property);
    Task<Property> GetByIdAsync(int id);
}
