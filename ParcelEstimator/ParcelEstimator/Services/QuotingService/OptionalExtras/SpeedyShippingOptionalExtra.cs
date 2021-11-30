using ParcelEstimator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcelEstimator.Services.QuotingService.OptionalExtras
{
    public class SpeedyShippingOptionalExtra : IOptionalExtra
    {
        public IEnumerable<LineItem> ApplyOptionalExtra(IEnumerable<LineItem> lineItems)
        {
            var speedyShippingItem = new LineItem(lineItems.Sum(x => x.Cost), "Speedy Shipping");

            return lineItems.Append(speedyShippingItem);
        }
    }
}
