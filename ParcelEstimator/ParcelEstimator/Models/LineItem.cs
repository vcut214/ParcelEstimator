using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcelEstimator.Models
{
    public class LineItem
    {
        /// <summary>
        /// Cost of the line item in dollars.
        /// </summary>
        public double Cost { get; set; }

        /// <summary>
        /// Description of the line item.
        /// </summary>
        public string Description { get; set; }



        public LineItem(double Cost, string Description)
        {
            this.Cost = Cost;
            this.Description = Description;
        }

        public LineItem()
        {
            Cost = 0;
            Description = null;
        }

    }
}
