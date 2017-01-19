using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactMySQL.Models
{
    public class Chiiki
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "地域コード")]
        public int Id { get; set; }

        [Display(Name = "地域名")]
        [StringLength(20)]
        public string Name { get; set; }
    }
}