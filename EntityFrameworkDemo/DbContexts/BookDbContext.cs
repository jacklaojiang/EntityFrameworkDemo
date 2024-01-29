using EntityFrameworkDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkDemo.DbContexts
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Edition> Editions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .HasKey(a => a.AuthorID);

            modelBuilder.Entity<Edition>()
                .HasOne(b => b.Book)
                .WithMany(e => e.Editions)
                .HasForeignKey(b => b.BookID);


            modelBuilder.Entity<Book>()
                .HasOne(a => a.Author)
                .WithMany(b => b.Books)
                .HasForeignKey(a => a.AuthID);
        }

        /* How to migrate db and update db:

         * View – other window – package manager console,

         * If its first time doing db migration , then :  Install-Package Microsoft.EntityFrameworkCore.Tools

         Add-Migration "<MigrationName>" 
        
         Update-Database
         */
    }
}
