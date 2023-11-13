﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Stoica_Ramona_Lab2.Models;

namespace Stoica_Ramona_Lab2.Data
{
    public class Stoica_Ramona_Lab2Context : DbContext
    {
        public Stoica_Ramona_Lab2Context(DbContextOptions<Stoica_Ramona_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Stoica_Ramona_Lab2.Models.Book> Book { get; set; } = default!;

        public DbSet<Stoica_Ramona_Lab2.Models.Publisher>? Publisher { get; set; }

        public DbSet<Stoica_Ramona_Lab2.Models.Author>? Author { get; set; }

        public DbSet<Stoica_Ramona_Lab2.Models.Category>? Category { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Borrowing)
                .WithOne(b => b.Book)
                .HasForeignKey<Borrowing>(b => b.BookID);

        }

        public DbSet<Stoica_Ramona_Lab2.Models.Member>? Member { get; set; }

        public DbSet<Stoica_Ramona_Lab2.Models.Borrowing>? Borrowing { get; set; }
    }
}
