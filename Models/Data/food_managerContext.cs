using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace food_Manager.Models.Data
{
    public partial class food_managerContext : DbContext
    {
        public food_managerContext()
        {
        }

        public food_managerContext(DbContextOptions<food_managerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Food> Foods { get; set; } = null!;
        public virtual DbSet<History> Histories { get; set; } = null!;
        public virtual DbSet<Kind> Kinds { get; set; } = null!;
        public virtual DbSet<Pet> Pets { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=food_manager;persist security info=True;user id=sa2;password=Wing2009;MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Food>(entity =>
            {
                entity.ToTable("foods");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.AlertTime).HasColumnName("alert_time");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.EndGram).HasColumnName("end_gram");

                entity.Property(e => e.FeedTime).HasColumnName("feed_time");

                entity.Property(e => e.FirstGram).HasColumnName("first_gram");

                entity.Property(e => e.FoodName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("food_name");

                entity.Property(e => e.Petid).HasColumnName("petid");

                entity.Property(e => e.RemainGram).HasColumnName("remain_gram");

                entity.Property(e => e.SpecifyRemainGram).HasColumnName("specify_remain_gram");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.Userid).HasColumnName("userid");
            });

            modelBuilder.Entity<History>(entity =>
            {
                entity.ToTable("history");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.ChangeFood).HasColumnName("change_food");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Foodid).HasColumnName("foodid");

                entity.Property(e => e.Memo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("memo");

                entity.Property(e => e.Petid).HasColumnName("petid");
            });

            modelBuilder.Entity<Kind>(entity =>
            {
                entity.ToTable("kinds");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.KindsData)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("kinds_data");
            });

            modelBuilder.Entity<Pet>(entity =>
            {
                entity.ToTable("pets");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Kindsid).HasColumnName("kindsid");

                entity.Property(e => e.PetsAge)
                    .HasColumnType("date")
                    .HasColumnName("pets_age");

                entity.Property(e => e.PetsGender).HasColumnName("pets_gender");

                entity.Property(e => e.PetsName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("pets_name");

                entity.Property(e => e.PetsWeight).HasColumnName("pets_weight");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.Userid).HasColumnName("userid");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
