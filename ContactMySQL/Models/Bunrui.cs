using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactMySQL.Models
{
    public class Bunrui
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "分類コード")]
        public int Id { get; set; }

        [Display(Name = "分類名")]
        [StringLength(10)]
        public string Name { get; set; }
    }
}