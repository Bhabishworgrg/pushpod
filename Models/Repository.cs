using System.ComponentModel.DataAnnotations;

namespace pushpod.Models;

public class Repository
{
	public int Id { get; set; }

	[Required]
	public string Name { get; set; } = string.Empty;

	public string Description { get; set; } = string.Empty;

	[DataType(DataType.Date)]
	public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
