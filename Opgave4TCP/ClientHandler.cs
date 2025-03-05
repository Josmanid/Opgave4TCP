using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Opgave4TCP
{
    public static class ClientHandler
    {
        public static void HandleClient(TcpClient socket) {
            //The client handling process
            //now we can use connection
            NetworkStream stream = socket.GetStream();

            //we can se what the client sends through this
            StreamReader reader = new StreamReader(stream);
            StreamWriter writer = new StreamWriter(stream) { AutoFlush = true};
           

            while (true)
            {

                //You read what the client sends by calling the method ReadLine on the reader object:
                string message = reader.ReadLine();

                Console.WriteLine("Client sent: " + message);
                //Then write the line back to the client, use the writer object:
                switch (message)
                {
                    //step 1
                    case "Random":
                        //Step 2
                        writer.WriteLine("Input numbers");
                        //Step 3
                        string[] twoNumbers = reader.ReadLine().Split();
                        Random random = new Random();
                        int num1 = int.Parse(twoNumbers[0]);
                        int num2 = int.Parse(twoNumbers[1]);
                        string result = random.Next(num1,num2+1).ToString();
                        //Step 4
                        writer.WriteLine(result);
                        
                        break;
                    case "Add":
                        //Step 2
                        writer.WriteLine("Input numbers");
                        //Step 3
                        string[] addNum = reader.ReadLine().Split();
                        int addnum1 = int.Parse(addNum[0]);
                        int addnum2 = int.Parse(addNum[1]);
                        string addResult = (addnum1 + addnum2).ToString();
                        //Step 4
                        writer.WriteLine(addResult);
                        break;
                    case "Subtract":
                        //Step 2
                        writer.WriteLine("Input numbers");
                        //Step 3
                        string[] subsNum = reader.ReadLine().Split();
                        int subnum1 = int.Parse(subsNum[0]);
                        int subnum2 = int.Parse(subsNum[1]);
                        string subResult = (subnum1 - subnum2).ToString();
                        //Step 4
                        writer.WriteLine(subResult);
                        break;

                }
                
            }

            socket.Close();

        }
    }
}
