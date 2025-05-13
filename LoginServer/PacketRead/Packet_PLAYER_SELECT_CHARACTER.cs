using PangyaAPI.BinaryModels;
using PangyaAPI.Handles;
namespace LoginServer.PacketRead
{
    internal class Packet_PLAYER_SELECT_CHARACTER : PacketResult
    {
        private byte IsFeminino { get; set; }

        private byte[] Unknown { get; set; }

        private byte CorCamisa { get; set; }

        public override void Load(PangyaBinaryReader reader)
        {
            IsFeminino = reader.ReadByte();

            Unknown = reader.ReadBytes(3);

            CorCamisa = reader.ReadByte();
        }
    }
}
