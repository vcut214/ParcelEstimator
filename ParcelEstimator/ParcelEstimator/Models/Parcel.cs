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

        /// <summary>
        /// Height of the parcel in kg.
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// Captures the type of the parcel, as well as any constraints on the parcel.
        /// </summary>
        internal ParcelType Type { get; set; }

        public Parcel(double length, double width, double height, double weight)
        {
            Length = length;
            Width = width;
            Height = height;
            Weight = weight;

            SetParcelType();
        }

        private void SetParcelType()
        {
            double largestDimension = Math.Max(Length, Math.Max(Width, Height));

            if (largestDimension < 10)
                Type = new ParcelType
                {
                    Size = ParcelSize.Small,
                    BaseCost = 3.00,
                    WeightLimit = 1.00
                };
            else if (largestDimension < 50)
                Type = new ParcelType
                {
                    Size = ParcelSize.Medium,
                    BaseCost = 8.00,
                    WeightLimit = 3.00
                };
            else if (largestDimension < 100)
                Type = new ParcelType
                {
                    Size = ParcelSize.Large,
                    BaseCost = 15.00,
                    WeightLimit = 6.00
                };
            else 
                Type = new ParcelType
                {
                    Size = ParcelSize.XL,
                    BaseCost = 25.00,
                    WeightLimit = 10.00
                };
        }

        internal double GetCost()
        {
            if (Weight > Type.WeightLimit)
            {
                double excessWeight = Weight - Type.WeightLimit;

                return Type.BaseCost + (excessWeight * 2);
            }

            return Type.BaseCost;
        }
    }
}