using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Models.Context
{
    public class ContextNews : DbContext
    {
        public DbSet<News> News { get; set; }
        public DbSet<NewsTable> NewsTable { get; set; }

        public ContextNews(DbContextOptions<ContextNews> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
