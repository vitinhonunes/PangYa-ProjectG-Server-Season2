using PangyaAPI.BinaryModels;
using System.Net.Sockets;

namespace PangyaAPI.Models
{
    public class Packet
    {
        #region Public Fields

        /// <summary>
        /// Leitor do packet
        /// </summary>
        public PangyaBinaryReader Reader;

        /// <summary>
        /// Id do Packet
        /// </summary>
        public short Id { get; set; }

        /// <summary>
        /// Mensagem do Packet
        /// </summary>
        public byte[] Message { get; set; }

        #endregion

        #region Constructor

        public Packet(byte[] message)
        {
            Message = message;

            //Season 2
            Id = BitConverter.ToInt16(new byte[] { message[0], 0x00 }, 0);

            //Season 8
            //Id = BitConverter.ToInt16(new byte[] { message[0], message[1] }, 0);

            Reader = new PangyaBinaryReader(message);

            Reader.BaseStream.Seek(1, SeekOrigin.Current); //Seek Inicial

            //Season 8
            //Reader.BaseStream.Seek(2, SeekOrigin.Current); //Seek Inicial
        }

        #endregion

        #region Public Methods

        public string GetHexId()
        {
            byte[] bytes = BitConverter.GetBytes(Id);
            return BitConverter.ToString(bytes).Replace("-", " ");
        }

        #endregion
    }
}
