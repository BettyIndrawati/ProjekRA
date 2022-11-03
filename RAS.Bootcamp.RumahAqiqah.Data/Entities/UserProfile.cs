using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAS.Bootcamp.RumahAqiqah.Data.Entities
{
    public class UserProfile : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public string? PoB { get; set; }
        public DateTime? DoB { get; set; }
        public string? Address { get; set; }
        public string? IdentityNumber { get; set; }
        public string? RT { get; set; }
        public string? RW { get; set; }
        public string? District { get; set; }
        public string? City { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
