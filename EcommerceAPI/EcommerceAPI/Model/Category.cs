using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAPI.Model
{
    public class Category
    {
        public long Id { get; set; }
        public string StoreId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public long Active { get; set; }
    }
}
