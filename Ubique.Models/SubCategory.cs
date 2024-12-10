using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ubique.Models
{
	public class SubCategory
	{
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "The \"Sub Category Name\" field is required.")]
		[MaxLength(30, ErrorMessage = "The \"Sub Category Name\" field must be a maximum of 30 characters.")]
		[DisplayName("Subcategory Name")]
		public string? Name { get; set; }

		[Required(ErrorMessage = "The \"Category\" field is mandatory.")]
		[DisplayName("Category")]
		public int CategoryId { get; set; }

		[ForeignKey("CategoryId")]
		[ValidateNever]
		public Category? Category { get; set; }
	}
}
