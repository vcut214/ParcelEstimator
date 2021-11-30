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
        public static IEnumerable<LineItem> GetQuoteForParcels(IEnumerable<Parcel> parcels)
        {
            throw new NotImplementedException();
        }

        internal static LineItem CreateLineItemFromParcel(Parcel parcel)
        {
            double largestDimension = Math.Max(parcel.Length, Math.Max(parcel.Width, parcel.Height));

            if (largestDimension < 10)
                return new LineItem(3.00, $"Small Parcel ({parcel.Length}L x {parcel.Width}W x {parcel.Height}H)");
            else if (largestDimension < 50)
                return new LineItem(8.00, $"Medium Parcel ({parcel.Length}L x {parcel.Width}W x {parcel.Height}H)");
            else if (largestDimension < 100)
                return new LineItem(15.00, $"Large Parcel ({parcel.Length}L x {parcel.Width}W x {parcel.Height}H)");

            return new LineItem(25.00, $"XL Parcel ({parcel.Length}L x {parcel.Width}W x {parcel.Height}H)");
        }
    }
}
