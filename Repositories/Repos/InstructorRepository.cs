using Microsoft.EntityFrameworkCore;
using University.Repositories.Interfaces;
using UniversityAPI.Repositories.Interfaces;
using UniversityAPI;
using UniversityAPI.Data;

namespace University.Repositories;

    public class InstructorRepository : IInstructorRepository
    {
        private readonly DataContextEF _context;
        
        public InstructorRepository(DataContextEF context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<Instructor>> GetAllAsync()
        {
            return await _context.Instructors.ToListAsync();
        }
        
        public async Task<Instructor> GetByIdAsync(int id)
        {
            return await _context.Instructors.FindAsync(id);
        }

        public async Task AddAsync(Instructor instructor)
        {
            _context.Instructors.Add(instructor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Instructor instructor)
        {
            _context.Instructors.Update(instructor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var instructor = await GetByIdAsync(id);
            if (instructor != null)
            {
                _context.Instructors.Remove(instructor);
                await _context.SaveChangesAsync();
            }
        }
    }