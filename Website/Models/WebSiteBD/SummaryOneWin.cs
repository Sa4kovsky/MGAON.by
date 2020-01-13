namespace Website.Models.WebSiteBD
{
    public class SummaryOneWin
    {
        /*Модель предназначена для вывода представления из базы WebSiteBD*/
        public int Id { get; set; }
        public double SummClients { get; set; } //Сумма клиентов со всех баз OneWinDB
        public double SummPhysicalPerson { get; set; } //Сумма ФизЛиц со всех баз OneWinDB
        public double SummLegalPerson { get; set; } //Сумма ЮрЛиц со всех баз OneWinDB
        public double SummAdmProcPhysicalPerson { get; set; } //Сумма АдмПроцедур ФизЛиц со всех баз OneWinDB
        public double SummAdmProcLegalPerson { get; set; } //Сумма АдмПроцедур ЮрЛиц со всех баз OneWinDB
    }
}
