using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAS.Bootcamp.RumahAqiqah.Data.Entities
{
    public enum PromoType
    {
        Percentage,
        ByFixValue
    }
    public class Promo : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Quota { get; set; }
        public PromoType PromoType { get; set; }
        public int Value { get; set; }
        public double PercentageValue { get; set; }
        public virtual ICollection<UsedPromo> UsedPromo { get; set; }
        public string Banner {get;set;}
        public string url {get;set;}
    }
}
