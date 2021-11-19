// Licensed to the .NET Foundation under one or more agreements.
// Portions Copyright (c) Eclo Solutions.
// The .NET Foundation licenses this file to you under the MIT license.

using System;

namespace Iot.Device.Swarm
{
    internal static partial class TileCommands
    {
        /// <summary>
        /// Command to transmit a message to the Swarm network.
        /// </summary>
        internal class TransmitData : CommandBase
        {
            public const string Command = "TD";

            private MessageToTransmit _message;

            public class Reply
            {
                /// <summary>
                /// Id assigned to the message after being placed in the local queue.
                /// </summary>
                public string MessageId { get; } = string.Empty;

                /// <summary>
                /// Error message.
                /// </summary>
                public string ErrorMessage { get; } = string.Empty;

                /// <summary>
                /// Event for a message.
                /// </summary>
                public MessageEvent Event { get; }

                public Reply(NmeaSentence sentence)
                {
                    if (sentence.Data.StartsWith("TD OK"))
                    {
                        // $TD OK,5354468575855*2a
                        //        |           |
                        //        6
                        int startIndex = 6;

                        // get message ID
                        MessageId = sentence.Data.Substring(startIndex);
                    }
                    else if (sentence.Data.Contains(PromptErrorReply))
                    {
                        // handle expired error differently
                        if (sentence.Data.Contains("HOLDTIMEEXPIRED"))
                        {
                            // $TD ERR,HOLDTIMEEXPIRED,<msg_id>*xx
                            //                         |      |
                            //                         23
                            int startIndex = 23;

                            // get message ID
                            MessageId = sentence.Data.Substring(startIndex);

                            Event = MessageEvent.Expired;
                        }
                        else
                        {
                            // for all the rest extract the error detail

                            // $TD ERR,BADDATA*0e
                            //         |     |
                            //         7
                            int startIndex = 7;

                            // get error message
                            ErrorMessage = sentence.Data.Substring(startIndex);
                        }
                    }
                    else if (sentence.Data.StartsWith("TD SENT"))
                    {
                        Event = MessageEvent.Sent;
                    }
                }
            }

            public TransmitData(MessageToTransmit message)
            {
                _message = message;
            }

            internal override NmeaSentence ComposeToSend()
            {
                // set optional parameters
                string hdParam = string.Empty;
                string etParam = string.Empty;

                if (_message.HoldDuration > 0)
                {
                    hdParam = $",HD={_message.HoldDuration}";
                }

                if (_message.ExpireTime > DateTime.MinValue)
                {
                    DateTimeOffset et = new(_message.ExpireTime);
                    etParam = $",ET={et.ToUnixTimeSeconds()}";
                }

                return new NmeaSentence($"{Command} AI={_message.ApplicationID}{hdParam}{etParam},\"{_message.Data}\"");
            }
        }
    }
}
