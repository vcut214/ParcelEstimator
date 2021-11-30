using NUnit.Framework;
using ParcelEstimator.Models;
using ParcelEstimator.Services.QuotingService.OptionalExtras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcelEstimator.Tests.ServiceTests.QuotingServiceTests
{
    public class SpeedyShippingTests
    {

        [Test]
        public void TestApply()
        {
            // Arrange
            var lineItems = new List<LineItem>
            {
                new LineItem
                {
                    Cost = 8,
                    Description = "Medium Parcel"
                },
                new LineItem
                {
                    Cost = 8,
                    Description = "Medium Parcel"
                },
                new LineItem
                {
                    Cost = 15,
                    Description = "Large Parcel"
                }
            };

            var speedyShipping = new SpeedyShippingOptionalExtra();

            // Act
            var resultLineItems = speedyShipping.ApplyOptionalExtra(lineItems);

            // Assert
            Assert.AreEqual(4, resultLineItems.Count());
            Assert.AreEqual(31, resultLineItems.Last().Cost);
            Assert.AreEqual("Speedy Shipping", resultLineItems.Last().Description);
        }
    }
}
