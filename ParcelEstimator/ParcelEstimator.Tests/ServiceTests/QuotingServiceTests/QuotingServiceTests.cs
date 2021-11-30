﻿using NUnit.Framework;
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
            Parcel newParcel = new Parcel()
            {
                Length = 9,
                Width = 9,
                Height = 9
            };

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
            Parcel newParcel = new Parcel()
            {
                Length = 9,
                Width = 9,
                Height = 10
            };

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
            Parcel newParcel = new Parcel()
            {
                Length = 50,
                Width = 49,
                Height = 49
            };

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
            Parcel newParcel = new Parcel()
            {
                Length = 101,
                Width = 100,
                Height = 100
            };

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
                {
                    Length = 9,
                    Width = 9,
                    Height = 9
                },
                new Parcel
                {
                    Length = 1,
                    Width = 1,
                    Height = 1
                }
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
                {
                    Length = 10,
                    Width = 9,
                    Height = 9
                },
                new Parcel
                {
                    Length = 49,
                    Width = 49,
                    Height = 49
                }
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
                {
                    Length = 49,
                    Width = 50,
                    Height = 49
                },
                new Parcel
                {
                    Length = 99,
                    Width = 99,
                    Height = 99
                }
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
                {
                    Length = 100,
                    Width = 99,
                    Height = 99
                },
                new Parcel
                {
                    Length = 500,
                    Width = 400,
                    Height = 500
                }
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
        public void TestGetQuote_WithSpeedyShipping()
        {
            // Arrange
            var newParcels = new List<Parcel>
            {
                new Parcel
                {
                    Length = 100,
                    Width = 99,
                    Height = 99
                },
                new Parcel
                {
                    Length = 500,
                    Width = 400,
                    Height = 500
                }
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
