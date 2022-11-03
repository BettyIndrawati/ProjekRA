using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAS.Bootcamp.RumahAqiqah.Application.Repository.ViewModels
{
    internal class CatagoryVM
    {
        public Catagory Catagory { get; set; } = new Catagory();
        public IEnumerable<Catagory> catagories { get; set; } = new List<Catagory>();
    }
}
