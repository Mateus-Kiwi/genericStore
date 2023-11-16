using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
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