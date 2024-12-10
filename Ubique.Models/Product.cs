using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ubique.Models
{
	public class Product
	{
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "The \"Name\" field is required.")]
		public string Name { get; set; }

		[Required(ErrorMessage = "The \"Description\" field is required.")]
		public string Description { get; set; }

		[Required(ErrorMessage = "The \"Brand\" field is required.")]
		public string Brand { get; set; }

		[Display(Name = "Price List")]
		[Range(1, 2000)]
		public double ListPrice { get; set; }

		[Display(Name = "Price for 1-50")]
		[Range(1, 2000)]
		public double Price { get; set; }

		[Required(ErrorMessage = "The \"Sub Category\" field is required.")]
		[Display(Name = "Sub Category")]
		public int SubCategoryId { get; set; }

		[ForeignKey("SubCategoryId")]
		public SubCategory SubCategory { get; set; }

		[ValidateNever]
		public List<ProductImage> ProductImages { get; set; }

		public bool IsValid()
		{
			if (string.IsNullOrEmpty(Name)) return false;
			if (string.IsNullOrEmpty(Description)) return false;
			if (string.IsNullOrEmpty(Brand)) return false;
			if (SubCategoryId == null) return false;

			return true;
		}
	}
}
