using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShopWebsite.Models;

public partial class Comment
{
    [Key]
    public int CommentId { get; set; }

    [Column("Comment")]
    [StringLength( 2-1000)]
    [Required(ErrorMessage = "Comment text is required")]
    public string? Comment1 { get; set; }

    public int AnimalId { get; set; }

    [ForeignKey("AnimalId")]
    [InverseProperty("Comments")]
    public virtual Animal? Animal { get; set; }
}