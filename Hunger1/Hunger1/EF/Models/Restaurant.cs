using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hunger1.EF.Models
{
    public class Restaurant
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        public virtual ICollection<Food> Foods { get; set; }
        public virtual ICollection<CollectRequest> CollectRequests { get; set; }

        public Restaurant() { 
        
            Foods = new List<Food>();
            CollectRequests = new List<CollectRequest>();
        }
    }
}