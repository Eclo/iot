// Licensed to the .NET Foundation under one or more agreements.
// Portions Copyright (c) Eclo Solutions.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Iot.Device.Swarm
{
    /// <summary>
    /// Operational quality based in the background noise RSSI.
    /// </summary>
    public enum GpsFixType : byte
    {
        /// <summary>
        /// No fix.
        /// </summary>
        None = 0,

        /// <summary>
        /// Dead reckoning only solution.
        /// </summary>
        DeadReckoning,

        /// <summary>
        /// Standalone 2D solution.
        /// </summary>
        Standalone2D,

        /// <summary>
        /// Standalone 3D solution.
        /// </summary>
        Standalone3D,

        /// <summary>
        /// Differential 2D solution.
        /// </summary>
        Differential2D,

        /// <summary>
        /// Differential 3D solution.
        /// </summary>
        Differential3D,

        /// <summary>
        /// Combined GNSS + dead reckoning solution.
        /// </summary>
        Combined,

        /// <summary>
        /// Time only solution.
        /// </summary>
        TimeOnly,
    }
}
