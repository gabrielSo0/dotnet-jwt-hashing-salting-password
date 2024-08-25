using hashing_salting_password.Data;
using hashing_salting_password.Models;
using hashing_salting_password.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace hashing_salting_password.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly InMemoryContext _context;

        public UserRepository(InMemoryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id.Equals(id));

            if(user is null) return null;

            return user;
        }

        public async Task<User> Create(User model)
        {
            if(model is null) return null;

            await _context.Users.AddAsync(model);
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task<User> Update(User model)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id.Equals(model.Id));

            if(user is null) return null;

            _context.Update(model);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<bool> Delete(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id.Equals(id));

            if(user is null) return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}