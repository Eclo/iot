// Licensed to the .NET Foundation under one or more agreements.
// Portions Copyright (c) Eclo Solutions.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Iot.Device.Swarm
{
    internal static partial class TileCommands
    {
        /// <summary>
        /// Command to set or query the unsolicited report messages for GPS jamming and spoofing indicators.
        /// </summary>
        internal class GpsJammingSpoofing : CommandBase
        {
            public const string Command = "GJ";

            public int Value;

            public class Reply
            {
                private const int IndexOfSpoofState = 0;
                private const int IndexOfJammingLevel = 1;

                /// <summary>
                /// <see cref="JammingSpoofingIndication"/> information.
                /// </summary>
                public JammingSpoofingIndication? Indication { get; }

                /// <summary>
                /// Current rate (in seconds) between each message.
                /// </summary>
                public uint Rate { get; set; } = uint.MinValue;

                public Reply(NmeaSentence sentence)
                {
                    try
                    {
                        if (sentence.Data.Length >= 6)
                        {
                            // $GJ <spoof_state>,<jamming_level>*xx
                            //     |                           |
                            //     3
                            int startIndex = ReplyStartIndex;

                            // get details now
                            var indication = sentence.Data.Substring(startIndex).Split(',');

                            Indication = new JammingSpoofingIndication();

                            // spoof state
                            Indication.SpoofState = byte.Parse(indication[IndexOfSpoofState]);

                            // jamming
                            Indication.JammingLevel = byte.Parse(indication[IndexOfJammingLevel]);
                        }
                        else if (!sentence.Data.Contains(PromptOkReply))
                        {
                            // must be the current GJ rate

                            // $GJ <rate>* xx
                            //     |    |
                            //     3
                            Rate = uint.Parse(sentence.Data.Substring(ReplyStartIndex));
                        }
                    }
                    catch
                    {
                        // empty on purpose, failed to parse the NMEA sentence
                    }
                }
            }

            public GpsJammingSpoofing(int value = 0)
            {
                Value = value;
            }

            public static NmeaSentence GetLast()
            {
                return new NmeaSentence($"{Command} @");
            }

            internal override NmeaSentence ComposeToSend()
            {
                // set command data
                // query if value is 0
                // rate value otherwise
                string data = Value < 0 ? "?" : $"{Value}";

                return new NmeaSentence($"{Command} {data}");
            }
        }
    }
}
