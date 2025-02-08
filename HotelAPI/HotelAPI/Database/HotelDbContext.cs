using System.Reflection;
using HotelAPI.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Database;

public class HotelDbContext(DbContextOptions<HotelDbContext> options) : DbContext(options)
{
    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Booking> Bookings { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Hotel>()
            .HasMany(h => h.Rooms)
            .WithOne(r => r.Hotel)
            .HasForeignKey(r => r.HotelId);
        builder.Entity<Hotel>()
            .HasMany(h => h.Bookings)
            .WithOne(b => b.Hotel)
            .HasForeignKey(b => b.HotelId);
        builder.Entity<Booking>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();
        
        builder.Entity<Hotel>().HasData(
            new Hotel { Id = 1, Name = "Grand Budapest Hotel"},
            new Hotel { Id = 2, Name = "Hotel California" }
        );

        // Seed Rooms
        builder.Entity<Room>().HasData(
            new Room { Id = 1, HotelId = 1, RoomNumber = 101, Type = RoomType.Single, Capacity = 1},
            new Room { Id = 2, HotelId = 1, RoomNumber = 102, Type = RoomType.Single, Capacity = 2 },
            new Room { Id = 5, HotelId = 1, RoomNumber = 103, Type = RoomType.Double, Capacity = 2 },
            new Room { Id = 6, HotelId = 1, RoomNumber = 104, Type = RoomType.Double, Capacity = 2 },
            new Room { Id = 7, HotelId = 1, RoomNumber = 105, Type = RoomType.Double, Capacity = 2 },
            new Room { Id = 8, HotelId = 1, RoomNumber = 106, Type = RoomType.Double, Capacity = 2 }, 
            new Room { Id = 9, HotelId = 1, RoomNumber = 107, Type = RoomType.Double, Capacity = 2 }, 
            new Room { Id = 3, HotelId = 2, RoomNumber = 201, Type = RoomType.Deluxe, Capacity = 3 },
            new Room { Id = 4, HotelId = 2, RoomNumber = 202, Type = RoomType.Double, Capacity = 2}
        );

        // Seed Bookings
        builder.Entity<Booking>().HasData(
            new Booking { Id = 1, Guests = 1, HotelId = 1, BookingNumber = new Guid("b050c476-91b8-425b-a3db-8c2d3a511c4e"),Name = "Norman Bates", RoomId = 1, StartDate = DateOnly.FromDateTime(DateTime.Now.AddDays(1).ToUniversalTime()), EndDate = DateOnly.FromDateTime(DateTime.Now.AddDays(5).ToUniversalTime()), CreatedAt = new DateTime(2025, 01, 27, 4, 20,30).ToUniversalTime()},
            new Booking { Id = 2, Guests = 1, HotelId = 1, BookingNumber = new Guid("5fce189e-27d4-4959-b2d5-9efb246d0c34"), Name = "Basil Fawlty", RoomId = 2, StartDate = DateOnly.FromDateTime(DateTime.Now.AddDays(3).ToUniversalTime()), EndDate = DateOnly.FromDateTime(DateTime.Now.AddDays(6).ToUniversalTime()), CreatedAt = new DateTime(2025, 01, 27, 4, 20,30).ToUniversalTime()},
            new Booking { Id = 3, Guests = 1, HotelId = 2, BookingNumber = new Guid("9ec86f60-460e-45ba-ac19-7570e65864f2"), Name = "M Gustave", RoomId = 1, StartDate = DateOnly.FromDateTime(DateTime.Now.AddDays(3).ToUniversalTime()), EndDate = DateOnly.FromDateTime(DateTime.Now.AddDays(7).ToUniversalTime()), CreatedAt = new DateTime(2025, 01, 27, 4, 20,30).ToUniversalTime()},
            new Booking { Id = 4, Guests = 1, HotelId = 2, BookingNumber = new Guid("4a0dd36d-18db-4826-9b9d-9cd311475f0f"), Name = "Norma Bates", RoomId = 2, StartDate = DateOnly.FromDateTime(DateTime.Now.AddDays(1).ToUniversalTime()), EndDate = DateOnly.FromDateTime(DateTime.Now.AddDays(4).ToUniversalTime()), CreatedAt = new DateTime(2025, 01, 27, 4, 20,30).ToUniversalTime()}
        );
    }
}