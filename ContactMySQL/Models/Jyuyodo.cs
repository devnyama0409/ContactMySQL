using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactMySQL.Models
{
    public class Jyuyodo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "重要度コード")]
        public int Id { get; set; }

        [Display(Name = "重要度")]
        [StringLength(20)]
        public string Name { get; set; }
    }
}