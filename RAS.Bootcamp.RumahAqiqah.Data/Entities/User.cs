using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RAS.Bootcamp.RumahAqiqah.Data.Entities
{
    [Index(nameof(Email),nameof(ReferalCode), IsUnique = true)]
    public class User : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey(nameof(Account))]
        public int AccountId { get; set; }
        public string Name { get; set; } = null!;
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? ReferalCode {get;set;}
        [ForeignKey(nameof(Role))]
        public int RoleId { get; set; }

        public virtual Role? Role { get; set; }
        public virtual Account? Account { get; set; }
        public virtual UserProfile? UserProfile { get; set; }
        public virtual ICollection<UsedPromo>? UsedPromos { get; set; }
        public virtual ICollection<UsedReferal>? UsedReferals { get; set; }
    }
}
