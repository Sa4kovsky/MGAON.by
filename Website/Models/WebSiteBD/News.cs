using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Models.WebSiteBD
{
    /*Модель предназначена для вывода текущих новостей из базы WebSiteBD*/
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
        public string DayWeek { get; set; } // для красивого вывода по дням. Надо переделать!!!! 
    }
}
