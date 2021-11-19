// Licensed to the .NET Foundation under one or more agreements.
// Portions Copyright (c) Eclo Solutions.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Iot.Device.Swarm
{
    /// <summary>
    /// Tile Status events.
    /// </summary>
    public enum TileStatus
    {
        /// <summary>
        /// Unknown status.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// A firmware crash occurred that caused a restart.
        /// </summary>
        Abort,

        /// <summary>
        /// The first time GPS has acquired a valid date/time reference.
        /// </summary>
        DateTimeAvailable,

        /// <summary>
        /// The first time GPS has acquired a valid position 3D fix.
        /// </summary>
        PositionAvailable,

        /// <summary>
        /// An error message has been received from the Tile. Check the content
        /// </summary>
        Error,
    }
}
