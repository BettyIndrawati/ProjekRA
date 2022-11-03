using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAS.Bootcamp.RumahAqiqah.Data.Entities
{
    public class Article : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        [DataType(DataType.Html)]
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }
        public string FileName { get; set; }
        public string UrlImage { get; set; }
    }
}
