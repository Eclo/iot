// Licensed to the .NET Foundation under one or more agreements.
// Portions Copyright (c) Eclo Solutions.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Iot.Device.Swarm
{
    /// <summary>
    /// Message event.
    /// </summary>
    public enum MessageEvent
    {
        /// <summary>
        /// No event.
        /// </summary>
        None = 0,

        /// <summary>
        /// Message received
        /// </summary>
        Received,

        /// <summary>
        /// Message help time expired
        /// </summary>
        Expired,

        /// <summary>
        /// Device is in sleep mode
        /// </summary>
        Sent,
    }
}
