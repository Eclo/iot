// Licensed to the .NET Foundation under one or more agreements.
// Portions Copyright (c) Eclo Solutions.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Iot.Device.Swarm
{
    /// <summary>
    /// Operational quality based in the background noise RSSI.
    /// </summary>
    public enum OperationalQuality
    {
        /// <summary>
        /// Unknown quality.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Bad (not likely to work). &gt;-90 dBm.
        /// </summary>
        Bad,

        /// <summary>
        /// Marginal. &gt;-93 dBm.
        /// </summary>
        Marginal,

        /// <summary>
        /// OK. &gt;-97 dBm.
        /// </summary>
        OK,

        /// <summary>
        /// Good. &gt;-100 dBm.
        /// </summary>
        Good,

        /// <summary>
        /// Great. &gt;-105 dBm.
        /// </summary>
        Great
    }
}
