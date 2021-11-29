using NUnit.Framework;
using ParcelEstimator.Models;

namespace ParcelEstimator.Tests.ModelTests
{
    class LineItemTests
    {

        [Test]
        public void TestCreateLineItem()
        {
            // Arrange / Act
            LineItem newLineItem = new LineItem()
            {
                Cost = 500.50,
                Description = "Random charge"
            };

            // Assert
            Assert.AreEqual(500.50, newLineItem.Cost);
            Assert.AreEqual("Random charge", newLineItem.Description);
        }
    }
}
