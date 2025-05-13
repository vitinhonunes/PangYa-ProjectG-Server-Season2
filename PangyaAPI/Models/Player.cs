using PangyaAPI.BinaryModels;
using PangyaAPI.Cryptography;
using System.Net.Sockets;

namespace PangyaAPI.Models
{
    public class Player : TcpClient
    {
        public byte Key;

        public Packet? CurrentPacket { get; set; }

        public void Send(byte[] buffer)
        {
            SendWithoutEncrypt(CryptorS2.Encrypt(buffer, Key));
            //SendWithoutEncrypt(ServerCipher.Encrypt(buffer, Key, 0));
        }

        public void Send(PangyaBinaryWriter packet)
        {
            Send(packet.GetBytes());
        }

        /// <summary>
        /// Env
        /// </summary>
        /// <param name="buffer"></param>
        public void SendWithoutEncrypt(byte[] buffer)
        {
            GetStream().Write(buffer, 0, buffer.Length);
        }
    }
}
