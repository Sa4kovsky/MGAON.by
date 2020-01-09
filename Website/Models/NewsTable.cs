using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Models
{
    public class NewsTable
    {
        public int Id { get; set; }
        public string DateTime { get; set; } // Дата новостей
        public string Name { get; set; } // Название новости
        public string Executor { get; set; } // Исполнитель
    }
}
