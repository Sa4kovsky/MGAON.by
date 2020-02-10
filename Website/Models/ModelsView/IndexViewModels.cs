using System.Collections.Generic;
using Website.Models.UsersSendEmail;
using Website.Models.WebSiteBD;


namespace Website.Models.ModelsView
{
    public class IndexViewModels
    {
        public List<News> News { get; set; }
        public List<NewsTable> NewsTable { get; set; }
        public List<SummaryOneWin> SummaryOneWin { get; set; }
        public List<Procedures> Procedures { get; set; }

        public Person People { get; set; }
    }
}
