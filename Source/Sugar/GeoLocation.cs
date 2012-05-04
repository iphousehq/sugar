using System;

namespace Sugar
{
    /// <summary>
    /// Represents a point on the surface of a sphere
    /// </summary>
    public class GeoLocation
    {
        private readonly double minimumLatitude = -90d.ToRadians();
        private readonly double maximumLatitude = 90d.ToRadians();
        private readonly double miniumumLongitude = -180d.ToRadians();
        private readonly double maxiumumLongitude = 180d.ToRadians();

        /// <summary>
        /// Gets or sets the latitude in degrees.
        /// </summary>
        /// <value>
        /// The latitude degrees.
        /// </value>
        public double Latitude { get; set; }

        /// <summary>
        /// Gets the latitude in radians.
        /// </summary>
        public double LatitudeRadians
        {
            get { return Latitude.ToRadians(); }
        }

        /// <summary>
        /// Gets or sets the longitude in degrees.
        /// </summary>
        /// <value>
        /// The longitude degrees.
        /// </value>
        public double Longitude { get; set; }

        /// <summary>
        /// Gets the longitude in radians.
        /// </summary>
        public double LongitudeRadians
        {
            get { return Longitude.ToRadians(); }
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="GeoLocation"/> class from being created.
        /// </summary>
        private GeoLocation() {}

        /// <summary>
        /// Create a new GeoLocation from lat/long in degrees
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <returns></returns>
        public static GeoLocation FromDegrees(double latitude, double longitude)
        {
            var geo = new GeoLocation
            {
                Latitude = latitude,
                Longitude = longitude
            };

            geo.CheckBounds();

            return geo;
        }

        /// <summary>
        /// Create a new GeoLocation from lat/long in radians
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <returns></returns>
        public static GeoLocation FromRadians(double latitude, double longitude)
        {
            return FromDegrees(latitude.ToDegrees(), longitude.ToDegrees());
        }

        /// <summary>
        /// Checks the bounds.
        /// </summary>
        /// <returns></returns>
        private void CheckBounds()
        {
            if (LatitudeRadians < minimumLatitude)
                throw new ArgumentException(string.Format("Latitude must not be less than the minimum value. ({0})", minimumLatitude.ToDegrees()));
            if (LatitudeRadians > maximumLatitude)
                throw new ArgumentException(string.Format("Latitude must not be greater than the maximum value. ({0})", maximumLatitude.ToDegrees()));
            if (LongitudeRadians < miniumumLongitude)
                throw new ArgumentException(string.Format("Longitude must not be less than the minimum value. ({0})", miniumumLongitude.ToDegrees()));
            if (LongitudeRadians > maxiumumLongitude)
                throw new ArgumentException(string.Format("Longitude must not be greater than the maximum value. ({0})", maxiumumLongitude.ToDegrees()));
        }

        /// <summary>
        /// Calculate the great circle distance between this location and another location.
        /// <seealso cref="http://en.wikipedia.org/wiki/Great-circle_distance"/>
        /// </summary>
        /// <param name="location">The location.</param>
        /// <param name="radius">The radius of the sphere in KM. This defaults to the Earth's radius (6371.01km).</param>
        /// <returns></returns>
        public double GetDistanceTo(GeoLocation location, double radius = 6371.01)
        {
            if (radius < 0d) throw new ArgumentException("Radius must be greater than zero");

            return Math.Acos(Math.Sin(LatitudeRadians) * Math.Sin(location.LatitudeRadians) +
                             Math.Cos(LatitudeRadians) * Math.Cos(location.LatitudeRadians) *
                             Math.Cos(LongitudeRadians - location.LongitudeRadians)) * radius;
        }

        /// <summary>
        /// Calcualte the bounding box (in degrees) of all points on the surface of a sphere that
        /// have a great circle distance less than the given distance.
        /// <seealso cref="http://en.wikipedia.org/wiki/Great-circle_distance"/>
        /// </summary>
        /// <param name="distance">The distance.</param>
        /// <param name="radius">The radius of the sphere in KM. This defaults to the Earth's radius (6371.01km).</param>
        /// <returns></returns>
        public double[] GetBoundingBox(double distance, double radius = 6371.01)
        {
            if(radius < 0d) throw new ArgumentException("Radius must be greater than zero");
            if (distance < 0d) throw new ArgumentException("Distance must be greater than zero");

            var angularDistance = distance / radius;

            var minLat = LatitudeRadians - angularDistance;
            var maxLat = LatitudeRadians + angularDistance;

            double minLon, maxLon;

            if(minLat > minimumLatitude && maxLat < maximumLatitude)
            {
                var deltaLon = Math.Asin(Math.Sin(angularDistance) / Math.Cos(LatitudeRadians));
                
                minLon = LongitudeRadians - deltaLon;
                maxLon = LongitudeRadians + deltaLon;

                if (minLon < miniumumLongitude) minLon += 2d * Math.PI;
                if (maxLon > maxiumumLongitude) maxLon -= 2d * Math.PI;
            }
            else
            {
                minLat = Math.Max(minLat, minimumLatitude);
                maxLat = Math.Min(maxLat, maximumLatitude);
                minLon = miniumumLongitude;
                maxLon = maxiumumLongitude;
            }

            return new[] { minLat.ToDegrees(), minLon.ToDegrees(), maxLat.ToDegrees(), maxLon.ToDegrees() };
        }
    }
}
