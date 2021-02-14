using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ilithenza.App.DataAccess
{
    [Table("ClassPathNode")]
    public class ClassPathNode
    {
        [Column("NodeId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int NodeId { get; set; }

        [Column("Name")]
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Column("Summary")]
        [Required]
        [StringLength(200)]
        public string Summary { get; set; }

        [Column("DetailedDescription")]
        [Required]
        [StringLength(400)]
        public string DetailedDescription { get; set; }

        [Column("Tier")]
        [Required]
        [StringLength(50)]
        public string Tier { get; set; }

        [Column("Type")]
        [Required]
        [StringLength(200)]
        public string Type { get; set; }

        [Column("Ap")]
        public int? Ap { get; set; }

        [Column("RecoveryTime")]
        public int? RecoveryTime { get; set; }

        [Column("DependsOnId")]
        public int? DependsOnId { get; set; }

        [Column("RelatedAttributeId")]
        public int? RelatedAttributeId { get; set; }

        [Column("Roll")]
        [Required]
        [StringLength(50)]
        public string Roll { get; set; }

        [ForeignKey("PathId")]
        [Required]
        public int PathId { get; set; }
    }
}
