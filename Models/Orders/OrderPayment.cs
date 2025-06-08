using BuyWise.Models.StaticEntities;

namespace BuyWise.Models.Orders
{
    public class OrderPayment
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public Order? Order { get; set; }
        public long PaymentMethodId { get; set; }
        public PaymentMehod? PaymentMethod { get; set; }
    }
}
