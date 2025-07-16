using Microsoft.EntityFrameworkCore;
using University.Repositories.Interfaces;
using UniversityAPI.Repositories.Interfaces;
using UniversityAPI;
using UniversityAPI.Data;
using UniversityAPI.Repositories;

namespace University.Repositories;

public class CourseRepository : ICourseRepository
{
    private readonly DataContextEF _context;

    public CourseRepository(DataContextEF context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Course>> GetAllAsync()
    {
        return await _context.Courses.ToListAsync();
    }

    public async Task<Course> GetByIdAsync(int id)
    {
        return await _context.Courses.FindAsync(id);
    }

    public async Task AddAsync(Course course)
    {
        _context.Courses.Add(course);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Course course)
    {
        _context.Courses.Update(course);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var course = await GetByIdAsync(id);
        if (course != null)
        {
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
        }
    }
}