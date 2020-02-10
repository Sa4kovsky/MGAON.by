using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Website.Models.OneWin;
using Website.Models.WebSiteBD;

namespace Website.Models.Context
{
    public class ContextNews : DbContext
    {
        public DbSet<News> News { get; set; }
        public DbSet<NewsTable> NewsTable { get; set; }
        public DbSet<SummaryOneWin> ViewSummaryOneWin { get; set; }
        public DbSet<Registration> Registration { get; set; }
        public DbSet<Procedures> Procedures { get; set; }

        public ContextNews()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=sqlengine; Database=WebSite; Integrated Security=false; User Id=docker; Password=!px2280pe!");
        }
    }
}
