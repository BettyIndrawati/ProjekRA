using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace RAS.Bootcamp.RumahAqiqah.Data.Entities
{
    public class Product : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [NotMapped]
        public string? Code {get; set;}
        [ForeignKey(nameof(ProductCategory))]
        public int ProductCategoryId { get; set; }
        public string Title { get; set; } = null!;
        public string FileName { get; set; }
        public string Url { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public ServiceType ServiceType { get; set; }
        [NotMapped]
        public IFormFile? ImageFile{get; set;}
        public virtual ProductCategory ProductCategory { get; set; }
    }
}
