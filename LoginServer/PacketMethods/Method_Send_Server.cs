using LoginServer.PacketRead;
using Microsoft.Identity.Client;
using PangyaAPI.BinaryModels;
using PangyaAPI.Handles;
using PangyaAPI.Models;

namespace LoginServer.PacketMethods
{
    class Method_Send_Server : HandleBase<Packet_PLAYER_SELECT_CHARACTER, Player>
    {
        public Method_Send_Server(Player connection) : base(connection)
        => Handle();

        public void Handle()
        {
            var servidores = new[]
           {
                new {
                    Nome = "João Vict.",
                    IP = "127.0.0.1",
                    Porta = 20202
                },
                new {
                    Nome = "Eric",
                    IP = "127.0.0.1",
                    Porta = 20203
                },
            };

         var packet_send_servers = new PangyaBinaryWriter(new byte[] { 0xFC, 0x02 });

            //Nome do servidor
            packet_send_servers.WriteStr("João Vict.", 10);

            var test = packet_send_servers.GetBytes();

            //VERIFICAR O QUE É
            packet_send_servers.Write(new byte[] {
                0x00, 0x02, 0x08,
                0x00, 0x00, 0x00, 0x2C, 0x00, 0x00, 0x00, 0x30, 0x9B, 0xFE, 0x02, 0x5C, 0x9B, 0xFE, 0x02,
                0x00, 0x00, 0x03, 0x08, 0x08, 0x00, 0x00, 0x00, 0x2C, 0x00, 0x00, 0x00, 0xED, 0x4E, 0x00,
                0x00, 0xD0, 0xFF /*Quantidade Maxima de usuarios*/ , 0x00, 0x00, 0x00, 0x00 /*usuarios on no server*/, 0x00 /*se alterar o server fica full*/, 0x00 /*se alterar o server fica full*/
            });

            packet_send_servers.WriteStr("127.0.0.1", 14);

            packet_send_servers.Write(new byte[] {
                0x00, 0x08, 0xD0, 0xAC,
                });

            //Porta
            packet_send_servers.Write((short)20202);

            packet_send_servers.Write(new byte[] {
                0x02,
                0x02, 0x00 /*alterar o server some*/, 0x00, 0x00, 0x00 });


            //Servidor 2

            packet_send_servers.Write(0x08);
            //Nome do servidor
            packet_send_servers.WriteStr("Eric", 10);

            //VERIFICAR O QUE É
            packet_send_servers.Write(new byte[] {
                0x00, 0x02, 0x08,
                0x00, 0x00, 0x00, 0x2C, 0x00, 0x00, 0x00, 0x30, 0x9B, 0xFE, 0x02, 0x5C, 0x9B, 0xFE, 0x02,
                0x00, 0x00, 0x03, 0x08, 0x08, 0x00, 0x00, 0x00, 0x2C, 0x00, 0x00, 0x00, 0xED, 0x4E, 0x00,
                0x00, 0xD0, 0x07, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00
            });

            packet_send_servers.WriteStr("127.0.0.1", 14);

            packet_send_servers.Write(new byte[] {
                0x00, 0x08, 0xD0, 0xAC,
                });

            //Porta
            packet_send_servers.Write((short)20203);

            packet_send_servers.Write(new byte[] {
                0x00,
                0x00, 0x00, 0x00, 0x00, 0x00 });


            var bytesGerados = packet_send_servers.GetBytes();

       

            Player.Send(packet_send_servers);
        }
}
}
