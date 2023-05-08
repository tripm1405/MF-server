using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MangaFigure.Models
{
    public partial class MangaFigureContext : DbContext
    {
        public MangaFigureContext()
        {
        }

        public MangaFigureContext(DbContextOptions<MangaFigureContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<Announcement> Announcements { get; set; } = null!;
        public virtual DbSet<Cart> Carts { get; set; } = null!;
        public virtual DbSet<Catalog> Catalogs { get; set; } = null!;
        public virtual DbSet<Contact> Contacts { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Footer> Footers { get; set; } = null!;
        public virtual DbSet<Header> Headers { get; set; } = null!;
        public virtual DbSet<Navbar> Navbars { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductImage> ProductImages { get; set; } = null!;
        public virtual DbSet<ProductReview> ProductReviews { get; set; } = null!;
        public virtual DbSet<SlideShow> SlideShows { get; set; } = null!;
        public virtual DbSet<Transaction> Transactions { get; set; } = null!;
        public virtual DbSet<TransactionDetail> TransactionDetails { get; set; } = null!;
        public virtual DbSet<TransactionStatus> TransactionStatuses { get; set; } = null!;
        public virtual DbSet<Voucher> Vouchers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=MangaFigure;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Password)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Announcement>(entity =>
            {
                entity.ToTable("Announcement");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Content)
                    .HasColumnType("text")
                    .HasColumnName("content");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("create_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Image)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("image");

                entity.Property(e => e.Meta)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("meta");

                entity.Property(e => e.Order).HasColumnName("order");

                entity.Property(e => e.Title)
                    .HasMaxLength(128)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("Cart");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("create_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Customer).HasColumnName("customer");

                entity.Property(e => e.Meta)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("meta");

                entity.Property(e => e.Order).HasColumnName("order");

                entity.Property(e => e.Product).HasColumnName("product");

                entity.HasOne(d => d.CustomerNavigation)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.Customer)
                    .HasConstraintName("Cart_customer");

                entity.HasOne(d => d.ProductNavigation)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.Product)
                    .HasConstraintName("Cart_product");
            });

            modelBuilder.Entity<Catalog>(entity =>
            {
                entity.ToTable("Catalog");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("create_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Meta)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("meta");

                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .HasColumnName("name");

                entity.Property(e => e.Order).HasColumnName("order");

                entity.Property(e => e.Type).HasColumnName("type");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("Contact");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("create_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Link)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("link");

                entity.Property(e => e.Meta)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("meta");

                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Order).HasColumnName("order");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Address)
                    .HasMaxLength(256)
                    .HasColumnName("address");

                entity.Property(e => e.Birthday)
                    .HasColumnType("datetime")
                    .HasColumnName("birthday");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("create_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Meta)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("meta");

                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .HasColumnName("name");

                entity.Property(e => e.Order).HasColumnName("order");

                entity.Property(e => e.Password)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.Username)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Address)
                    .HasMaxLength(256)
                    .HasColumnName("address");

                entity.Property(e => e.Birthday)
                    .HasColumnType("datetime")
                    .HasColumnName("birthday");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("create_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Meta)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("meta");

                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .HasColumnName("name");

                entity.Property(e => e.Order).HasColumnName("order");

                entity.Property(e => e.Password)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.Username)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Footer>(entity =>
            {
                entity.ToTable("Footer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("create_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.Logo)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("logo");

                entity.Property(e => e.Meta)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("meta");

                entity.Property(e => e.Order).HasColumnName("order");
            });

            modelBuilder.Entity<Header>(entity =>
            {
                entity.ToTable("Header");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("create_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.Logo)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("logo");

                entity.Property(e => e.Meta)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("meta");

                entity.Property(e => e.Order).HasColumnName("order");
            });

            modelBuilder.Entity<Navbar>(entity =>
            {
                entity.ToTable("Navbar");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("create_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Meta)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("meta");

                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Order).HasColumnName("order");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Catalog).HasColumnName("catalog");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("create_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.Discount).HasColumnName("discount");

                entity.Property(e => e.Image).HasColumnName("image");

                entity.Property(e => e.Meta)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("meta");

                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .HasColumnName("name");

                entity.Property(e => e.Order).HasColumnName("order");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.HasOne(d => d.CatalogNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Catalog)
                    .HasConstraintName("Product_catalog");

                entity.HasOne(d => d.ImageNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Image)
                    .HasConstraintName("Product_image");
            });

            modelBuilder.Entity<ProductImage>(entity =>
            {
                entity.ToTable("ProductImage");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("create_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Link)
                    .HasMaxLength(256)
                    .HasColumnName("link");

                entity.Property(e => e.Meta)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("meta");

                entity.Property(e => e.Order).HasColumnName("order");

                entity.Property(e => e.Product).HasColumnName("product");

                entity.HasOne(d => d.ProductNavigation)
                    .WithMany(p => p.ProductImages)
                    .HasForeignKey(d => d.Product)
                    .HasConstraintName("ProductImage_product");
            });

            modelBuilder.Entity<ProductReview>(entity =>
            {
                entity.ToTable("ProductReview");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Content)
                    .HasColumnType("text")
                    .HasColumnName("content");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("create_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Customer).HasColumnName("customer");

                entity.Property(e => e.Meta)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("meta");

                entity.Property(e => e.Order).HasColumnName("order");

                entity.Property(e => e.Product).HasColumnName("product");

                entity.Property(e => e.Rate).HasColumnName("rate");

                entity.HasOne(d => d.CustomerNavigation)
                    .WithMany(p => p.ProductReviews)
                    .HasForeignKey(d => d.Customer)
                    .HasConstraintName("ProductReview_customer");
            });

            modelBuilder.Entity<SlideShow>(entity =>
            {
                entity.ToTable("SlideShow");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("create_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Image)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("image");

                entity.Property(e => e.Meta)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("meta");

                entity.Property(e => e.Order).HasColumnName("order");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.ToTable("Transaction");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("create_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Customer).HasColumnName("customer");

                entity.Property(e => e.Employee).HasColumnName("employee");

                entity.Property(e => e.Meta)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("meta");

                entity.Property(e => e.Order).HasColumnName("order");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Rate).HasColumnName("rate");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.CustomerNavigation)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.Customer)
                    .HasConstraintName("Transaction_customer");

                entity.HasOne(d => d.EmployeeNavigation)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.Employee)
                    .HasConstraintName("Transaction_employee");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("Transaction_status");
            });

            modelBuilder.Entity<TransactionDetail>(entity =>
            {
                entity.ToTable("TransactionDetail");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("create_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Meta)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("meta");

                entity.Property(e => e.Order).HasColumnName("order");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Product).HasColumnName("product");

                entity.Property(e => e.Transaction).HasColumnName("transaction");

                entity.HasOne(d => d.ProductNavigation)
                    .WithMany(p => p.TransactionDetails)
                    .HasForeignKey(d => d.Product)
                    .HasConstraintName("TransactionDetail_product");

                entity.HasOne(d => d.TransactionNavigation)
                    .WithMany(p => p.TransactionDetails)
                    .HasForeignKey(d => d.Transaction)
                    .HasConstraintName("TransactionDetail_transaction");
            });

            modelBuilder.Entity<TransactionStatus>(entity =>
            {
                entity.ToTable("TransactionStatus");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Content)
                    .HasMaxLength(128)
                    .HasColumnName("content");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("create_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Meta)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("meta");

                entity.Property(e => e.Order).HasColumnName("order");
            });

            modelBuilder.Entity<Voucher>(entity =>
            {
                entity.ToTable("Voucher");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Condition)
                    .HasColumnType("text")
                    .HasColumnName("condition");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("create_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.Meta)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("meta");

                entity.Property(e => e.Money).HasColumnName("money");

                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .HasColumnName("name");

                entity.Property(e => e.Order).HasColumnName("order");

                entity.Property(e => e.Percent).HasColumnName("percent");

                entity.Property(e => e.Type).HasColumnName("type");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
