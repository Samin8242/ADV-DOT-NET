using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hunger1.EF.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
       
       
        public virtual ICollection<CollectRequest> CollectRequests { get; set; }

        public Employee() {
        CollectRequests= new List<CollectRequest>();
        
        }   


    }
}