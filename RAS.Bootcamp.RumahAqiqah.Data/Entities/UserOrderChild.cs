using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAS.Bootcamp.RumahAqiqah.Data.Entities
{
    public class UserOrderChild : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey(nameof(Order))]
        public int OrderId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public DateTime DoB { get; set; }
        public string PlaceOfBirth { get; set; }
        public string FileName { get; set; }
        public string UrlImage { get; set; }
        public string Notes { get; set; }

        public virtual Order Order { get; set; }

    }
}
