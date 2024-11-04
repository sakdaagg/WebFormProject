using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebFormProject.Entities.Shared;

namespace WebFromProject.Entities.Entities;

public class Form : BaseEntity<int>
{
    public string Name { get; set; }
    public string Description { get; set; }
    [DataType(DataType.Date)]
    public DateTime CreatedAt { get; set; }
    public Guid CreatedById { get; set; }
    public virtual AspNetUser CreatedBy { get; set; }
    public ICollection<Field> Fields { get; set; } 
}

public class Field : BaseEntity<int>
{
    public bool Required { get; set; }
    public string Name { get; set; }
    public string DataType { get; set; }
    public int FormId { get; set; }
    public virtual Form Form { get; set; }
}