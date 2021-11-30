using ParcelEstimator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcelEstimator.Services.QuotingService.OptionalExtras
{
    public interface IOptionalExtra
    {
        /// <summary>
        /// Applies this optional extra to a list of LineItems
        /// </summary>
        /// <returns>New sequence of LineItems including the optional extra</returns>
        public IEnumerable<LineItem> ApplyOptionalExtra(IEnumerable<LineItem> lineItems);
    }
}
