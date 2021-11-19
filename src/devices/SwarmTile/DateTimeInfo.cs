// Licensed to the .NET Foundation under one or more agreements.
// Portions Copyright (c) Eclo Solutions.
// The .NET Foundation licenses this file to you under the MIT license.

using System;

namespace Iot.Device.Swarm
{
    /// <summary>
    /// <see cref="DateTime"/> information from the Tile.
    /// </summary>
    public class DateTimeInfo
    {
        /// <summary>
        /// <see cref="DateTime"/> value available from the Tile.
        /// </summary>
        public DateTime Value { get; internal set; } = DateTime.MinValue;

        /// <summary>
        /// Information if the available <see cref="Value"/> is valid.
        /// </summary>
        public bool IsValid { get; internal set; }
    }
}
