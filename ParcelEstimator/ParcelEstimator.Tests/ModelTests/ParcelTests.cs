using NUnit.Framework;
using ParcelEstimator.Models;

namespace ParcelEstimator.Tests.ModelTests
{
    class ParcelTests
    {

        [Test]
        public void TestCreateParcel_SmallParcel()
        {
            // Arrange / Act
            Parcel newParcel = new Parcel(9, 9, 9, 1);

            // Assert
            Assert.AreEqual(9, newParcel.Length);
            Assert.AreEqual(9, newParcel.Width);
            Assert.AreEqual(9, newParcel.Height);
            Assert.AreEqual(1, newParcel.Weight);

            Assert.AreEqual(ParcelSize.Small, newParcel.Type.Size);
            Assert.AreEqual(3.00, newParcel.Type.BaseCost);
            Assert.AreEqual(1.00, newParcel.Type.WeightLimit);
        }

        [Test]
        public void TestCreateParcel_MediumParcel()
        {
            // Arrange / Act
            Parcel newParcel = new Parcel(10, 9, 9, 3);

            // Assert
            Assert.AreEqual(10, newParcel.Length);
            Assert.AreEqual(9, newParcel.Width);
            Assert.AreEqual(9, newParcel.Height);
            Assert.AreEqual(3, newParcel.Weight);

            Assert.AreEqual(ParcelSize.Medium, newParcel.Type.Size);
            Assert.AreEqual(8.00, newParcel.Type.BaseCost);
            Assert.AreEqual(3.00, newParcel.Type.WeightLimit);
        }

        [Test]
        public void TestCreateParcel_LargeParcel()
        {
            // Arrange / Act
            Parcel newParcel = new Parcel(49, 49, 50, 6);

            // Assert
            Assert.AreEqual(49, newParcel.Length);
            Assert.AreEqual(49, newParcel.Width);
            Assert.AreEqual(50, newParcel.Height);
            Assert.AreEqual(6, newParcel.Weight);

            Assert.AreEqual(ParcelSize.Large, newParcel.Type.Size);
            Assert.AreEqual(15.00, newParcel.Type.BaseCost);
            Assert.AreEqual(6.00, newParcel.Type.WeightLimit);
        }

        [Test]
        public void TestCreateParcel_XLParcel()
        {
            // Arrange / Act
            Parcel newParcel = new Parcel(101, 100, 100, 10);

            // Assert
            Assert.AreEqual(101, newParcel.Length);
            Assert.AreEqual(100, newParcel.Width);
            Assert.AreEqual(100, newParcel.Height);
            Assert.AreEqual(10, newParcel.Weight);

            Assert.AreEqual(ParcelSize.XL, newParcel.Type.Size);
            Assert.AreEqual(25.00, newParcel.Type.BaseCost);
            Assert.AreEqual(10.00, newParcel.Type.WeightLimit);
        }

        [Test]
        public void TestGetCost_SmallParcel()
        {
            // Arrange
            Parcel normalParcel = new Parcel(9, 9, 9, 1);
            Parcel overweightParcel = new Parcel(9, 9, 9, 3);

            // Act
            var normalResult = normalParcel.GetCost();
            var overweightResult = overweightParcel.GetCost();

            // Assert
            Assert.AreEqual(3.00, normalResult);
            Assert.AreEqual(7.00, overweightResult);
        }

        [Test]
        public void TestGetCost_MediumParcel()
        {
            // Arrange
            Parcel normalParcel = new Parcel(10, 9, 9, 3);
            Parcel overweightParcel = new Parcel(10, 9, 9, 5);

            // Act
            var normalResult = normalParcel.GetCost();
            var overweightResult = overweightParcel.GetCost();

            // Assert
            Assert.AreEqual(8.00, normalResult);
            Assert.AreEqual(12.00, overweightResult);
        }

        [Test]
        public void TestGetCost_LargeParcel()
        {
            // Arrange
            Parcel normalParcel = new Parcel(49, 49, 50, 6);
            Parcel overweightParcel = new Parcel(49, 49, 50, 8);

            // Act
            var normalResult = normalParcel.GetCost();
            var overweightResult = overweightParcel.GetCost();

            // Assert
            Assert.AreEqual(15.00, normalResult);
            Assert.AreEqual(19.00, overweightResult);
        }

        [Test]
        public void TestGetCost_XLParcel()
        {
            // Arrange
            Parcel normalParcel = new Parcel(101, 100, 100, 10);
            Parcel overweightParcel = new Parcel(101, 100, 100, 12);

            // Act
            var normalResult = normalParcel.GetCost();
            var overweightResult = overweightParcel.GetCost();

            // Assert
            Assert.AreEqual(25.00, normalResult);
            Assert.AreEqual(29.00, overweightResult);
        }
    }
}
