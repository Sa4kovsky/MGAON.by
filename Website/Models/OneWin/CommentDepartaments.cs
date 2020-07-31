using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Models.OneWin
{
    public class CommentDepartaments
    {
        [Key]
        public int Id { get; set; }
        [Column("IdDep")]
        public Guid IdDepartament { get; set; }
        [Column("IdDoc")]
        public Guid IdProcedure { get; set; }
        [Column("Text")]
        public string Comment { get; set; }
        [Column("Email")]
        public string Link { get; set; }
    }
}
