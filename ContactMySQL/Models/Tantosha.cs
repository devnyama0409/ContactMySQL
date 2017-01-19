using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactMySQL.Models
{
    public class Tantosha
    {
        public int Id { get; set; }

        [Display(Name = "担当者名")]
        [StringLength(20)]
        public string Name { get; set; }

        [Display(Name = "担当者カナ名")]
        [StringLength(20)]
        public string Kana { get; set; }

        [Display(Name = "担当者略称")]
        [StringLength(10)]
        public string ShortName { get; set; }

        [Display(Name = "部署コード")]
        public int BushoId { get; set; }

        [ForeignKey("BushoId")]
        public Busho Busho { get; set; }
    }
}