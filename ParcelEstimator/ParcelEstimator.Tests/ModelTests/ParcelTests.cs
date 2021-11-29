using NUnit.Framework;
using ParcelEstimator.Models;

namespace ParcelEstimator.Tests.ModelTests
{
    class ParcelTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestCreateParcel()
        {
            // Arrange / Act
            Parcel newParcel = new Parcel()
            {
                Length = 50,
                Width = 30,
                Height = 40
            };

            // Assert
            Assert.AreEqual(50, newParcel.Length);
            Assert.AreEqual(30, newParcel.Width);
            Assert.AreEqual(40, newParcel.Height);
        }
    }
}
