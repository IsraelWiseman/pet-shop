using PetShopWebsite.Validators;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PetShopWebsite.Models;

public partial class Animal
{

    [Key]
    public int AnimalId { get; set; }

    [Required(ErrorMessage = "Please enter a name.")]
    [StringLength(20)]
    [AllLettersValidation(ErrorMessage = "Only letters allowed.")]

    public string? Name { get; set; }
   
    [Range(1, 250)]
    public int? Age { get; set; }
   
    public string? PictureName { get; set; }

    [DataType(DataType.MultilineText)]
    public string? Description { get; set; }
   
    public int CategoryId { get; set; }
   


    [ForeignKey("CategoryId")]
    [InverseProperty("Animals")]
    public virtual Category? Category { get; set; }

    [InverseProperty("Animal")]
    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

}
