namespace Cinema.DataLayer.DBLayer
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CinemaContext : DbContext
    {
        public CinemaContext()
            : base("name=CinemaContext")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Film> Films { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Hall> Halls { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<SessionDate> SessionDates { get; set; }
        public virtual DbSet<Stat> Stats { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Film>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<Film>()
                .Property(e => e.about)
                .IsUnicode(false);

            modelBuilder.Entity<Film>()
                .Property(e => e.starring)
                .IsUnicode(false);

            modelBuilder.Entity<Film>()
                .Property(e => e.director)
                .IsUnicode(false);

            modelBuilder.Entity<Film>()
                .Property(e => e.trailer)
                .IsUnicode(false);

            modelBuilder.Entity<Film>()
                .HasMany(e => e.SessionDates)
                .WithRequired(e => e.Film)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Film>()
                .HasMany(e => e.Tickets)
                .WithRequired(e => e.Film)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Genre>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Hall>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Hall>()
                .HasMany(e => e.SessionDates)
                .WithRequired(e => e.Hall)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Hall>()
                .HasMany(e => e.Tickets)
                .WithRequired(e => e.Hall)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Photo>()
                .Property(e => e.pathPhoto)
                .IsUnicode(false);

            modelBuilder.Entity<SessionDate>()
                .HasMany(e => e.Tickets)
                .WithRequired(e => e.SessionDate)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Stat>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Stat>()
                .HasMany(e => e.Halls)
                .WithRequired(e => e.Stat)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ticket>()
                .Property(e => e.price)
                .HasPrecision(18, 0);
        }
    }
}
