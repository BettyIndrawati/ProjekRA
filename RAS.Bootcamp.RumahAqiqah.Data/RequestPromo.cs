using Microsoft.AspNetCore.Http;

namespace RAS.Bootcamp.RumahAqiqah.Data;

public class RequestPromo{

        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Quota { get; set; }
        public int tipe { get; set; }
        public int Value { get; set; }
        public double PercentageValue { get; set; }
        public IFormFile? Banner {get;set;}
        public string url{get;set;} 
}