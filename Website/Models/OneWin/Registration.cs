using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Models.OneWin
{
    public class Registration
    {
        private protected string _gettingDate, _mustBeReady, _dateOfSolution, _returnInDeptDate;

        public int Id { get; set; }
        public string FName { get; set; }
        public string MName { get; set; }
        public string LName { get; set; }
        public string DocNo { get; set; }
        public DateTime GettingDate { get; set; }
     /*   {
            get
            {
                if (_gettingDate != "")
                {
                    _gettingDate = Convert.ToDateTime(_gettingDate).ToLongDateString();
                }
                return _gettingDate;
            }
            set { _gettingDate = value; }
        }*/
        public DateTime? MustBeReady { get; set; }
        public int State { get; set; }
        public DateTime? DateOfSolution { get; set; }
        public string Solution { get; set; }
        public string SolutionNamber { get; set; }
        public DateTime? ReturnInDeptDate { get; set; }

    }
}
