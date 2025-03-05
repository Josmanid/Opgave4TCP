using System;
using System.IO;
using System.Net.Sockets;
using System.Net;
using Opgave4TCP;


public class Program
{
    private static void Main(string[] args) {
        //først skal der lyttes
        Console.WriteLine("TCP Server:");
        //The IP Address used here, is not the client IP
        TcpListener listener = new TcpListener(IPAddress.Any, 7);
        listener.Start();

        // Now we can handle more clients
        while (true)
        {
            //our communication socket/object we can communicate through
            TcpClient socket = listener.AcceptTcpClient();
            //Handling clients at the same time
            Task.Run(()=>ClientHandler.HandleClient(socket));

        }
        listener.Stop();
    }
}