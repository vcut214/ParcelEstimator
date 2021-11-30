using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcelEstimator.Models
{
    internal enum ParcelSize
    {
        Small,
        Medium,
        Large,
        XL
    }

    internal class ParcelType
    {
        internal ParcelSize Size { get; set; }
        internal double BaseCost { get; set; }
        internal double WeightLimit { get; set; }
    }
}
