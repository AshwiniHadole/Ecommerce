using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAPI.Model
{
    public class Category
    {
        public long Id { get; set; }
        [Required]
        public string StoreId { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 4)]
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        [Required]
        [StringLength(25, MinimumLength = 4)]
        public string CreatedBy { get; set; }
        public long Active { get; set; }
    }
}
