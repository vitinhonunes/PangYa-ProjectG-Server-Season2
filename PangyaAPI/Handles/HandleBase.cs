
using PangyaAPI.Models;

namespace PangyaAPI.Handles
{
    public class HandleBase<T, T2> 
        where T : PacketResult, new()
        where T2 : Player
    {
        public T2 Player { get; set; }

        public T PacketResult { get; set; }

        public HandleBase(T2 player)
        {
            this.Player = player;

            PacketResult = new T();
            PacketResult.Load(player.CurrentPacket!.Reader);

            //var json = JsonConvert.SerializeObject(PacketResult, Formatting.Indented);
            //Console.WriteLine(json);
        }
    }
}
