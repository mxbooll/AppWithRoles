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

            string emailGroup1 = "userGroup1@mail.ru";
            string passwordGroup1 = "123456";

            string emailGroup2 = "userGroup2@mail.ru";
            string passwordGroup2 = "456";

            Role group1Role = new Role { Id = 1, Name = group1RoleName };
            Role group2Role = new Role { Id = 2, Name = group2RoleName };
            User group1User = new User { Id = 1, Email = emailGroup1, Password = passwordGroup1, RoleId = group1Role.Id };
            User group2User = new User { Id = 2, Email = emailGroup2, Password = passwordGroup2, RoleId = group2Role.Id };

            modelBuilder.Entity<Role>().HasData(new Role[] { group1Role, group2Role });
            modelBuilder.Entity<User>().HasData(new User[] { group1User, group2User });
            base.OnModelCreating(modelBuilder);
        }
    }
}
