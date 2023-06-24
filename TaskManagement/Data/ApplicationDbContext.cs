using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Models;


namespace TaskManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data source=task.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure entity relationships
            modelBuilder.Entity<Models.Task>()
         .HasOne(t => t.AssignedUser)
         .WithMany(u => u.AssignedTask)
         .HasForeignKey(t => t.AssignedUserId);

            modelBuilder.Entity<Models.Task>()
                .HasMany(t => t.Comments)

                .WithOne(c => c.Task)
                .HasForeignKey(c => c.TaskId);

            // Configure entity properties
            modelBuilder.Entity<Models.Task>()
                .Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Models.Task>()
                .Property(t => t.Description)
                .HasMaxLength(500);

            // Configure other entity properties...

            base.OnModelCreating(modelBuilder);
        }
    }
   }
   

