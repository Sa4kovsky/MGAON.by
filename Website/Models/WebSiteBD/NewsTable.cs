namespace Website.Models.WebSiteBD
{
    /*Модель предназначена для вывода новостей за месяц из базы WebSiteBD*/
    public class NewsTable
    {
        public int Id { get; set; }
        public string DateTime { get; set; } // Дата новостей
        public string Name { get; set; } // Название новости
        public string Executor { get; set; } // Исполнитель
    }
}
