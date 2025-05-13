using PangyaAPI.BinaryModels;
using PangyaAPI.Handles;

namespace GameServer.PacketRead
{
    internal class Packet_PLAYER_LOGIN : PacketResult
    {
        /// <summary>
        /// Nome do usuário logado
        /// </summary>
        public string Username { get; set; }

        public string Password { get; set; }

        public string Nickname { get; set; }

        /// <summary>
        /// VERIFICAR O QUE É
        /// </summary>
        public byte[] Unknown { get; set; }

        public override void Load(PangyaBinaryReader reader)
        {
            this.Username = reader.ReadPStr();
            this.Password = reader.ReadPStr();
            this.Nickname = reader.ReadPStr();
            this.Unknown = reader.ReadBytes(4);
        }
    }
}
