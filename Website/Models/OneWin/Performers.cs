using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Models.OneWin
{
    public class Performers
    {
        public string Name { get; set; } //Уполномоченный орган
        public string Title { get; set; } //Должность
        [Key]
        public string FIO { get; set; } //ФИО должносного лица
        public bool CheckPerName { get; set; } //переменная для определения выводить ФИО или нет
        public string Address { get; set; } //адрес
        public bool CheckPerAddress { get; set; }  //переменная для определения выводить АДРЕС или нет
        public string Cabinet { get; set; } //кабинет
        public bool CheckPerCabinet { get; set; }  //переменная для определения выводить КАБИНЕТ или нет
        public string Phone { get; set; } //телефон
        public bool CheckPerPhone { get; set; }  //переменная для определения выводить ТЕЛЕФОН или нет
        public string Mail { get; set; } //почта
        public bool CheckPermail { get; set; }  //переменная для определения выводить ПоЧТУ или нет
        public string Notes { get; set; } //примечания
        public bool ChekPerNotes { get; set; }  //переменная для определения выводить ПРИМЕЧАНИЕ или нет 
    }
}
