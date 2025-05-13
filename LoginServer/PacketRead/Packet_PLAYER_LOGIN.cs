using PangyaAPI.BinaryModels;
using PangyaAPI.Handles;

namespace LoginServer.PacketRead
{
    internal class Packet_PLAYER_LOGIN : PacketResult
    {
        /// <summary>
        /// Nome do usuário logado
        /// </summary>
        public string Username { get; set; }

        public string Password { get; set; }

        public override void Load(PangyaBinaryReader reader)
        {
            this.Username = reader.ReadPStr();
            this.Password = reader.ReadPStr();
        }
    }
}
