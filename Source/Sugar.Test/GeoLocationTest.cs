using System;
using NUnit.Framework;
using Sugar.Extensions;

namespace Sugar
{
    [TestFixture]
    public class GeoLocationTest
    {
        private GeoLocation location;

        [SetUp]
        public void Setup()
        {
            location = GeoLocation.FromDegrees(0, 0);
        }

        [Test]
        public void TestConstructorFromDegrees()
        {
            var loc = GeoLocation.FromDegrees(1, 1);

            Assert.AreEqual(1, loc.Latitude);
            Assert.AreEqual(1, loc.Longitude);
        }

        [Test]
        public void TestConstructorFromRadians()
        {
            var loc = GeoLocation.FromRadians(1d.ToRadians(), 1d.ToRadians());

            Assert.AreEqual(1, loc.Latitude);
            Assert.AreEqual(1, loc.Longitude);
        }

        [Test]
        public void TestConstructorFromDegreesLatitideTooSmall()
        {
            var exception = Assert.Throws<ArgumentException>(() => GeoLocation.FromDegrees(-95, 1));
            
            Assert.AreEqual(exception.Message, "Latitude must not be less than the minimum value. (-90)");
        }

        [Test]
        public void TestConstructorFromDegreesLatitideTooLarge()
        {
            var exception = Assert.Throws<ArgumentException>(() => GeoLocation.FromDegrees(95, 1));

            Assert.AreEqual(exception.Message, "Latitude must not be greater than the maximum value. (90)");
        }

        [Test]
        public void TestConstructorFromDegreesLongitudeTooSmall()
        {
            var exception = Assert.Throws<ArgumentException>(() => GeoLocation.FromDegrees(1, -185));

            Assert.AreEqual(exception.Message, "Longitude must not be less than the minimum value. (-180)");
        }

        [Test]
        public void TestConstructorFromDegreesLongitudeTooLarge()
        {
            var exception = Assert.Throws<ArgumentException>(() => GeoLocation.FromDegrees(1, 185));

            Assert.AreEqual(exception.Message, "Longitude must not be greater than the maximum value. (180)");
        }

        [Test]
        public void TestGetDistanceToRadiusLessThanZero()
        {
            var toLocation = GeoLocation.FromDegrees(20, 20);

            Assert.Throws<ArgumentException>(() => location.GetDistanceTo(toLocation, -1), "Radius must be greater than zero");
        }

        [Test]
        public void TestGetDistanceTo()
        {
            //Math.Acos(Math.Sin(0.ToRadians()) * Math.Sin(20.ToRadians()) +
            //          Math.Cos(0.ToRadians()) * Math.Cos(20.ToRadians()) *
            //          Math.Cos(0.ToRadians() - 20.ToRadians())) * 6371.01;

            //Math.Acos(Math.Sin(0) * Math.Sin(0.34906585) +
            //          Math.Cos(0) * Math.Cos(0.34906585) *
            //          Math.Cos(0 - 0.34906585)) * 6371.01;

            //Math.Acos(0 * 0.342020143 +
            //          1 * 0.939692621 *
            //          Math.Cos(-0.34906585)) * 6371.01;

            //Math.Acos(0 * 0.342020143 +
            //          1 * 0.939692621 *
            //          0.939692621) * 6371.01;

            //Math.Acos(0.883022222) * 6371.01;

            //0.488533203 * 6371.01;

            //3112.44992

            var toLocation = GeoLocation.FromDegrees(20, 20);

            var distance = location.GetDistanceTo(toLocation);

            Assert.AreEqual(3112.44992, distance, 0.0001);
        }

        [Test]
        public void TestGetBoundingBoxRadiusLessThanZero()
        {
            Assert.Throws<ArgumentException>(() => location.GetBoundingBox(1000, -1), "Radius must be greater than zero");
        }

        [Test]
        public void TestGetBoundingBoxRadius()
        {
            //angularDistance = 1000 / 6371.01
            //angularDistance = 0.156960984

            //minLat = 0.ToRadians() - 0.156960984
            //maxLat = 0.ToRadians() + 0.156960984

            //minLat = -0.156960984
            //maxLat = 0.156960984

            //deltaLon = Math.Asin(Math.Sin(0.156960984) / Math.Cos(0))
            //deltaLon = Math.Asin(0.156317276 / 1)
            //deltaLon = 0.156960984

            //minLon = 0 - 0.156960984;
            //maxLon = 0 + 0.156960984;

            //minLon = -0.156960984;
            //maxLon = +0.156960984;

            var box = location.GetBoundingBox(1000);

            Assert.AreEqual(-8.99320193, box[0], 0.0001);
            Assert.AreEqual(-8.99320193, box[1], 0.0001);
            Assert.AreEqual(8.99320193, box[2], 0.0001);
            Assert.AreEqual(8.99320193, box[3], 0.0001);
        }

        [Test]
        public void TestGetBoundingBoxRadiusNearPoles()
        {
            //angularDistance = 1000 / 6371.01
            //angularDistance = 0.156960984

            //minLat = 88.ToRadians() - 0.156960984
            //maxLat = 88.ToRadians() + 0.156960984

            //minLat = 1.53588974 - 0.156960984
            //maxLat = 1.53588974 + 0.156960984

            //minLat = 1.37892876
            //maxLat = 1.69285072

            var loc = GeoLocation.FromDegrees(88, 178);

            var box = loc.GetBoundingBox(1000);

            Assert.AreEqual(79.0067982, box[0], 0.0001);
            Assert.AreEqual(-180, box[1], 0.0001);
            Assert.AreEqual(90, box[2], 0.0001);
            Assert.AreEqual(180, box[3], 0.0001);
        }
    }
}
