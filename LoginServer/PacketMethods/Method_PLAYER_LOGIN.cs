using LoginServer.PacketRead;
using PangyaAPI.BinaryModels;
using PangyaAPI.Handles;
using PangyaAPI.Models;
using System.Net.Sockets;
using Pangya.DB;
using Microsoft.Data.SqlClient;
using LoginServer.PacketMethods;


namespace LoginServer.PacketMethods
{
    internal class Method_PLAYER_LOGIN : HandleBase<Packet_PLAYER_LOGIN, Player>
    {
        public Method_PLAYER_LOGIN(Player connection) : base(connection)
        => Handle();
        private void Handle()
        {
            var db = new PangyaDBContext();

            /*
            00 = Login Ok
            01 = Login Inexistente
            02 = problema no servidor
            03 = Login em Uso
            04 = Login bloqueado
            05 = Usuário ou senha inválido
            06 = Login proibido por tempo limitado
            07 = Crasha o jogo
            08 = Bloqueio Por Idade
            09 = Sem autorização para jogar
            10 = houve um erro no login por parte do servidor
            11 = Numero do RG invalido
            12 = Usuario cancelado
            13 = Apenas Usuarios autorizados podem fazer o login
            14 = MsgBox erro login
            15 = Não disponivel para sua area "Pais"
              
            New Character
            packet.ID        nick =   a     d     s  
            0x8A, 0x00, 0x03, 0x00, 0x61, 0x64, 0x73, 0xC5

            packet.Write(new byte[] { 0xfb, 0x04 });  

            */

//          LISTA DE SERVIDORES
            
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

///////// Fim da lista de Servidores




            // ********consultar e validar um usuário específico************//
            var contausuario = db.Account.Where(c => PacketResult.Username == c.ID && PacketResult.Password == c.PASSWORD).FirstOrDefault();

            if (contausuario != null)
            { 
                var packet = new PangyaBinaryWriter(new byte[] { 0xFB, 0x00 });
                packet.WritePStr(PacketResult.Username);
                //Verificar
                packet.Write(new byte[] { 0xE8, 0x07, 0x09, 0x00, 0x05, 0x00, 0x1B, 0x00, 0x01, 0x00, 0x12, 0x00, 0x33, 0x00, 0xD5, 0x03, 0x00, 0x00, 0x32, 0x98 });
                                
            Player.Send(packet);
            Player.Send(packet_send_servers);
            Console.WriteLine("Login OK");


        } 


            if (contausuario == null)
            {
                //packet que usuario não existe
                var packet = new PangyaBinaryWriter(new byte[] { 0xfb, 0x05 });
                Player.Send(packet);
                Console.WriteLine("Login ou senha Invalida");
            }



            ////Tela de seleção de personagem, 0x44 0x00(masculino), 0x44 0x01(feminino)

            //var packet = new PangyaBinaryWriter(new byte[] { 0x44, 0x00 });
            //packet.WritePStr(PacketResult.Username);
            //Player.Send(packet.GetBytes());

            Console.WriteLine("O Player " + PacketResult.Username + " Realizou o Login com sucesso!");
        }
    }
}
