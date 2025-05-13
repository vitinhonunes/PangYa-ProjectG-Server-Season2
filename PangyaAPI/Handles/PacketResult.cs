using PangyaAPI.BinaryModels;

namespace PangyaAPI.Handles
{
    public abstract class PacketResult
    {
        public abstract void Load(PangyaBinaryReader reader);
    }
}
