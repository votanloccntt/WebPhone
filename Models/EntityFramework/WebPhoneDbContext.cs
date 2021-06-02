using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Models.EntityFramework
{
    public partial class WebPhoneDbContext : DbContext
    {
        public WebPhoneDbContext()
            : base("name=WebPhoneDbContext")
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Deliverer> Deliverer { get; set; }
        public virtual DbSet<Footer> Footer { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<MenuType> MenuType { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Order_detail> Order_detail { get; set; }
        public virtual DbSet<Phones> Phones { get; set; }
        public virtual DbSet<Sale_phones> Sale_phones { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.Metta_title)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.Seo_title)
                .IsUnicode(false);

            modelBuilder.Entity<Comment>()
                .Property(e => e.Phone_number)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Customer_phone)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Customer_mail)
                .IsUnicode(false);

            modelBuilder.Entity<Deliverer>()
                .Property(e => e.Deliverer_phone)
                .IsUnicode(false);

            modelBuilder.Entity<Footer>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.Link)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.Target)
                .IsUnicode(false);

            modelBuilder.Entity<MenuType>()
                .HasMany(e => e.Menu)
                .WithOptional(e => e.MenuType)
                .HasForeignKey(e => e.TypeID);

            modelBuilder.Entity<Phones>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Phones>()
                .Property(e => e.Meta_title)
                .IsUnicode(false);

            modelBuilder.Entity<Phones>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<Phones>()
                .HasMany(e => e.Comment)
                .WithOptional(e => e.Phones)
                .HasForeignKey(e => e.Phone_id);

            modelBuilder.Entity<User>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);
        }
    }
}
