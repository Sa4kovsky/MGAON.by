using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Models.OneWin
{
    public class Departaments
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } //Уполномоченный орган
    }
}
