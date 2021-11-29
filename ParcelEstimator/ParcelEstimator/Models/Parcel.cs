using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcelEstimator.Models
{
    public class Parcel
    {
        /// <summary>
        /// Length of the parcel in cm.
        /// </summary>
        public double Length { get; set; }

        /// <summary>
        /// Width of the parcel in cm.
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// Height of the parcel in cm.
        /// </summary>
        public double Height { get; set; }
    }
}


/*
 Small parcel: all dimensions < 10cm. Cost $3
○ Medium parcel: all dimensions < 50cm. Cost $8
○ Large parcel: all dimensions < 100cm. Cost $15
○ XL parcel: any dimension >= 100cm. Cost $25
*/