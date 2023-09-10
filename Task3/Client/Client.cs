namespace Task3;

using System.Net.Sockets;
using System.Text;

class Client
{
    private readonly TcpClient _client;
    private StreamReader? _sReader;
    private StreamWriter? _sWriter;

    private Boolean _isConnected;

    public Client(string ipAddress, int portNum)
    {
        _client = new TcpClient();
        _client.Connect(ipAddress, portNum);

        HandleCommunication();
    }

    private void HandleCommunication()
    {
        _sReader = new StreamReader(_client.GetStream(), Encoding.ASCII);
        _sWriter = new StreamWriter(_client.GetStream(), Encoding.ASCII);

        _isConnected = true;
        string? sData;
        while (_isConnected)
        {
            
            Console.Write("> ");
            sData = Console.ReadLine();
            
            _sWriter.WriteLine(sData);
            _sWriter.Flush();
            
            var sDataIncoming = _sReader.ReadLine();
            Console.WriteLine(sDataIncoming);
            if (sDataIncoming == "closing")
            {
                _isConnected = false;
            }
        }
        _sReader.Close();
        _sWriter.Close();
        _client.Close();
    }
}