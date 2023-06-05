using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckIssuedBooksTimeLimit.Core.Entities;

namespace CheckIssuedBooksTimeLimit.DBconnect.Data
{
    public class LibraryServiceContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Configure your database provider here
                optionsBuilder.UseSqlServer("Data Source = DESKTOP-PHC5QCQ\\SQLEXPRESS; Initial Catalog = LMS; Trusted_Connection = SSPI; Encrypt = false; Integrated Security = True;");
            }
        }
        public LibraryServiceContext(DbContextOptions<LibraryServiceContext> options)
        : base(options)
        {

        }
        public DbSet<Book>Books { get; set; }
        public DbSet<IssueBook> IssueBooks { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<BookReminder> BookReminder { get; set; }
    }
}
