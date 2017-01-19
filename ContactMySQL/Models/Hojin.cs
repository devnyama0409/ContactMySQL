using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactMySQL.Models
{
    public class Hojin
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "法人コード")]
        public int Id { get; set; }

        [Display(Name = "法人名")]
        [StringLength(20)]
        public string Name { get; set; }

        [Display(Name = "代表者名")]
        [StringLength(20)]
        public string DaihyoshaName { get; set; }
    }
}