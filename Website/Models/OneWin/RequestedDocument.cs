using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Models.OneWin
{
    public class RequestedDocument
    {
        [Key]
        public string Name { get; set; }
    }
}
