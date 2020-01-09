using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Models
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; } // Название и текст новости
        public string Images { get; set; } // Картинка 
        public string Organization { get; set; }
        public string Position { get; set; }
        public string Name { get; set; } // Фио ответственого
        public DateTime DateStart { get; set; } // Дата начало проведения
        public DateTime DateFinish { get; set; } // Дата конца проведения
        public string Language { get; set; }
    }
}
