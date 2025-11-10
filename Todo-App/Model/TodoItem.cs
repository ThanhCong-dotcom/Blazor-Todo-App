using System.ComponentModel.DataAnnotations;

public class TodoItem : IValidatableObject
{
    public Guid Id { get; set; } = Guid.Empty;

    [Required(ErrorMessage = "Tên task không được để trống")]
    [StringLength(100, ErrorMessage = "Tên task không được vượt quá 100 ký tự")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Deadline không được để trống")]
    [DataType(DataType.Date)]
    public DateTime Deadline { get; set; } = DateTime.Today;

    public bool IsCompleted { get; set; } = false;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (Deadline < DateTime.Today)
            yield return new ValidationResult("Deadline phải từ hôm nay trở đi", new[] { nameof(Deadline) });
    }
}