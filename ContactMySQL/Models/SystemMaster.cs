using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactMySQL.Models
{
    public class SystemMaster
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "システムコード")]
        public int Id { get; set; }

        [Display(Name = "システム名")]
        [StringLength(50)]
        public string Name { get; set; }

        [Display(Name = "システム略称")]
        [StringLength(20)]
        public string ShortName { get; set; }
    }
}