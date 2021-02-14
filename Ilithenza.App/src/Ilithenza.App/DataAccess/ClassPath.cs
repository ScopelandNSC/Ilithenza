using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ilithenza.App.DataAccess
{
    [Table("ClassPath")]
    public class ClassPath
    {
        [Column("PathId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int PathId { get; set; }

        [Column("Name")]
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Column("Description")]
        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        [ForeignKey("ClassId")]
        [Required]
        public int ClassId { get; set; }
    }
}
