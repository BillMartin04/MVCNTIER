using Microsoft.EntityFrameworkCore;
using MVCWebNTier.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCWebNTier.Data.Context
{
    public class SchoolContext : DbContext
    {
        public DbSet<School> Schools { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            // optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=myNewDataBase;Persist Security Info=True;User ID=sa;Password=Password;TrustServerCertificate=True;");
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=MVCNTier;Trusted_Connection=True;MultipleActiveResultSets=true;");
            //      optionsBuilder.UseSqlServer(@"  Server = tcp:hellow.database.windows.net,1433; Initial Catalog = Hellow; Persist Security Info = False; User ID = sql_admin; Password =Password1; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");

        }
    }
}
