// Licensed to the .NET Foundation under one or more agreements.
// Portions Copyright (c) Eclo Solutions.
// The .NET Foundation licenses this file to you under the MIT license.

using System;

namespace Iot.Device.Swarm
{
    /// <summary>
    /// Exception occurred when executing a command.
    /// </summary>
    public class ErrorExecutingCommandException : Exception
    {
        /// <summary>
        /// Exception occurred when executing a command.
        /// </summary>
        public ErrorExecutingCommandException()
        {
        }

        /// <summary>
        /// Exception occurred when executing a command.
        /// </summary>
        /// <param name="message">Error message with details about the error.</param>
        public ErrorExecutingCommandException(string message)
            : base(message)
        {
        }
    }
}
