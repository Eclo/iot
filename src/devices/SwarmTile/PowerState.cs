// Licensed to the .NET Foundation under one or more agreements.
// Portions Copyright (c) Eclo Solutions.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Iot.Device.Swarm
{
    /// <summary>
    /// Power state of the Swarm Tile.
    /// </summary>
    public enum PowerState
    {
        /// <summary>
        /// Unknown power state.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Device is on
        /// </summary>
        On,

        /// <summary>
        /// Device is off
        /// </summary>
        Off,

        /// <summary>
        /// Device is in sleep mode
        /// </summary>
        Sleep,
    }
}
