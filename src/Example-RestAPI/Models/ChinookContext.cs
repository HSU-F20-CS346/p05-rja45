using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Threading.Tasks;
using Example_RestAPI.Models;

namespace Example_RestAPI.Models
{
    public class ChinookContext : DbContext
    {

        public ChinookContext() : base()
        {
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Invoice_item> Invoice_Items { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Media_type> Media_types { get; set; }      
        public DbSet<Playlist_track> Playlist_track { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Track> Tracks { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=chinook.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Playlist_track>()
                .HasKey(c => new { c.PlaylistID, c.TrackID });
        }
    }

}