
using System;
using System.ComponentModel.DataAnnotations;

namespace EcommerceAPI.Model
{
    public class Product
    {
        public int Id { get; set; }
        public int StoreId{ get; set; }
        public int CategoryId { get; set; }
        [Required]
        [StringLength(250, MinimumLength = 2)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public bool ShowPrice { get; set; }
        [Required]
        public double Price { get; set; }
        public string FavNote { get; set; }
        public DateTime? CreatedOn { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string CreatedBy { get; set; }
        public bool Active { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]

        public string ImagePath { get; set; }

    }
}
