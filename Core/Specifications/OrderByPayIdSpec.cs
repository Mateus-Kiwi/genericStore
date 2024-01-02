using Core.Entitites.OrderAggregate;

namespace Core.Specifications
{
    public class OrderByPayIdSpec : BaseSpecs<Order>
    {
        public OrderByPayIdSpec(string paymentIntentId) 
            : base(o => o.PaymentIntetId == paymentIntentId)
        {
        }
    }
}