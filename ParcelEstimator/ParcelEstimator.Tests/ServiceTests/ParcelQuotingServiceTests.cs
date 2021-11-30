using NUnit.Framework;
using ParcelEstimator.Models;
using ParcelEstimator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcelEstimator.Tests.ServiceTests
{
    public class ParcelQuotingServiceTests
    {
        [Test]
        public void TestCreateLineItemFromParcel_SmallParcel()
        {
            // Arrange
            Parcel newParcel = new Parcel()
            {
                Length = 9,
                Width = 9,
                Height = 9
            };

            // Act
            var resultLineItem = ParcelQuotingService.CreateLineItemFromParcel(newParcel);

            // Assert
            Assert.AreEqual(3.00, resultLineItem.Cost);
            Assert.AreEqual($"Small Parcel ({newParcel.Length}L x {newParcel.Width}W x {newParcel.Height}H)", resultLineItem.Description);
        }

        [Test]
        public void TestCreateLineItemFromParcel_MediumParcel()
        {
            // Arrange
            Parcel newParcel = new Parcel()
            {
                Length = 9,
                Width = 9,
                Height = 10
            };

            // Act
            var resultLineItem = ParcelQuotingService.CreateLineItemFromParcel(newParcel);

            // Assert
            Assert.AreEqual(8.00, resultLineItem.Cost);
            Assert.AreEqual($"Medium Parcel ({newParcel.Length}L x {newParcel.Width}W x {newParcel.Height}H)", resultLineItem.Description);
        }

        [Test]
        public void TestCreateLineItemFromParcel_LargeParcel()
        {
            // Arrange
            Parcel newParcel = new Parcel()
            {
                Length = 50,
                Width = 49,
                Height = 49
            };

            // Act
            var resultLineItem = ParcelQuotingService.CreateLineItemFromParcel(newParcel);

            // Assert
            Assert.AreEqual(15.00, resultLineItem.Cost);
            Assert.AreEqual($"Large Parcel ({newParcel.Length}L x {newParcel.Width}W x {newParcel.Height}H)", resultLineItem.Description);
        }

        [Test]
        public void TestCreateLineItemFromParcel_XLParcel()
        {
            // Arrange
            Parcel newParcel = new Parcel()
            {
                Length = 101,
                Width = 100,
                Height = 100
            };

            // Act
            var resultLineItem = ParcelQuotingService.CreateLineItemFromParcel(newParcel);

            // Assert
            Assert.AreEqual(25.00, resultLineItem.Cost);
            Assert.AreEqual($"XL Parcel ({newParcel.Length}L x {newParcel.Width}W x {newParcel.Height}H)", resultLineItem.Description);
        }
    }
}
