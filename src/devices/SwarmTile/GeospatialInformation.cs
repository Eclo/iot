// Licensed to the .NET Foundation under one or more agreements.
// Portions Copyright (c) Eclo Solutions.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Iot.Device.Swarm
{
    /// <summary>
    /// Geospatial information of the Tile.
    /// </summary>
    public class GeospatialInformation
    {
        /// <summary>
        /// Latitude in d.dddd format.
        /// </summary>
        /// <remarks>
        /// The latitude is presented in the N basis (negative latitudes are in the southern hemisphere).
        /// </remarks>
        public float Latitude { get; internal set; }

        /// <summary>
        /// Longitude in d.dddd format.
        /// </summary>
        /// <remarks>
        /// The longitude is presented in the E basis (negative longitudes are in the western hemisphere).
        /// </remarks>
        public float Longitude { get; internal set; }

        /// <summary>
        /// Altitude in meters.
        /// </summary>
        public float Altitude { get; internal set; }

        /// <summary>
        /// Course in degrees (0..359).
        /// </summary>
        /// <remarks>
        /// Course proceeds clockwise, with 0=north, 90=east, 180=south, and 270=west.
        /// </remarks>
        public float Course { get; internal set; }

        /// <summary>
        /// Speed in kilometers per hour (0..999).
        /// </summary>
        public float Speed { get; internal set; }
    }
}
