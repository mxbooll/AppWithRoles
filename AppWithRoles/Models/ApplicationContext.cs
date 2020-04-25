using Microsoft.EntityFrameworkCore;

namespace AppWithRoles.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        // Занесем некоторые данные в БД для теста
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string group1RoleName = "group1";
            string group2RoleName = "group2";

            string email = "user@mail.ru";
            string password = "123456";
                        
            Role group1Role = new Role { Id = 1, Name = group1RoleName };
            Role group2Role = new Role { Id = 2, Name = group2RoleName };
            User group1User = new User { Id = 1, Email = email, Password = password, RoleId = group1Role.Id };

            modelBuilder.Entity<Role>().HasData(new Role[] { group1Role, group2Role });
            modelBuilder.Entity<User>().HasData(new User[] { group1User });
            base.OnModelCreating(modelBuilder);
        }
    }
}
