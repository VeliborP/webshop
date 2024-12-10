using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ubique.Models
{
	public class Category
	{
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "The \"Category Name\" field is required.")]
		[MaxLength(30, ErrorMessage = "The \"Category Name\" field must be a maximum of 30 characters.")]
		[DisplayName("Category Name")]
		public string Name { get; set; }
	}
}
