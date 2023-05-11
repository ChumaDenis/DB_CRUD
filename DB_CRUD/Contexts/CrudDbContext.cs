using DB_CRUD.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DB_CRUD.Contexts
{
    public class CrudDbContext:DbContext
{
    public DbSet<User> Users { get; set; }

        public CrudDbContext(DbContextOptions<CrudDbContext> options) : base(options)
        {
        }
    }
}
