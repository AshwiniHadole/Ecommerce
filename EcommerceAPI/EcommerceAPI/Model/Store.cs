using System;

namespace EcommerceAPI.Model
{
    public class Store
    { 
		public int StoreId { get; set; }
		public int UserId { get; set; }
		public string Name { get; set; }
		public string TagLine { get; set; }
		public string Theme { get; set; }
		public string BackGroundImage { get; set; }
		public bool SupportsMultipleLang { get; set; }
		public string StoreRoute { get; set; }
		public DateTime? CreatedOn { get; set; }
		public string CreatedBy { get; set; }
		public bool Active { get; set; }
	}
}
