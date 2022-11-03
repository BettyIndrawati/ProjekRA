using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RAS.Bootcamp.RumahAqiqah.Data.Entities
{
    [Index(nameof(UserId), IsUnique = true)]
    public class UsedReferal : BaseEntity
    {
        public UsedReferal()
        {

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public string ReferalCode {get;set;}

        
    }
}