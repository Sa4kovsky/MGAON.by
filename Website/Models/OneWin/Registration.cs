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
        public string GettingDate
        {
            get
            {
                if (_gettingDate != "")
                {
                    _gettingDate = Convert.ToDateTime(_gettingDate).ToLongDateString();
                }
                return _gettingDate;
            }
            set { _gettingDate = value; }
        }
        public string MustBeReady
        {
            get
            {
                if (_mustBeReady != "")
                {
                    _mustBeReady = Convert.ToDateTime(_mustBeReady).ToLongDateString();
                }
                return _mustBeReady;
            }
            set { _mustBeReady = value; }
        }
        public int State { get; set; }
        public string DateOfSolution
        {
            get
            {
                if (_dateOfSolution != "")
                {
                    _dateOfSolution = Convert.ToDateTime(_dateOfSolution).ToLongDateString();
                }
                return _dateOfSolution;
            }
            set { _dateOfSolution = value; }
        }
        public string Solution { get; set; }
        public string SolutionNamber { get; set; }
        public string ReturnInDeptDate
        {
            get
            {
                if (_returnInDeptDate != "")
                {
                    _returnInDeptDate = Convert.ToDateTime(_returnInDeptDate).ToLongDateString();
                }
                return _returnInDeptDate;
            }
            set { _returnInDeptDate = value; }
        }

    }
}
