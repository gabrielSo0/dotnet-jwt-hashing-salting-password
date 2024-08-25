using hashing_salting_password.Models;
using Microsoft.EntityFrameworkCore;

namespace hashing_salting_password.Data
{
    public class InMemoryContext(DbContextOptions<InMemoryContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
    }
}