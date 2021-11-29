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