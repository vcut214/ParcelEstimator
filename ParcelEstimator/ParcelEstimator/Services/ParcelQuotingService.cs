using ParcelEstimator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcelEstimator.Services
{
    public static class ParcelQuotingService
    {
        /// <summary>
        /// Method to retrieve a sequence of LineItems with a cost and description given a list of Parcels.
        /// </summary>
        /// <param name="parcels"></param>
        /// <returns>A sequence of LineItems</returns>
        public static IEnumerable<LineItem> GetQuoteForParcels(IEnumerable<Parcel> parcels)
        {
            return parcels.Select(x => CreateLineItemFromParcel(x));
        }


        /// <summary>
        /// Helper method to create a LineItem from a Parcel.
        /// </summary>
        /// <param name="parcel"></param>
        /// <returns>A LineItem generated from the Parcel</returns>
        internal static LineItem CreateLineItemFromParcel(Parcel parcel)
        {
            double largestDimension = Math.Max(parcel.Length, Math.Max(parcel.Width, parcel.Height));

            if (largestDimension < 10)
                return new LineItem(3.00, "Small Parcel");
            else if (largestDimension < 50)
                return new LineItem(8.00, "Medium Parcel");
            else if (largestDimension < 100)
                return new LineItem(15.00, "Large Parcel");

            return new LineItem(25.00, "XL Parcel");
        }
    }
}
