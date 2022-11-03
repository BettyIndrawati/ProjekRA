using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAS.Bootcamp.RumahAqiqah.Data.Entities
{
    public class OrderDelivery
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey(nameof(Order))]
        public int OrderId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Area { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int EstimateHour { get; set; }

        public virtual Order Order { get; set; }
    }
}
