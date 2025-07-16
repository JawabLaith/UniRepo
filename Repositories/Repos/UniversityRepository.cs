using Microsoft.EntityFrameworkCore;
using UniversityAPI.Data;
using UniversityAPI.Repositories.Interfaces;

namespace University.Repositories;

public class UniversityRepository : IUniversityRepository
{
    private readonly DataContextEF _context;

    public UniversityRepository(DataContextEF context)
    {
        _context = context;
    }

    public async Task<IEnumerable<UniversityAPI.University>> GetAllAsync()
    {
        return await _context.Universities.ToListAsync();
    }

    public async Task<UniversityAPI.University> GetByIdAsync(int id)
    {
        return await _context.Universities.FindAsync(id);
    }

    public async Task AddAsync(UniversityAPI.University university)
    {
        _context.Universities.Add(university);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(UniversityAPI.University university)
    {
        _context.Universities.Update(university);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var university = await GetByIdAsync(id);
        if (university != null)
        {
            _context.Universities.Remove(university);
            await _context.SaveChangesAsync();
        }
    }
}