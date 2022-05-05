using System;
namespace EcommerceAPI.Model
{
    public class Product
    {
        public int Id { get; set; }
        public int StoreId{ get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool ShowPrice { get; set; }
        public double Price { get; set; }
        public string FavNote { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public bool Active { get; set; }
        public string ImagePath { get; set; }

    }
}
