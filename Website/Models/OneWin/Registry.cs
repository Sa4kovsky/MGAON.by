using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Models.OneWin
{
    //класс для вывода срока действия, срока выполнения, цена
    public class Registry
    {
        [Key]
        public string Cost { get; set; } //цена
        public string Inssue { get; set; } //срок выполнения
        public string Validaty { get; set; } //срок действия
        public string URL { get; set; } //ссылка на заявление
    }
}
