using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShopWebsite.Models;

public partial class Category
{
    [Key]
    public int CategoryId { get; set; }

    [Required]
    [StringLength(20)]
    public string? Name { get; set; }

    [InverseProperty("Category")]
    public virtual ICollection<Animal> Animals { get; } = new List<Animal>();
}