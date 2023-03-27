using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hunger1.EF.Models
{
    public class CollectRequest
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Food")]
        public int FId { get; set; }
        
        [ForeignKey("Employee")]
        public int EId { get; set; }

        [ForeignKey("Restaurant")]
        public int RId { get; set; }

        [Required]
        public DateTime CollectionDate { get; set; }
        public DateTime PreservationTime { get; set; }



      
        public virtual Food Food { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Restaurant Restaurant { get; set; }

    }
}