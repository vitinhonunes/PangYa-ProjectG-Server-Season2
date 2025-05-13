using PangyaAPI.BinaryModels;
using PangyaAPI.Cryptography;
using PangyaAPI.Models;
using System.Net;
using System.Net.Sockets;

namespace PangyaAPI
{
    public class TcpConnection
    {
        #region Delegates

        public delegate void PacketReceivedEvent(Player connection, Packet packet);

        #endregion

        #region Events

        /// <summary>
        /// Este evento ocorre quando o Servidor Recebe um Packet do ProjectG
        /// </summary>
        public event PacketReceivedEvent OnPacketReceived;


        #endregion


        private bool IsGameServer;

        #region Public Fields

        public Packet Packet { get; set; } = default!;

        public List<Player> Players { get; set; } = new();

        #endregion

        public void Start(string ip, int port, int maxConnections)
        {
            if (port == 20202)
                IsGameServer = true;
            Console.WriteLine("Servidor Iniciado na porta:" + port);

            var server = new TcpListener(IPAddress.Parse(ip), port);

            server.Start();

            Thread t = new Thread(new ParameterizedThreadStart(AcceptConnections));
            t.Start(server);
        }

        private void AcceptConnections(object obj)
        {
            for (; ; )
            {
                TcpClient newClient = ((TcpListener)obj).AcceptTcpClient();

                Thread t = new Thread(new ParameterizedThreadStart(HandleClient!));
                t.Start(newClient);
            }
        }

        private void HandleClient(object obj)
        {
            //Novo player
            var player = new Player()
            {
                Client = ((TcpClient)obj).Client,
                Key = 0x00
            };

            Players.Add(player);

            if (IsGameServer)
                player.SendWithoutEncrypt(new byte[] { 0xe8, 0x06, 0x00, 0x00, 0x00, 0x01, 0x01, 0x01, player.Key, 0x11 });
            else
                player.SendWithoutEncrypt(new byte[] { 0xe9, 0x0b, 0x00, 0x00, 0x00, 0xfa, player.Key, 0x00, 0x00, 0x00, 0x76, 0x27, 0x00, 0x00, 0xa2 });

            //player.SendWithoutEncrypt([0x00, 0x06, 0x00, 0x00, 0x3f, 0x00, 0x01, 0x01, player.Key]);

            while (player.Connected)
            {
                try
                {
                    var messageBufferRead = new byte[500000]; //Tamanho do BUFFER á ler

                    //Lê mensagem do OnCliente
                    int bytesRead = player.GetStream().Read(messageBufferRead, 0, 500000);

                    //variável para armazenar a mensagem recebida
                    byte[] message = new byte[bytesRead];

                    //Copia mensagem recebida
                    Buffer.BlockCopy(messageBufferRead, 0, message, 0, bytesRead);

                    if (message.Length >= 5)
                    {
                        var decryptedPackets = new ToServerBuffer().PutPacket(message, player.Key);

                        foreach (var packet in decryptedPackets)
                        {
                            player.CurrentPacket = new Packet(packet);

                            OnPacketReceived?.Invoke(player, packet: player.CurrentPacket);
                        }
                    }
                    else
                    {
                        //Sem Resposta
                        //Console.WriteLine("SEM RESPOSTA");
                        //DisconnectPlayer(player);
                    }
                }
                catch (Exception erro)
                {
                    Console.WriteLine("[Exception] " + erro.Message);
                }
            }
        }

        public void SendToAllPlayers(PangyaBinaryWriter packet)
        {
            Players.ForEach(p =>
            {
                p.Send(packet);
            });
        }
    }
}
