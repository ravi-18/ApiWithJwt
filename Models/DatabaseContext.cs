using Microsoft.EntityFrameworkCore;

namespace ApiWithJwt.Models
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<OrderModel>? Orders { get; set; }
        public virtual DbSet<UserInfo>? UserInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("UserInfo");
                entity.Property(e => e.UserId).HasColumnName("UserId");
                entity.Property(e => e.DisplayName).HasMaxLength(60).IsUnicode(false);
                entity.Property(e => e.UserName).HasMaxLength(30).IsUnicode(false);
                entity.Property(e => e.Email).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.Password).HasMaxLength(20).IsUnicode(false);
                entity.Property(e => e.CreatedDate).IsUnicode(false);
            });

            modelBuilder.Entity<OrderModel>(entity =>
            {
                entity.Property(e => e.OrderId);
                entity.Property(e => e.OrderName).HasMaxLength(30).IsUnicode(false);
                entity.Property(e => e.OrderAmount).IsUnicode(false);
                entity.Property(e => e.OrderQuatity).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}