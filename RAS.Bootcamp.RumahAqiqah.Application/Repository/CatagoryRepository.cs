using RAS.Bootcamp.RumahAqiqah.Data;
namespace RAS.Bootcamp.RumahAqiqah.Application.Repository;
{
    public class CatagoryRepository :Repository<Catagory>, ICatagoryRepository
    {
        private ApplicationDbContext _context;
        public CatagoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context; 
        }

        public void Update(Catagory catagory)
        {
            var catagoryDB = _context.Catagories.FirstOrDefault(s => s.Id == catagory.Id);
            if (catagoryDB != null)
            {
                catagoryDB.Name = catagory.Name;    
                catagoryDB.Description = catagory.Description;
            
            }
        }
    }
}
