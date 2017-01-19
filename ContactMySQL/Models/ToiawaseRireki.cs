using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactMySQL.Models
{
    public class ToiawaseRireki
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "処理日")]
        [DisplayFormat(DataFormatString = "{0:yyyy年MM月dd日}")]
        [DataType(DataType.Date)]
        public DateTime? Shoribi { get; set; }

        [Display(Name = "担当者")]
        public int? TantoshaId { get; set; }

        [ForeignKey("TantoshaId")]
        public Tantosha Tantosha { get; set; }

        [Display(Name = "ユーザー")]
        public int? UserId { get; set; }

        [ForeignKey("UserId")]
        public ShafukuUser ShafukuUser { get; set; }

        [StringLength(20)]
        [Display(Name = "相手方担当")]
        public string UserTantoshaMei { get; set; }

        [Display(Name = "システム")]
        public int? SystemId { get; set; }

        [ForeignKey("SystemId")]
        public SystemMaster SystemMaster { get; set; }

        [Display(Name = "分類")]
        public int? BunruiId { get; set; }

        [ForeignKey("BunruiId")]
        public Bunrui Bunrui { get; set; }

        [Display(Name = "処理時間")]
        public int? ShoriJikan { get; set; }

        [Display(Name = "重要度")]
        public int? JyuyodoId { get; set; }

        [ForeignKey("JyuyodoId")]
        public Jyuyodo Jyuyodo { get; set; }

        [Display(Name = "問合せ・トラブル内容")]
        [DataType(DataType.MultilineText)]
        public string Naiyo { get; set; }

        [Display(Name = "対応")]
        [DataType(DataType.MultilineText)]
        public string Taio { get; set; }

        [Display(Name = "完了日")]
        [DataType(DataType.Date)]
        public DateTime? Kanryobi { get; set; }

        [StringLength(20)]
        [Display(Name = "受付者")]
        public string UketsukeshaMei { get; set; }

        [StringLength(20)]
        [Display(Name = "問合せ先")]
        public string Toiawasesaki { get; set; }
    }
}