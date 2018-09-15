using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ToDoList.Models
{
    public class ToDoMSsqlDBContext : IdentityDbContext<ApplicationUser>
    {
        public ToDoMSsqlDBContext()
            : base("ToDoMSsqlDBContext", throwIfV1Schema: false)
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<ToDoMSsqlDBContext>());
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ToDoMSsqlDBContext>());
        }

        public static ToDoMSsqlDBContext Create()
        {
            return new ToDoMSsqlDBContext();
        }

        public virtual DbSet<ToDo> ToDoList { get; set; }
    }
}