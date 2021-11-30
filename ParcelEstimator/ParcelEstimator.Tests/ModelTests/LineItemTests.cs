using NUnit.Framework;
using ParcelEstimator.Models;

namespace ParcelEstimator.Tests.ModelTests
{
    class LineItemTests
    {

        [Test]
        public void TestCreateLineItemDefaultConstructor()
        {
            // Arrange / Act
            LineItem newLineItem = new LineItem();

            // Assert
            Assert.AreEqual(0, newLineItem.Cost);
            Assert.AreEqual(null, newLineItem.Description);
        }

        [Test]
        public void TestCreateLineItemOverloadedConstructor()
        {
            // Arrange / Act
            LineItem newLineItem = new LineItem(500.50, "Random charge");

            // Assert
            Assert.AreEqual(500.50, newLineItem.Cost);
            Assert.AreEqual("Random charge", newLineItem.Description);
        }
    }
}
