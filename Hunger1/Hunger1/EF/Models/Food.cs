using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hunger1.EF.Models
{
    public class Food
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        
        public int Quantity { get; set; }
        [ForeignKey("Restaurant")]

        public int RId { get; set; }

        public virtual Restaurant Restaurant { get; set; }
        public virtual ICollection<CollectRequest> CollectRequests { get; set; }

        public Food() { 
        CollectRequests= new List<CollectRequest>();

        }   

    }
}