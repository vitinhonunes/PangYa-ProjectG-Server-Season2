using PacketDotNet;
using SharpPcap.LibPcap;
using SharpPcap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PcapSniffer
{
    public enum ServiceType : int
    {
        //PangyaS1
        LoginServer = 10103,
        GameServer = 20202,
        RankServer = 7913,
        AntiCheat = 55999,

        ////PangyaS2 
        //LoginServer = 10103,
        //GameServer = 20202,
        //RankServer = 4774,
        //AntiCheat = 55999,

        //RenatoS4.9
        //LoginServer = 10110,
        //GameServer = 20202,
        //RankServer = 4774,
        //AntiCheat = 55999,

        ////Season 8
        //LoginServer = 10103,
        //GameServer = 20201,
        ////GameServer = 20207,
        //MessageServer = 10101



    }

    public sealed class PangyaCapturer : IDisposable
    {
        private readonly LibPcapLiveDevice _device;
        private readonly Dictionary<(ushort, ushort), ServiceInfo> _services = new Dictionary<(ushort, ushort), ServiceInfo>();

        public PangyaCapturer(LibPcapLiveDevice device)
        {
            _device = device;
            _device.OnPacketArrival += OnPacketArrival;
        }

        private readonly bool _isSeason4 = false;

        private void OnPacketArrival(object sender, CaptureEventArgs e)
        {
            RawCapture capture = e.Packet;
            Packet packet = Packet.ParsePacket(capture.LinkLayerType, capture.Data);
            IPv4Packet ipv4Packet = (IPv4Packet)packet.Extract(typeof(IPv4Packet));
            TcpPacket tcpPacket = (TcpPacket)packet.Extract(typeof(TcpPacket));


            if (tcpPacket == null)
            {
                return;
            }

            var isServer = tcpPacket.SourcePort == (int)ServiceType.LoginServer
                || tcpPacket.SourcePort == (int)ServiceType.GameServer
                || tcpPacket.SourcePort == (int)ServiceType.RankServer
                || tcpPacket.SourcePort == (int)ServiceType.AntiCheat;
            //|| tcpPacket.SourcePort == (int)ServiceType.MessageServer;

            //bool isServer = tcpPacket.SourcePort < tcpPacket.DestinationPort;
            ushort port1 = isServer ? tcpPacket.SourcePort : tcpPacket.DestinationPort;
            ushort port2 = isServer ? tcpPacket.DestinationPort : tcpPacket.SourcePort;
            (ushort, ushort) connectionId = (port1, port2);

            if (isServer)
            {
                if (port1 == (ushort)ServiceType.LoginServer && tcpPacket.PayloadData.Length > 2)
                {

                }
            }

            //Caso as portas não estiverem sidas listadas no enum, não continua
            if (!Enum.IsDefined(typeof(ServiceType), (int)port1) && !Enum.IsDefined(typeof(ServiceType), (int)port2))
                return;

            if (tcpPacket.Fin)
            {
                if (_services.Remove(connectionId))
                {
                    OnLogEvent?.Invoke(this, $"Connection finished. {ipv4Packet.SourceAddress}:{tcpPacket.SourcePort} -> {ipv4Packet.DestinationAddress}:{tcpPacket.DestinationPort}");
                }
                return;
            }

            if (tcpPacket.PayloadData.Length < 2)
            {
                return;
            }

            ServiceInfo serviceInfo;
            List<byte[]> decryptedPackets = new List<byte[]>();
            lock (_services)
            {
                serviceInfo = _services.ContainsKey(connectionId) ? _services[connectionId] : null;

                if (serviceInfo == null)
                {
                    if (RegisterNewService(connectionId, tcpPacket.PayloadData, tcpPacket.SourcePort))
                    {
                        OnLogEvent?.Invoke(this, $"Connection established. {ipv4Packet.SourceAddress}:{tcpPacket.SourcePort} -> {ipv4Packet.DestinationAddress}:{tcpPacket.DestinationPort}");
                    }
                    return;
                }

                var payload = tcpPacket.PayloadData;

                if (isServer && ((port1 == (ushort)ServiceType.AntiCheat) || port2 == (ushort)ServiceType.AntiCheat))
                {
                    decryptedPackets.Add(payload);
                }

                else
                {
                    try
                    {
                        serviceInfo.ToClientBuffer = new ToClientBuffer(serviceInfo.ToClientBuffer._serverCryptKey);
                        serviceInfo.ToServerBuffer = new ToServerBuffer(serviceInfo.ToServerBuffer._serverCryptKey);

                        if (isServer)
                        {
                        }

                        var teste = Shared.Server.Cryptor.Decrypt(tcpPacket.PayloadData, serviceInfo.ToClientBuffer._serverCryptKey);

                        if (isServer && tcpPacket.PayloadData.Length > 200)
                        {

                        }


                        decryptedPackets = isServer
                            ? new ToServerBuffer(serviceInfo.ToClientBuffer._serverCryptKey).PutPacket(tcpPacket.PayloadData)
                            //? serviceInfo.ToClientBuffer.PutPacket(tcpPacket.PayloadData)
                            //? decryptedPackets = new List<byte[]>
                            //{
                            //    tcpPacket.PayloadData
                            //}
                            : serviceInfo.ToServerBuffer.PutPacket(tcpPacket.PayloadData);
                    }
                    catch (Exception ex)
                    {
                        //OnExceptionReceived?.Invoke(this, ex.Message);
                    }
                }
            }

            if (!decryptedPackets.Any())
            {
                //Console.WriteLine("Ups, couldn't decrypt, packet too small!");
                return;
            }

            //Console.WriteLine($"Decrypted packet! Packets: '{decryptedPackets.Count}'");

            foreach (byte[] decryptedPacket in decryptedPackets)
            {
                OnPacketReceived?.Invoke(this, new DecryptedPacket(capture.Timeval.Date, serviceInfo.ServiceType, ipv4Packet.SourceAddress, tcpPacket.SourcePort,
                    ipv4Packet.DestinationAddress, tcpPacket.DestinationPort, isServer, decryptedPacket));
            }
        }

        public delegate void HandlePacket(object sender, DecryptedPacket decryptedPacket);
        public event HandlePacket OnPacketReceived;

        public delegate void HandlePacketException(object sender, string mensagem);
        public event HandlePacketException OnExceptionReceived;

        public delegate void LogEvent(object sender, string message);
        public event LogEvent OnLogEvent;

        public void Dispose()
        {
            //_device.Dispose();
        }

        public void StartCapture()
        {
            if (!_device.Opened)
            {
                _device.Open();
                //_device.Filter = "net 203.107.140.0/24 and tcp portrange 10000-45000";
                _device.Filter = "tcp portrange 4773-45000";
            }

            _device.StartCapture();
        }

        public void StopCapture()
        {
            _device.StopCapture();
        }


        private bool RegisterNewService((ushort, ushort) connectionId, byte[] payloadData, ushort serverPort)
        {
            ServiceType serviceType = ServiceType.GameServer;
            byte cryptographyKey = 0x00;


            if (_isSeason4)
            {
                int packetId = (payloadData[2] << 8) | payloadData[1];

                switch (packetId)
                {
                    case 0x000b:
                        serviceType = ServiceType.LoginServer;
                        cryptographyKey = payloadData[6];
                        break;
                    case 0x0006:
                        serviceType = ServiceType.GameServer;
                        cryptographyKey = payloadData[8];
                        break;
                    default:
                        //TODO: output error
                        return false;
                }
            }
            else
            {
                int packetId = (payloadData[1] << 8);

                switch (packetId)
                {
                    case 0x2100:
                        {
                            serviceType = ServiceType.RankServer;
                            cryptographyKey = payloadData[6];
                        }
                        break;
                    case 0x0000000b:
                    case 0xb00:
                        {
                            serviceType = serverPort == 7997 ? ServiceType.RankServer : ServiceType.LoginServer;
                            cryptographyKey = payloadData[6];
                        }
                        break;
                    case 0x1500:
                    case 0x600:
                        serviceType = ServiceType.GameServer;
                        cryptographyKey = payloadData[8];
                        break;
                    default:
                        //TODO: output error
                        return false;
                }
            }



            _services[connectionId] = new ServiceInfo(serviceType, new ToClientBuffer(cryptographyKey), new ToServerBuffer(cryptographyKey));
            return true;
        }
    }

    // Class for ServiceInfo
    public class ServiceInfo
    {
        public ServiceType ServiceType { get; set; }
        public ToClientBuffer ToClientBuffer { get; set; }
        public ToServerBuffer ToServerBuffer { get; set; }

        public ServiceInfo(ServiceType serviceType, ToClientBuffer toClientBuffer, ToServerBuffer toServerBuffer)
        {
            ServiceType = serviceType;
            ToClientBuffer = toClientBuffer;
            ToServerBuffer = toServerBuffer;
        }

    }

    // Class for DecryptedPacket
    public class DecryptedPacket
    {
        public DateTime DateTime { get; set; }

        public string Hora { get; set; }
        public ServiceType ServiceType { get; set; }
        public string Id { get; set; }
        public IPAddress Source { get; set; }
        public ushort SourcePort { get; set; }
        public IPAddress Destination { get; set; }
        public ushort DestinationPort { get; set; }
        public bool IsServer { get; set; }
        public byte[] Data { get; set; }
        public long DataSize { get { return Data.Length; } }

        public DecryptedPacket(DateTime date, ServiceType serviceType, IPAddress sourceAddress, ushort sourcePort, IPAddress destinationAddress, ushort destinationPort, bool isServer, byte[] decryptedPacket)
        {
            DateTime = date;
            Hora = date.ToString("HH:mm:ss");
            ServiceType = serviceType;
            Source = sourceAddress;
            SourcePort = sourcePort;
            Destination = destinationAddress;
            DestinationPort = destinationPort;
            IsServer = isServer;
            Data = decryptedPacket;
        }
    }
}
