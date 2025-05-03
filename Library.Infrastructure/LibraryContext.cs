using Library.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Library.Infrastructure
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }

        public DbSet<BookModel> Books { get; set; }
        public DbSet<AudioBookModel> AudioBooks { get; set; }
        public DbSet<EBookModel> EBooks { get; set; }
        public DbSet<LibraryMemberModel> LibraryMembers { get; set; }
        public DbSet<TagModel> Tags { get; set; }
        public DbSet<BookTagModel> BookTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ===== Table-per-Type успадкування =====
            modelBuilder.Entity<BookModel>().ToTable("Books");
            modelBuilder.Entity<AudioBookModel>().ToTable("AudioBooks");
            modelBuilder.Entity<EBookModel>().ToTable("EBooks");

            // ===== Один-до-багатьох: Book → LibraryMember =====
            modelBuilder.Entity<BookModel>()
                .HasOne(b => b.LibraryMember)
                .WithMany(l => l.BorrowedBooks)
                .HasForeignKey(b => b.LibraryMemberId)
                .OnDelete(DeleteBehavior.Cascade);

            // ===== Багато-до-багатьох: Book ↔ Tag через BookTag =====
            modelBuilder.Entity<BookTagModel>()
                .HasKey(bt => new { bt.BookId, bt.TagId });

            modelBuilder.Entity<BookTagModel>()
                .HasOne(bt => bt.Book)
                .WithMany(b => b.BookTags)
                .HasForeignKey(bt => bt.BookId);

            modelBuilder.Entity<BookTagModel>()
                .HasOne(bt => bt.Tag)
                .WithMany(t => t.BookTags)
                .HasForeignKey(bt => bt.TagId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
