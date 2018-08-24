using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Week6CapstoneTaskList.Data.Maps;
using Week6CapstoneTaskList.Domain.Models;

namespace Week6CapstoneTaskList.Data
{
    public class Week6CapstoneTaskListContext : DbContext
    {
        public Week6CapstoneTaskListContext() : base("TaskList")
        {
            Database.SetInitializer(new Week6CapstoneTaskListInitializer());
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new TaskMap());

            base.OnModelCreating(modelBuilder);
        }

    }
}
