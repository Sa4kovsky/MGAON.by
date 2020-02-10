using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Models.WebSiteBD
{
    public class Procedures
    {
        public int Id { get; set; }
        public int Chapter { get; set; }
        public string Title { get; set; }
        public string FIO { get; set; }
        public string Documents { get; set; }
        public string Cost { get; set; }
        public string MaximumTerm { get; set; }
        public string Term { get; set; }
    }
}
