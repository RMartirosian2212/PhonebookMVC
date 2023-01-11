using Microsoft.EntityFrameworkCore;
using Phonebook.Models;
using System.Collections.Generic;

namespace Phonebook.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {

        }
        public DbSet<Contact> Contacts { get; set; }
    }
}
