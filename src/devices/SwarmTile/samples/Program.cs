// Licensed to the .NET Foundation under one or more agreements.
// Portions Copyright (c) Eclo Solutions.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Threading;
using Iot.Device.Swarm;

namespace Swarm.Sample
{
    internal class Program
    {
        private static SwarmTile? s_swarmTile;
        private static bool s_RequestToExit = false;

        public static void Main()
        {
            Console.WriteLine("Starting SWARM Tile demo");

            s_swarmTile = new SwarmTile("/dev/ttyAMA0");

            // set this here just for debugging
            s_swarmTile.TimeoutForCommandExecution = 50_000;

            // wait 5 seconds for the Tile to become operational
            if (!s_swarmTile.DeviceReady.WaitOne(5_000, false))
            {
                ////////////////////////////
                // Tile is not responsive //
                ////////////////////////////

                Console.WriteLine("****************************************************************");
                Console.WriteLine("*** TILE IS NOT RESPONSIVE, POSSIBLY POWERED OFF OR SLEEPING ***");
                Console.WriteLine("****************************************************************");
            }
            else
            {
                // Tile is operational

                // output device IDs
                Console.WriteLine($"DeviceID: {s_swarmTile.DeviceID}");
                Console.WriteLine($"DeviceName: {s_swarmTile.DeviceName}");

                // setup event to handle power state change notifications
                s_swarmTile.PowerStateChanged += SwarmTile_PowerStateChanged;

                // setup handler for message events
                s_swarmTile.MessageEvent += SwarmTile_MessageEvent;

                // set GPS info rate to each 5 minutes
                s_swarmTile.GeospatialInformationRate = 5 * 60;

                // set date time information to each minute
                s_swarmTile.DateTimeStatusRate = 60;

                // get count on how many received messages are waiting to be read
                var unreadCount = s_swarmTile.MessagesReceived.UnreadCount;

                Console.WriteLine($"There are {unreadCount} unread messages.");

                if (unreadCount > 0)
                {
                    bool keepReading = true;

                    while (keepReading)
                    {
                        // read newest message
                        var newestMessage = s_swarmTile.MessagesReceived.ReadNewestMessage();

                        if (newestMessage == null)
                        {
                            // no more messages to read
                            keepReading = false;
                        }
                        else
                        {
                            Console.WriteLine($"+++ New message +++");
                            Console.WriteLine($"{newestMessage}");
                            Console.WriteLine();
                        }
                    }
                }

                // get count on how many messages are queued for transmission
                var toTxCount = s_swarmTile.MessagesToTransmit.Count;

                Console.WriteLine($"There are {toTxCount} messages queued for transmission.");

                // compose message to transmit
                MessageToTransmit message = new MessageToTransmit("Hello from .NET nanoFramework!");
                message.ApplicationID = 12345;

                // send message
                string msgId;

                if (s_swarmTile.TryToSendMessage(message, out msgId))
                {
                    Console.WriteLine($"Message {msgId} waiting to be transmitted!");
                }
                else
                {
                    Console.WriteLine($"Failed to send message. Error: {s_swarmTile.LastErrorMessage}.");
                }
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");

            // loop "forever" waiting a char to exit
            while (!s_RequestToExit)
            {
                // read console
                int line = Console.Read();

                if (line != -1)
                {
                    // user requested exit
                    break;
                }

                // wait another second to check input
                Thread.Sleep(1000);
            }
        }

        private static void Console_CancelKeyPress(object? sender, ConsoleCancelEventArgs e)
        {
            // close port to kill pending operations
            s_swarmTile?.Close();

            // signal to exit main()
            s_RequestToExit = true;
        }

        private static void SwarmTile_MessageEvent(MessageEvent messageEvent, string? messageId)
        {
            switch (messageEvent)
            {
                case MessageEvent.Expired:
                    Console.WriteLine($"Message {messageId} expired without being transmitted.");
                    break;

                case MessageEvent.Sent:
                    Console.WriteLine($"Message {messageId} has been successfully transmitted.");
                    break;

                case MessageEvent.Received:
                    Console.WriteLine($"Just received message {messageId}.");
                    break;

            }
        }

        private static void SwarmTile_PowerStateChanged(PowerState powerState)
        {
            switch (powerState)
            {
                case PowerState.On:
                    Console.WriteLine($"Tile is ON.");
                    break;

                case PowerState.Off:
                    Console.WriteLine($"Tile is OFF.");
                    break;

                case PowerState.Sleep:
                    Console.WriteLine($"Tile was entered SLEEP.");
                    break;

                case PowerState.Unknown:
                    Console.WriteLine($"Tile power mode is unknown.");
                    break;
            }
        }
    }
}
