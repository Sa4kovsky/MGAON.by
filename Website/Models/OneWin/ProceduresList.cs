using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Models.OneWin
{
    //Класс для вывода названия: перечней, глав, процедур  в справочную систему (Controller - HelpInformation; View - Index) 
    public class ProceduresList
    {
        //   public int Id { get; set; }
        private string _name;
        private string _docRegistryNumber;

        /// <summary>
        /// id перечня
         /// </summary>
        public int IdNameList { get; set; }
        /// <summary>
        ///Название перечня для главы. Пример:"ПЕРЕЧЕНЬ административных процедур, по которым прием заявлений заинтересованных лиц об осуществлении административных процедур и выдача административных решений осуществляется службой "одно окно" в соответствии с постановлением Совета Министров Республики Беларусь от 17 февраля 2012 № 156 "Об утверждении единого перечня административных процедурах, осуществляемых государственными органами и иными организациями в отношении юридических лиц и индивидуальных предпринимателей, внесении дополнения в постановление Совета Министров Республики Беларусь от 14 февраля 2009 г. №193 и признании утратившими силу некоторых постановлений Совета Министров Республики Беларусь"
        /// </summary>
        public string NameList { get { return _name; } set { _name = value.ToUpper(); } } 
        /// <summary>
        /// Номер главы
        /// </summary>
        public int HeadsNumber { get; set; }
        /// <summary>
        /// Название главы
        /// </summary>
        public string HeadsName { get; set; }
        /// <summary>
        /// Номер процедуры
        /// </summary>
        public string DocRegistryNumber 
        {
            get 
            {
                if (IdNameList != 3 && IdNameList != 4)
                {
                    return _docRegistryNumber;
                }
                else 
                {
                    return null;  
                }
            }
            set 
            {
                { _docRegistryNumber = value; }
            }
        }
        /// <summary>
        /// Название раздела
        /// </summary>
        public string SectionsName { get; set; }
        /// <summary>
        /// Название процедуры
        /// </summary>
        public string DocRegistryRegName { get; set; }
        /// <summary>
        /// Id процедуры
        /// </summary>
        [Key]
        public Guid DocRegistryRegId { get; set; }
    }
}
