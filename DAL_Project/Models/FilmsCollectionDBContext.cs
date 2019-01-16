using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Configuration;

namespace DAL_Project.Models
{
    public partial class FilmsCollectionDBContext : DbContext
    {
        public FilmsCollectionDBContext()
        {
        }

        public FilmsCollectionDBContext(DbContextOptions<FilmsCollectionDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FavouriteFilm> FavouriteFilm { get; set; }
        public virtual DbSet<Filmmakers> Filmmakers { get; set; }
        public virtual DbSet<Films> Films { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<FavouriteFilm>(entity =>
            {
                entity.HasKey(e => e.FavoriteFilmId)
                    .HasName("PK__FAVOURIT__6BE1F296BFB68CD4");

                entity.ToTable("FAVOURITE_FILM");

                entity.HasIndex(e => e.FilmId)
                    .HasName("UQ__FAVOURIT__6D1D229D10686481")
                    .IsUnique();

                entity.Property(e => e.FavoriteFilmId).HasColumnName("favoriteFilmID");

                entity.Property(e => e.FilmId).HasColumnName("FilmID");

                entity.HasOne(d => d.Film)
                    .WithOne(p => p.FavouriteFilm)
                    .HasForeignKey<FavouriteFilm>(d => d.FilmId)
                    .HasConstraintName("FK__FAVOURITE___ID_F__403A8C7D");
            });

            modelBuilder.Entity<Filmmakers>(entity =>
            {
                entity.HasKey(e => e.FilmMakerId)
                    .HasName("PK__FILMMAKE__2A12643A2CF1C729");

                entity.ToTable("FILMMAKERS");

                entity.Property(e => e.FilmMakerId).HasColumnName("FilmMakerID");

                entity.Property(e => e.Awards)
                    .HasColumnName("AWARDS")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasColumnName("COUNTRY")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Dateofbirth)
                    .HasColumnName("DATEOFBIRTH")
                    .HasColumnType("date");

                entity.Property(e => e.Firstname)
                    .HasColumnName("FIRSTNAME")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Genre)
                    .HasColumnName("GENRE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .HasColumnName("LASTNAME")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Films>(entity =>
            {
                entity.HasKey(e => e.FilmId)
                    .HasName("PK__FILMS__62C9DB1C87A3CB23");

                entity.ToTable("FILMS");

                entity.Property(e => e.FilmId).HasColumnName("FilmID");

                entity.Property(e => e.Budget)
                    .HasColumnName("BUDGET")
                    .HasColumnType("money");

                entity.Property(e => e.Filmname)
                    .HasColumnName("FILMNAME")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Genre)
                    .HasColumnName("GENRE")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MakerId).HasColumnName("MakerID");

                entity.Property(e => e.Releasedate)
                    .HasColumnName("RELEASEDATE")
                    .HasColumnType("date");

                entity.HasOne(d => d.Maker)
                    .WithMany(p => p.Films)
                    .HasForeignKey(d => d.MakerId)
                    .HasConstraintName("FK__FILMS__ID_MAKER__3E52440B");
            });
        }
    }
}
