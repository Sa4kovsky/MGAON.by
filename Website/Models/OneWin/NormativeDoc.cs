using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Models.OneWin
{
    //вывод нормативных документов прекрепленных к процедуре
    public class NormativeDoc
    {   
        [Key]
        public string Name { get; set; }
        public string URL { get; set; }
    }
}
