using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Entity;

namespace Data
{
    public partial class huuzaapiContext : DbContext
    {
        public huuzaapiContext()
        {
        }

        public huuzaapiContext(DbContextOptions<huuzaapiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Assessment> Assessments { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Company> Companies { get; set; } = null!;
        public virtual DbSet<Departament> Departaments { get; set; } = null!;
        public virtual DbSet<Employeer> Employeers { get; set; } = null!;
        public virtual DbSet<Event> Events { get; set; } = null!;
        public virtual DbSet<EventsRoom> EventsRooms { get; set; } = null!;
        public virtual DbSet<ImagesEvent> ImagesEvents { get; set; } = null!;
        public virtual DbSet<InitialEvent> InitialEvents { get; set; } = null!;
        public virtual DbSet<Login> Logins { get; set; } = null!;
        public virtual DbSet<News> News { get; set; } = null!;
        public virtual DbSet<Permission> Permissions { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<Sale> Sales { get; set; } = null!;
        public virtual DbSet<Seat> Seats { get; set; } = null!;
        public virtual DbSet<Ticket> Tickets { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UsersType> UsersTypes { get; set; } = null!;
        public virtual DbSet<VideosEvent> VideosEvents { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=Lucas;Initial Catalog=huuzaapi;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assessment>(entity =>
            {
                entity.Property(e => e.Comment)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEventNavigation)
                    .WithMany(p => p.Assessments)
                    .HasForeignKey(d => d.IdEvent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Assessments_Events");

                entity.HasOne(d => d.IdLoginNavigation)
                    .WithMany(p => p.Assessments)
                    .HasForeignKey(d => d.IdLogin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Assessments_Login");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.Cnpj)
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("CNPJ");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Departament>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employeer>(entity =>
            {
                entity.HasOne(d => d.IdCompanyNavigation)
                    .WithMany(p => p.Employeers)
                    .HasForeignKey(d => d.IdCompany)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employeers_Companies");

                entity.HasOne(d => d.IdDepartamentNavigation)
                    .WithMany(p => p.Employeers)
                    .HasForeignKey(d => d.IdDepartament)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employeers_Departaments");

                entity.HasOne(d => d.IdLoginNavigation)
                    .WithMany(p => p.Employeers)
                    .HasForeignKey(d => d.IdLogin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employeers_Login");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ReleaseDate).HasColumnType("datetime");

                entity.Property(e => e.UrlPhoto)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCategoryNavigation)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.IdCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Events_Categories");
            });

            modelBuilder.Entity<EventsRoom>(entity =>
            {
                entity.Property(e => e.DatePresetion).HasColumnType("datetime");

                entity.HasOne(d => d.IdEventsNavigation)
                    .WithMany(p => p.EventsRooms)
                    .HasForeignKey(d => d.IdEvents)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MoviesRooms_Movies");

                entity.HasOne(d => d.IdRoomNavigation)
                    .WithMany(p => p.EventsRooms)
                    .HasForeignKey(d => d.IdRoom)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MoviesRooms_Rooms");
            });

            modelBuilder.Entity<ImagesEvent>(entity =>
            {
                entity.Property(e => e.Src)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEventNavigation)
                    .WithMany(p => p.ImagesEvents)
                    .HasForeignKey(d => d.IdEvent)
                    .HasConstraintName("FK_ImagesEvents_Events");
            });

            modelBuilder.Entity<InitialEvent>(entity =>
            {
                entity.Property(e => e.DateEnd).HasColumnType("datetime");

                entity.Property(e => e.DateStart).HasColumnType("datetime");

                entity.HasOne(d => d.IdEventNavigation)
                    .WithMany(p => p.InitialEvents)
                    .HasForeignKey(d => d.IdEvent)
                    .HasConstraintName("FK_InitialEvent_Events");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.ToTable("Login");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPermissionNavigation)
                    .WithMany(p => p.Logins)
                    .HasForeignKey(d => d.IdPermission)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Login_Permissions");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Logins)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Login_Users");
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.Property(e => e.DateModification).HasColumnType("datetime");

                entity.Property(e => e.DatePublication).HasColumnType("datetime");

                entity.Property(e => e.Text).IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEventNavigation)
                    .WithMany(p => p.News)
                    .HasForeignKey(d => d.IdEvent)
                    .HasConstraintName("FK_News_Events");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCompanyNavigation)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.IdCompany)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rooms_Companies");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.Property(e => e.Data).HasColumnType("datetime");

                entity.HasOne(d => d.IdLoginNavigation)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.IdLogin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sales_Users");
            });

            modelBuilder.Entity<Seat>(entity =>
            {
                entity.HasOne(d => d.IdRoomNavigation)
                    .WithMany(p => p.Seats)
                    .HasForeignKey(d => d.IdRoom)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Seats_Rooms");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.HasOne(d => d.IdMovieRoomNavigation)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.IdMovieRoom)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tickets_MoviesRooms");

                entity.HasOne(d => d.IdSaleNavigation)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.IdSale)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tickets_Sales");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Cpf)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("CPF");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUserTypeNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdUserType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_UsersTypes");
            });

            modelBuilder.Entity<UsersType>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(20)
                    .IsFixedLength();
            });

            modelBuilder.Entity<VideosEvent>(entity =>
            {
                entity.Property(e => e.Src)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEventNavigation)
                    .WithMany(p => p.VideosEvents)
                    .HasForeignKey(d => d.IdEvent)
                    .HasConstraintName("FK_VideosEvents_Events");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
