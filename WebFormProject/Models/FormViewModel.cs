using System.ComponentModel.DataAnnotations;

namespace WebFormProject.Models;

public class FormViewModel
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid CreatedById { get; set; }
    public List<FieldViewModel> Fields { get; set; } = new List<FieldViewModel>();
}
