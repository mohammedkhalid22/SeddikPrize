﻿using FinalProjectSeddik.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectSeddik.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
                : base(options)
        {

        }
        public DbSet<compRegs> compRegs { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<Contact> ContactUs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<compRegs>()
                .HasOne(b => b.CompProj)
                .WithOne(i => i.CompReg)
                .HasForeignKey<Projects>(b => b.CompId);
        }
    }
}
