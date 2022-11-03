namespace RAS.Bootcamp.RumahAqiqah.Data.Entities
{
    public class BaseEntity
    {
        /// <summary>
        /// For saving who actor created row
        /// </summary>
        public int CreatedBy { get; set; }
        /// <summary>s
        /// for saving who updated row
        /// </summary>
        public int UpdatedBy { get; set; }
        public DateTime CreatedDt { get; set; }
        public DateTime UpdatedDt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
