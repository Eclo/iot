// Licensed to the .NET Foundation under one or more agreements.
// Portions Copyright (c) Eclo Solutions.
// The .NET Foundation licenses this file to you under the MIT license.

using System;

namespace Iot.Device.Swarm
{
    /// <summary>
    /// Message received from the Swarm network.
    /// </summary>
    public class MessageReceived : MessageBase
    {
        /// <summary>
        /// Message identifier assigned by the device.
        /// </summary>
        /// <remarks>
        /// This property is empty for messages that have been created by code.
        /// </remarks>
        public string ID { get; internal set; } = string.Empty;

        /// <summary>
        /// Time-stamp of the moment the message was received by the Tile.
        /// </summary>
        /// <remarks>
        /// This property is empty for messages that have been created by code.
        /// </remarks>
        public DateTime TimeStamp { get; internal set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageReceived"/> class.
        /// </summary>
        /// <param name="data">Data to be sent.</param>
        /// <param name="applicationId">The application ID tag for the message.</param>
        public MessageReceived(string data, uint applicationId = 0)
            : base(data, applicationId)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageReceived"/> class.
        /// </summary>
        /// <param name="data">Data to be sent.</param>
        /// <param name="applicationId">The application ID tag for the message.</param>
        public MessageReceived(byte[] data, uint applicationId = 0)
            : base(data, applicationId)
        {
        }
    }
}
