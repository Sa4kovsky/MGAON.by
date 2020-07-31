using Microsoft.EntityFrameworkCore;
using Website.Models.OneWin;
using Website.Models.WebSiteBD;

namespace Website.Models.Context
{
    public class Context : DbContext
    {
        public DbSet<News> News { get; set; }
        public DbSet<NewsTable> NewsTable { get; set; }
        public DbSet<SummaryOneWin> ViewSummaryOneWin { get; set; } //статистика, факты регистрации в одном окне
        public DbSet<Registration> Registration { get; set; }
        public DbSet<Procedures> Procedures { get; set; } //перечень адм. процедур выполняемых КУП «Минское городское агентство обслуживания населения» для граждан, состоящих (состоявших) в трудовых отношениях

        #region Для справочной системы 
        public DbSet<ProceduresList> ProceduresLists { get; set; } //Перечни,главы,процедуры
        public DbSet<Registry> Registry { get; set; } //цена и сроки процедуры
        public DbSet<NormativeDoc> NormativeDoc { get; set; } //нормативные документы
        public DbSet<Document> Document { get; set; } //документы гражданина
        public DbSet<RequestedDocument> RequestedDocuments { get; set; } //запрашиваемые документы
        public DbSet<Performers> Performers { get; set; } //уполномоченый орган, ответственные и исполнители за процедуру 
        public DbSet<Departaments> Departaments { get; set; } //уполномоченый орган
        public DbSet<PaymentAccaount> PaumentAccaounts { get; set; } //расчетные счета
        public DbSet<CommentDepartaments> CommentDepartaments { get; set; } //комментарии и признак куда выводить в уполномоченный орган, прием документов
        #endregion

        public Context()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=sqlengine; Database=WebSite; Integrated Security=false; User Id=docker; Password=!px2280pe!");
        }
    }
}
