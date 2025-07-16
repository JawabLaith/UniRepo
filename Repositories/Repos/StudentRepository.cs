using Microsoft.EntityFrameworkCore;
using University.Repositories.Interfaces;
using UniversityAPI.Repositories.Interfaces;
using UniversityAPI.Data;

namespace UniversityAPI.Repositories.Repos;

public class StudentRepository : IStudentRepository
{
    private readonly DataContextEF _context;

    public StudentRepository(DataContextEF context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Student>> GetAllAsync()
    {
        return await _context.Students.ToListAsync();
    }
    
    public async Task<Student> GetByIdAsync(int id)
    {
        return await _context.Students.FindAsync(id);
    }

    public async Task AddAsync(Student student)
    {
         _context.Students.Add(student);
         await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Student student)
    {
        _context.Students.Update(student);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var student = await GetByIdAsync(id);
        if (student != null){
        _context.Students.Remove(student);
        await _context.SaveChangesAsync();
        }
    }
}