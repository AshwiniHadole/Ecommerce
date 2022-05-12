using System;
using System.ComponentModel.DataAnnotations;

namespace EcommerceAPI.Model
{
	public class Store
	{
		public int StoreId { get; set; }
		public int UserId { get; set; }
		[Required]
		[StringLength(250, MinimumLength = 2)]
		public string Name { get; set; }
		[Required]
		public string TagLine { get; set; }
		public string Theme { get; set; }
		[Required]
		public string BackGroundImage { get; set; }
		public bool SupportsMultipleLang { get; set; }
		public string StoreRoute { get; set; }
		public DateTime? CreatedOn { get; set; }
		[Required]
		[StringLength(100, MinimumLength = 2)]
		public string CreatedBy { get; set; }
		public bool Active { get; set; }
	}
}