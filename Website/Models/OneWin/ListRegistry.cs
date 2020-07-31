using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Models.OneWin
{
    public class ListRegistry
    {
        public List<Registry> Registries { get; set; }
        public List<NormativeDoc> NormativeDocs { get; set; }
        public List<Document> Documents { get; set; }
        public List<RequestedDocument> RequestedDocuments { get; set; }
        public List<Performers> Performers { get; set; }
        public List<Departaments> Departaments { get; set; }
        public List<Departaments> DepartamentsAccept { get; set; }
        public List<Performers> Executor { get; set; }   
        public List<PaymentAccaount> PaymentAccaount { get; set; }
        public List<CommentDepartaments> CommentDepartaments { get; set; }
        public List<Performers> DocumentAccept { get; set; }
    }
}
