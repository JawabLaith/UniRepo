using UniversityAPI;
using UniversityAPI.Repositories;

namespace University.Repositories.Interfaces;

public interface IInstructorRepository
{
    Task<IEnumerable<Instructor>> GetAllAsync(); 
    Task<Instructor> GetByIdAsync(int id);        
    Task AddAsync(Instructor instructor);         
    Task UpdateAsync(Instructor instructor);     
    Task DeleteAsync(int id);
}