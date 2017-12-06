using TicketSystem.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TicketSystem.Data
{
    public class TicketSystemDbContext : IdentityDbContext< User >
    {
        public DbSet< Album > Albums { get; set; }

        public DbSet< Band > Bands { get; set; }

        public DbSet< Song > Songs { get; set; }

        public DbSet< Concert > Concerts { get; set; }

        public DbSet< Ticket > Tickets { get; set; }

        public TicketSystemDbContext( DbContextOptions< TicketSystemDbContext > options )
            : base( options )
        {
        }

        protected override void OnModelCreating( ModelBuilder builder )
        {
            builder
                .Entity< BandConcert >()
                .HasKey( bc => new { bc.BandId, bc.ConcertId } );

            builder
                .Entity< BandConcert >()
                .HasOne( b => b.Band )
                .WithMany( bc => bc.Concerts )
                .HasForeignKey( b => b.BandId );

            builder
                .Entity< BandConcert >()
                .HasOne( c => c.Concert )
                .WithMany( bc => bc.Bands )
                .HasForeignKey( c => c.ConcertId );

            builder
                .Entity< Album >()
                .HasOne( a => a.Band )
                .WithMany( b => b.Albums )
                .HasForeignKey( a => a.BandId );

            builder
                .Entity< Album >()
                .HasMany( a => a.Songs )
                .WithOne( s => s.Album )
                .HasForeignKey( s => s.AlbumId );

            builder
                .Entity< Band >()
                .HasMany( a => a.Albums )
                .WithOne( b => b.Band )
                .HasForeignKey( b => b.BandId );

            builder
                .Entity< Ticket >()
                .HasOne( c => c.Concert )
                .WithMany( t => t.Tickets )
                .HasForeignKey( c => c.ConcertId );

            builder
                .Entity< Ticket >()
                .HasOne( t => t.User )
                .WithMany( u => u.Tickets )
                .HasForeignKey( t => t.UserId );

            base.OnModelCreating( builder );
        }
    }
}