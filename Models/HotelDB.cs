namespace Hotel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HotelDB : DbContext
    {
        public HotelDB()
            : base("name=HotelDB")
        {
        }

        public virtual DbSet<CLIENTS> CLIENTS { get; set; }
        public virtual DbSet<ROOMS> ROOMS { get; set; }
        public virtual DbSet<SERVICES> SERVICES { get; set; }
        public virtual DbSet<RESERVATION> RESERVATION { get; set; }
        public virtual DbSet<STATUSES> STATUSES { get; set; }
        public DbSet<RoomInfo> RoomInfo { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CLIENTS>()
                .Property(e => e.ID_CLIENT)
                .HasPrecision(38, 0);

            modelBuilder.Entity<CLIENTS>()
                .Property(e => e.FAM)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTS>()
                .Property(e => e.IM)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTS>()
                .Property(e => e.OT)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTS>()
                .Property(e => e.LOGIN)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTS>()
                .Property(e => e.PASSWORD)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTS>()
                .Property(e => e.DOC_TYPE)
                .HasPrecision(38, 0);

            modelBuilder.Entity<CLIENTS>()
                .Property(e => e.SERIAL_DOC)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTS>()
                .Property(e => e.SALE)
                .HasPrecision(38, 0);

            modelBuilder.Entity<CLIENTS>()
                .Property(e => e.BEGIN_PRICE)
                .HasPrecision(38, 0);

            modelBuilder.Entity<CLIENTS>()
                .Property(e => e.TOTAL_PRICE)
                .HasPrecision(38, 0);

            modelBuilder.Entity<CLIENTS>()
                .Property(e => e.NUMBER_DOC)
                .HasPrecision(38, 0);

            modelBuilder.Entity<CLIENTS>()
                .Property(e => e.ADMIN)
                .HasPrecision(38, 0);

            modelBuilder.Entity<CLIENTS>()
                .HasMany(e => e.STATUSES)
                .WithRequired(e => e.CLIENTS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CLIENTS>()
                .HasMany(e => e.RESERVATION)
                .WithRequired(e => e.CLIENTS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ROOMS>()
                .Property(e => e.ID_ROOM)
                .HasPrecision(38, 0);

            modelBuilder.Entity<ROOMS>()
                .Property(e => e.NUM_ROOM)
                .HasPrecision(38, 0);

            modelBuilder.Entity<ROOMS>()
                .Property(e => e.PLACES)
                .HasPrecision(38, 0);

            modelBuilder.Entity<ROOMS>()
                .Property(e => e.PRICE)
                .HasPrecision(38, 0);

            modelBuilder.Entity<ROOMS>()
                .HasMany(e => e.RESERVATION)
                .WithRequired(e => e.ROOMS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SERVICES>()
                .Property(e => e.ID_SERVICE)
                .HasPrecision(38, 0);

            modelBuilder.Entity<SERVICES>()
                .Property(e => e.PRICE_ONHOUR)
                .HasPrecision(38, 0);

            modelBuilder.Entity<SERVICES>()
                .HasMany(e => e.STATUSES)
                .WithRequired(e => e.SERVICES)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RESERVATION>()
                .Property(e => e.ID_ROOM)
                .HasPrecision(38, 0);

            modelBuilder.Entity<RESERVATION>()
                .Property(e => e.ID_CLIENT)
                .HasPrecision(38, 0);

            modelBuilder.Entity<STATUSES>()
                .Property(e => e.ID_CLIENT)
                .HasPrecision(38, 0);

            modelBuilder.Entity<STATUSES>()
                .Property(e => e.ID_SERVICE)
                .HasPrecision(38, 0);

            modelBuilder.Entity<STATUSES>()
                .Property(e => e.TIME_SERVICE)
                .HasPrecision(38, 0);
        }
    }
}
