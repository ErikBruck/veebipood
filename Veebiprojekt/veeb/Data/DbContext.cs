using Microsoft.EntityFrameworkCore;
using veeb.models;
using System.Collections.Generic;

namespace veeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Toode> Tooted { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}