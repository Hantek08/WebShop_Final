using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebShop_Final.Models
{
    public partial class WebshopContext : DbContext
    {
        public WebshopContext()
        {
        }

        public WebshopContext(DbContextOptions<WebshopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<PostalCode> PostalCodes { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Shipment> Shipments { get; set; }
        public virtual DbSet<SubCategory> SubCategories { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:sqlschoolproject.database.windows.net,1433;Initial Catalog=Webshop;Persist Security Info=False;User ID=hantek13;Password=Admin1308;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("categoryName");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BillDate)
                    .HasColumnType("datetime")
                    .HasColumnName("billDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasColumnName("orderDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PaymentId).HasColumnName("paymentId");

                entity.Property(e => e.ShipmentId).HasColumnName("shipmentId");

                entity.Property(e => e.ShippedDate)
                    .HasColumnType("date")
                    .HasColumnName("shippedDate");

                entity.Property(e => e.Tax).HasColumnName("tax");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.Property(e => e.UserId).HasColumnName("userId");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProductId })
                    .HasName("PK__OrderDet__BAD83E4BBF58EB87");

                entity.Property(e => e.OrderId).HasColumnName("orderId");

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetails.orderId");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetails.productId");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PaymentType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("paymentType");
            });

            modelBuilder.Entity<PostalCode>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("country");

                entity.Property(e => e.PostalCode1)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("postalCode");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Color)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("color");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("productName");

                entity.Property(e => e.Size)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("size");

                entity.Property(e => e.SubCategoryId).HasColumnName("subCategoryId");

                entity.Property(e => e.SupplierId).HasColumnName("supplierId");

                entity.Property(e => e.UnitInStock).HasColumnName("unitInStock");

                entity.Property(e => e.UnitPrice).HasColumnName("unitPrice");

                entity.HasOne(d => d.SubCategory)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SubCategoryId)
                    .HasConstraintName("FK_Products.subCategoryId");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK_Products.supplierId");
            });

            modelBuilder.Entity<Shipment>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("companyName");

                entity.Property(e => e.Freight).HasColumnName("freight");
            });

            modelBuilder.Entity<SubCategory>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryId).HasColumnName("categoryId");

                entity.Property(e => e.SubCategoryName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("subCategoryName");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.SubCategories)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_SubCategories.categoryId");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.PostalCodeId).HasColumnName("postalCodeId");

                entity.HasOne(d => d.PostalCode)
                    .WithMany(p => p.Suppliers)
                    .HasForeignKey(d => d.PostalCodeId)
                    .HasConstraintName("FK_Suppliers.postalCodeId");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Username, "UQ__Users__F3DBC572C13C1525")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Admin).HasColumnName("admin");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("firstName");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lastName");

                entity.Property(e => e.Password)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.PostalCodeId).HasColumnName("postalCodeId");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.HasOne(d => d.PostalCode)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.PostalCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users.postalCodeId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
