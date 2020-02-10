namespace Website.Models.WebSiteBD
{
    public class SummaryOneWin
    {
        /*Модель предназначена для вывода представления из базы WebSiteBD*/
        public int Id { get; set; }
        public int SummClients { get; set; } //Сумма клиентов со всех баз OneWinDB
        public int SummPhysicalPerson { get; set; } //Сумма ФизЛиц со всех баз OneWinDB
        public int SummLegalPerson { get; set; } //Сумма ЮрЛиц со всех баз OneWinDB
        public int SummAdm { get; set; } //Сумма решенных(строка solution не null) со всех баз OneWinDB
    }
}
