// Licensed to the .NET Foundation under one or more agreements.
// Portions Copyright (c) Eclo Solutions.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Iot.Device.Swarm
{
    internal static partial class TileCommands
    {
        /// <summary>
        /// Command to retrieve the configuration settings for the Swarm device ID.
        /// </summary>
        internal class ConfigurationSettings : CommandBase
        {
            public const string Command = "CS";

            public class Reply
            {
                private const int IndexOfDeviceId = 0;
                private const int IndexOfDeviceName = 1;

                /// <summary>
                /// Device ID that identifies this device on the Swarm network
                /// </summary>
                public string DeviceId { get; } = string.Empty;

                /// <summary>
                /// Device type name.
                /// </summary>
                public string DeviceName { get; } = string.Empty;

                public Reply(NmeaSentence sentence)
                {
                    try
                    {
                        // $CS DI=<dev_ID>,DN=<dev_name>*xx
                        //     |                       |
                        //     3
                        int startIndex = ReplyStartIndex;

                        // get version now
                        var configuration = sentence.Data.Substring(startIndex).Split(',');

                        // device ID
                        var deviceIdRaw = configuration[IndexOfDeviceId].Split('=');
                        DeviceId = deviceIdRaw[1];

                        // device name
                        var deviceNameRaw = configuration[IndexOfDeviceName].Split('=');
                        DeviceName = deviceNameRaw[1];
                    }
                    catch
                    {
                        // empty on purpose, failed to parse the NMEA sentence
                    }
                }
            }

            internal override NmeaSentence ComposeToSend()
            {
                return new NmeaSentence(Command);
            }
        }
    }
}
