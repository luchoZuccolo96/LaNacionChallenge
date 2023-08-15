// MyApi.Data.DataContext.cs

using Microsoft.EntityFrameworkCore;
using ChallengeLaNacion.Models;

namespace ChallengeLaNacion.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}
