using System.ComponentModel.DataAnnotations;
using System.Data;
using Website.Interfaces.LoadXLSX;

namespace Website.Models.WebSiteBD
{
    /*Модель предназначена для вывода новостей за месяц из базы WebSiteBD*/
    public class NewsTable : IDataForNewsTable
    {
        public int Id { get; set; }
        public string DateTime { get; set; } // Дата новостей
        public string Name { get; set; } // Название новости
        public string Executor { get; set; } // Исполнитель

        public NewsTable()
        {
        }
        public NewsTable(string _a, string _b, string _c)
        {
            DateTime = _a;
            Name = _b;
            Executor = _c;
        }

        public NewsTable(DataRow item)
        {
            DateTime = item["MyFieldA"].ToString();
            Name = item["MyFieldB"].ToString();
            Executor = item["MyFieldC"].ToString();
        }
    }
}
