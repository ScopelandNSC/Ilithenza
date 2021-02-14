using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ilithenza.App.DataAccess
{
    [Table("Class")]
    public class Class
    {
        [Column("ClassId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int ClassId { get; set; }

        [Column("Name")]
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Column("Description")]
        [Required]
        [StringLength(200)]
        public string Description { get; set; }
    }
}
