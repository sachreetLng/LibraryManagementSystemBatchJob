using CheckIssuedBooksTimeLimit.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIssuedBooksTimeLimit.Data
{
    public class LibraryServiceContext : DbContext
    {
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
