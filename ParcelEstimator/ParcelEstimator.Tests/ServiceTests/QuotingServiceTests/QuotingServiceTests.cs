using NUnit.Framework;
using ParcelEstimator.Models;
using ParcelEstimator.Services.QuotingService;
using ParcelEstimator.Services.QuotingService.OptionalExtras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcelEstimator.Tests.ServiceTests.QuotingServiceTests
{
    public class QuotingServiceTests
    {
        [Test]
        public void TestCreateLineItemFromParcel_SmallParcel()
        {
            // Arrange
            Parcel newParcel = new Parcel
            (
                length: 9,
                width: 9,
                height: 9,
                weight: 1
            );

            // Act
            var resultLineItem = QuotingService.CreateLineItemFromParcel(newParcel);

            // Assert
            Assert.AreEqual(3.00, resultLineItem.Cost);
            Assert.AreEqual("Small Parcel", resultLineItem.Description);
        }

        [Test]
        public void TestCreateLineItemFromParcel_MediumParcel()
        {
            // Arrange
            Parcel newParcel = new Parcel
            (
                length: 9,
                width: 9,
                height: 10,
                weight: 3
            );

            // Act
            var resultLineItem = QuotingService.CreateLineItemFromParcel(newParcel);

            // Assert
            Assert.AreEqual(8.00, resultLineItem.Cost);
            Assert.AreEqual("Medium Parcel", resultLineItem.Description);
        }

        [Test]
        public void TestCreateLineItemFromParcel_LargeParcel()
        {
            // Arrange
            Parcel newParcel = new Parcel
            (
                length: 50,
                width: 49,
                height: 49,
                weight: 6
            );

            // Act
            var resultLineItem = QuotingService.CreateLineItemFromParcel(newParcel);

            // Assert
            Assert.AreEqual(15.00, resultLineItem.Cost);
            Assert.AreEqual("Large Parcel", resultLineItem.Description);
        }

        [Test]
        public void TestCreateLineItemFromParcel_XLParcel()
        {
            // Arrange
            Parcel newParcel = new Parcel
            (
                length: 101,
                width: 100,
                height: 100,
                weight: 10
            );

            // Act
            var resultLineItem = QuotingService.CreateLineItemFromParcel(newParcel);

            // Assert
            Assert.AreEqual(25.00, resultLineItem.Cost);
            Assert.AreEqual("XL Parcel", resultLineItem.Description);
        }

        [Test]
        public void TestGetQuoteForParcels_SmallParcels()
        {
            // Arrange
            var newParcels = new List<Parcel>
            {
                new Parcel
                (
                    length: 9,
                    width: 9,
                    height: 9,
                    weight: 1
                ),
                new Parcel
                (
                    length: 1,
                    width: 1,
                    height: 1,
                    weight: 1
                )
            };

            // Act
            var resultLineItems = QuotingService.GetQuote(newParcels);

            // Assert
            foreach (var resultLineItem in resultLineItems)
            {
                Assert.AreEqual(3, resultLineItem.Cost);
                Assert.AreEqual("Small Parcel", resultLineItem.Description);
            }
        }

        [Test]
        public void TestGetQuoteForParcels_MediumParcels()
        {
            // Arrange
            var newParcels = new List<Parcel>
            {
                new Parcel
                (
                    length: 10,
                    width: 9,
                    height: 9,
                    weight: 3
                ),
                new Parcel
                (
                    length: 49,
                    width: 49,
                    height: 49,
                    weight: 2
                )
            };

            // Act
            var resultLineItems = QuotingService.GetQuote(newParcels);

            // Assert
            foreach (var resultLineItem in resultLineItems)
            {
                Assert.AreEqual(8, resultLineItem.Cost);
                Assert.AreEqual("Medium Parcel", resultLineItem.Description);
            }
        }

        [Test]
        public void TestGetQuoteForParcels_LargeParcels()
        {
            // Arrange
            var newParcels = new List<Parcel>
            {
                new Parcel
                (
                    length: 49,
                    width: 50,
                    height: 49,
                    weight: 6
                ),
                new Parcel
                (
                    length: 99,
                    width: 99,
                    height: 99,
                    weight: 5
                )
            };

            // Act
            var resultLineItems = QuotingService.GetQuote(newParcels);

            // Assert
            foreach (var resultLineItem in resultLineItems)
            {
                Assert.AreEqual(15, resultLineItem.Cost);
                Assert.AreEqual("Large Parcel", resultLineItem.Description);
            }
        }

        [Test]
        public void TestGetQuoteForParcels_XLParcels()
        {
            // Arrange
            var newParcels = new List<Parcel>
            {
                new Parcel
                (
                    length: 100,
                    width: 99,
                    height: 99,
                    weight: 10
                ),
                new Parcel
                (
                    length: 500,
                    width: 400,
                    height: 500,
                    weight: 10
                )
            };

            // Act
            var resultLineItems = QuotingService.GetQuote(newParcels);

            // Assert
            foreach (var resultLineItem in resultLineItems)
            {
                Assert.AreEqual(25, resultLineItem.Cost);
                Assert.AreEqual("XL Parcel", resultLineItem.Description);
            }
        }

        [Test]
        public void TestGetQuoteForParcels_OverweightSmallParcel()
        {
            // Arrange
            var newParcels = new List<Parcel>
            {
                new Parcel
                (
                    length: 1,
                    width: 1,
                    height: 1,
                    weight: 11
                )
            };

            // Act
            var resultLineItems = QuotingService.GetQuote(newParcels);

            // Assert
            var resultLineItem = resultLineItems.FirstOrDefault();
            Assert.AreEqual(23, resultLineItem.Cost);
            Assert.AreEqual("Small Parcel", resultLineItem.Description);
        }

        [Test]
        public void TestGetQuoteForParcels_OverweightMediumParcel()
        {
            // Arrange
            var newParcels = new List<Parcel>
            {
                new Parcel
                (
                    length: 49,
                    width: 49,
                    height: 49,
                    weight: 13
                )
            };

            // Act
            var resultLineItems = QuotingService.GetQuote(newParcels);

            // Assert
            var resultLineItem = resultLineItems.FirstOrDefault();
            Assert.AreEqual(28, resultLineItem.Cost);
            Assert.AreEqual("Medium Parcel", resultLineItem.Description);
        }

        [Test]
        public void TestGetQuoteForParcels_OverweightLargeParcel()
        {
            // Arrange
            var newParcels = new List<Parcel>
            {
                new Parcel
                (
                    length: 99,
                    width: 99,
                    height: 99,
                    weight: 16
                )
            };

            // Act
            var resultLineItems = QuotingService.GetQuote(newParcels);

            // Assert
            var resultLineItem = resultLineItems.FirstOrDefault();
            Assert.AreEqual(35, resultLineItem.Cost);
            Assert.AreEqual("Large Parcel", resultLineItem.Description);
        }

        [Test]
        public void TestGetQuoteForParcels_OverweightXLParcel()
        {
            // Arrange
            var newParcels = new List<Parcel>
            {
                new Parcel
                (
                    length: 100,
                    width: 100,
                    height: 100,
                    weight: 20
                )
            };

            // Act
            var resultLineItems = QuotingService.GetQuote(newParcels);

            // Assert
            var resultLineItem = resultLineItems.FirstOrDefault();
            Assert.AreEqual(45, resultLineItem.Cost);
            Assert.AreEqual("XL Parcel", resultLineItem.Description);
        }

        [Test]
        public void TestGetQuote_WithSpeedyShipping()
        {
            // Arrange
            var newParcels = new List<Parcel>
            {
                new Parcel
                (
                    length: 100,
                    width: 99,
                    height: 99,
                    weight: 10
                ),
                new Parcel
                (
                    length: 500,
                    width: 400,
                    height: 500,
                    weight: 10
                )
            };

            var extras = new List<IOptionalExtra>
            {
                new SpeedyShippingOptionalExtra()
            };

            // Act
            var resultLineItems = QuotingService.GetQuoteWithOptions(newParcels, extras);

            // Assert
            Assert.AreEqual(50, resultLineItems.Last().Cost);
            Assert.AreEqual("Speedy Shipping", resultLineItems.Last().Description);
        }
    }
}
