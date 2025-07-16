using UniversityAPI.Repositories;

namespace UniversityAPI.Repositories.Interfaces;

public interface IUniversityRepository
{
    Task<IEnumerable<University>> GetAllAsync();
    Task<University> GetByIdAsync(int id);
    Task AddAsync(University university);
    Task UpdateAsync(University university);
    Task DeleteAsync(int id);
}