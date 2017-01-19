using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactMySQL.Models
{
    public class ShafukuUser
    {
        public int Id { get; set; }

        [Display(Name = "ユーザー名")]
        [StringLength(20)]
        public string Name { get; set; }

        [Display(Name = "ユーザーカナ名")]
        [StringLength(20)]
        public string Kana { get; set; }

        [Display(Name = "ユーザー略称")]
        [StringLength(10)]
        public string ShortName { get; set; }

        [Display(Name = "法人コード")]
        public int HojinId { get; set; }

        [ForeignKey("HojinId")]
        public Hojin Hojin { get; set; }

        [Display(Name = "地域コード")]
        public int ChiikiId { get; set; }

        [ForeignKey("ChiikiId")]
        public Chiiki Chiiki { get; set; }

        [Display(Name = "〒")]
        [DataType(DataType.PostalCode)]
        public string Yubinbango { get; set; }

        [Display(Name = "住所１")]
        [StringLength(40)]
        public string Jyusho1 { get; set; }

        [Display(Name = "住所２")]
        [StringLength(40)]
        public string Jyusho2 { get; set; }

        [Display(Name = "電話番号")]
        [DataType(DataType.PhoneNumber)]
        public string Tel { get; set; }

        [Display(Name = "FAX番号")]
        [DataType(DataType.PhoneNumber)]
        public string Fax { get; set; }

        [Display(Name = "代表者名")]
        [StringLength(20)]
        public string DaihyoshaName { get; set; }

        [Display(Name = "導入日")]
        [DisplayFormat(DataFormatString = "{0:yyyy年MM月dd日}")]
        [DataType(DataType.Date)]
        public DateTime Donyubi { get; set; }

        [Display(Name = "オンライン")]
        public Boolean Online { get; set; }

        [Display(Name = "備考")]
        [DataType(DataType.MultilineText)]
        public string Biko { get; set; }

        [Display(Name = "担当者")]
        public int TantoshaId { get; set; }

        [ForeignKey("TantoshaId")]
        public Tantosha Tantosha { get; set; }
    }
}