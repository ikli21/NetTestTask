using System;
using System.Data;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.EntityFrameworkCore;
using NetTestTask.Data.Entities;

namespace NetTestTask.DAL.DataBase
{
    public class NetTestTaskDatabase: DbContext
    {
        public NetTestTaskDatabase(DbContextOptions<NetTestTaskDatabase> options)
            : base(options)
        {
            if (Database.EnsureCreated())
            {
                List<User> users = new List<User>()
                {
                   new User
                   {
                       SurName = "Сергеев",
                       Name = "Сергей",
                       CreationDate = DateTime.Now,
                       LastChangeDate = DateTime.Now,
                       UserStatus = UserStatus.Active
                   },
                   new User
                   {
                       SurName = "Сергеев",
                       Name = "Матвей",
                       CreationDate = DateTime.Now,
                       LastChangeDate = DateTime.Now,
                       UserStatus = UserStatus.Blocked
                   },
                   new User
                   {
                       SurName = "Kozlovskiy",
                       Name = "Iogann",
                       CreationDate = DateTime.Now,
                       LastChangeDate = DateTime.Now,
                       UserStatus = UserStatus.Offline
                   },
                   new User
                   {
                       SurName = "Scari",
                       Name = "Judah",
                       CreationDate = DateTime.Now,
                       LastChangeDate = DateTime.Now,
                       UserStatus = UserStatus.Active
                   },
                   new User
                   {
                       SurName = "Кучер",
                       Name = "Максим",
                       CreationDate = DateTime.Now,
                       LastChangeDate = DateTime.Now,
                       UserStatus = UserStatus.Blocked
                   }
                };
                
                List<Task> tasks = new List<Task>();
                for(int i=0; i<24; i++)
                {
                    tasks.Add(new Task
                    {
                        TaskName = "TaskName" + i,
                        Description = "Description of Task #" + i,
                        CreationDate = DateTime.Now,
                        LastChangeDate = DateTime.Now
                    });
                }

                tasks.ForEach(t => Tasks.Add(t));

                users.ForEach(u => Users.Add(u));
                SaveChanges();
            }
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "host=ec2-176-34-222-188.eu-west-1.compute.amazonaws.com; port=5432; database=d24u48t1o00t74; user id=ygmynoozuwlaur; password=bacc74d82078cabb04b61a33e48e623b50ac30025034539cde100f349f2d1ac1; SSL Mode=Require;Trust Server Certificate=true;";
                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>().HasOne(t=>t.Manager).WithMany(u=>u.ManagerTasks).HasForeignKey(t=>t.ManagerId);
            modelBuilder.Entity<Task>().HasOne(t => t.Executor).WithMany(u => u.ExecutorTasks).HasForeignKey(t => t.ExecutorId);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
    }
}
