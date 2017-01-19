using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactMySQL.Models
{
    public class Busho
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "部署コード")]
        public int Id { get; set; }

        [Display(Name = "部署名")]
        [StringLength(20)]
        public string Name { get; set; }

        public ICollection<Tantosha> Tantoshas { get; set; }
    }
}