using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;
using Todo.Core.Entities;
using Todo.Core.Enums;
using Todo.Core.Interfaces;
using Todo.Infrastructure.Data;

namespace Todo.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly ApplicationDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
       return  await _dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }
  

    public async Task<T> AddAsync(T entity) => (await _dbSet.AddAsync(entity)).Entity;
    public async Task UpdateAsync(T entity) => _dbSet.Update(entity);
    public async Task DeleteAsync(T entity) => _dbSet.Remove(entity);

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
