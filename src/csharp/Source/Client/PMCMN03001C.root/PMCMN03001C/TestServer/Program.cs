using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Common;

namespace TestServer
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleInqPMIpcServer server = new SimpleInqPMIpcServer();
            server.SimplInqPMCommMsg.ConnectCheckEvent += new SimplInqPMCommMsg.CheckedConnectEventHandler(SimplInqPMCommMsg_ConnectCheckEvent);
            server.SimplInqPMCommMsg.MessageRecieveEvent += new SimplInqPMCommMsg.ReceivedMessageEventHandler(SimplInqPMCommMsg_MessageRecieveEvent);

            Console.ReadLine();
        }

        static void SimplInqPMCommMsg_MessageRecieveEvent(string message)
        {
            Console.WriteLine(message);
        }

        private static bool _connected = false;
        static void SimplInqPMCommMsg_ConnectCheckEvent(out bool isConnect)
        {
            isConnect = _connected;
            Console.WriteLine(_connected.ToString());

            _connected = !_connected;
        }
    }
}
