using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAS.Bootcamp.RumahAqiqah.Data.Entities
{
    public class Order : BaseEntity
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
            OrderDeliveries = new HashSet<OrderDelivery>();
            OrderHistories = new HashSet<OrderHistory>();
            Children = new HashSet<UserOrderChild>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime TransactionDate { get; set; }
        public int TotalAmount { get; set; }
        public string? PromoCode { get; set; }
        public int PromoValue { get; set; }
        public int PaymentValue { get; set; }
        public DateTime? PaymentDate { get; set; }
        public DateTime? PaymentVerificationDate { get; set; }
        public string SenderBank { get; set; }
        public string AccountBankNumber { get; set; }
        public string OrderStatus { get; set; } = null!;
        public string PaymentStatus { get; set; } = null!;
        public string TransferAccountNumber { get; set; } = null!;
        public string Bank { get; set; } = null!;

        public virtual ICollection<OrderDelivery> OrderDeliveries { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<OrderHistory> OrderHistories { get; set; }
        public virtual ICollection<UserOrderChild> Children { get; set; }
    }
}
