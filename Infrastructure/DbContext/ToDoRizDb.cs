using Domain.Entities.Users;
using Domain.Entities.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    namespace Infrastructure.ToDoRiz;

    public class ToDoRizDb : DbContext
    {
        #region Ctor

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=POURIA\\SQLEXPRESS;Initial Catalog=ToDoRiz;Integrated Security=True;MultipleActiveResultSets=true;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }

        #endregion

        #region ToDoRiz Db Sets

        public DbSet<Tasks> Tasks { get; set; }

        public DbSet<Users> Users { get; set; }

        #endregion
    }


