namespace Task3;

using System.Net;
using System.Net.Sockets;
using System.Text;

class Server
{
    private readonly TcpListener _server;
    private readonly Boolean _isRunning;

    public Server(int port)
    {
        _server = new TcpListener(IPAddress.Any, port);
        _server.Start();

        _isRunning = true;

        LoopClients();
    }

    private void LoopClients()
    {
        while (_isRunning)
        {
            // wait for client connection
            TcpClient newClient = _server.AcceptTcpClient();

            // client found.
            // create a thread to handle communication
            Thread thread = new Thread(HandleClient);
            thread.Start(newClient);
        }
    }

    private static void HandleClient(object obj)
    {
        var client = (TcpClient)obj;

        var sWriter = new StreamWriter(client.GetStream(), Encoding.ASCII);
        var sReader = new StreamReader(client.GetStream(), Encoding.ASCII);

        var bClientConnected = true;
        string? cData;
        while (bClientConnected)
        {
            cData = sReader.ReadLine();
            // reads from stream
            // shows content on the console.
            Console.WriteLine("Client > " + cData);


            switch (cData)
            {
                case "Task1":
                    GetTask("Enter your digit", FindFirstDigit, sWriter, sReader);

                    break;
                case "Task2":
                    GetTask("Enter N", MoreThan5K, sWriter, sReader);

                    break;
                case "Task3":
                    GetTask("Enter your digit", PowerOf4, sWriter, sReader);

                    break;
                case "Task4":
                    GetTask("AreYouShure", OtricatelnuyChlen, sWriter, sReader);

                    break;
                case "Task5":
                    sWriter.WriteLine("Enter your digit");
                    sWriter.Flush();
                    var data = sReader.ReadLine();
                    if (data != null)
                    {
                        for (int i = 0; i < Convert.ToInt32(data); i++)
                        {
                            var digit = Convert.ToDouble(sReader.ReadLine());
                            if (digit >= 0)
                            {
                                sWriter.WriteLine(Convert.ToString(Math.Abs(digit)));
                                sWriter.Flush();
                            }
                            else
                            {
                                sWriter.WriteLine("HAHA Loh vvel otricatelnoe");
                                sWriter.Flush();
                                break;
                            }

                        }
                    }

                    
                    

                    break;
                default:
                    sWriter.WriteLine("Please provide TaskN where N is a number of task");
                    sWriter.Flush();
                    break;
            }

            if (cData?.ToLower() == "exit")
            {
                bClientConnected = false;
                sWriter.WriteLine("closing");
                sWriter.Flush();
            }
        }

        sReader.Close();
        sWriter.Close();
        client.Close();
    }

    private static void GetTask<T>(string taskPhrase, Func<string, T> taskFunc, StreamWriter writer,
        StreamReader reader)
    {
        writer.WriteLine(taskPhrase);
        writer.Flush();
        var data = reader.ReadLine();

        if (data != null)
        {
            writer.WriteLine(taskFunc(data));
            writer.Flush();
        }
    }

    private static string FindFirstDigit(string digit)
    {
        return digit[..1];
    }

    private static string MoreThan5K(string data)
    {
        var n = Convert.ToDouble(data);
        var k = 0;
        while (Math.Pow(5, k) < n)
        {
            k++;
        }

        return $"{k}";
    }

    private static string PowerOf4(string data)
    {
        static double Logn(double n, int r)
        {
            return Math.Log(n) /
                   Math.Log(r);
        }

        var n = Convert.ToDouble(data);

        return Math.Abs(Math.Floor(Logn(n, 4)) - Math.Ceiling(Logn(n, 4))) == 0 ? "Yes" : "No";
    }

    private static string OtricatelnuyChlen(string data)
    {
        int n = 1;
        double answer;
        while ((answer = Math.Cos(1 / Math.Tan(n))) > 0) n++;
        return $"{answer}";
    }

    public static string FirstNegativeAbs(string data)
    {
        
    }
}