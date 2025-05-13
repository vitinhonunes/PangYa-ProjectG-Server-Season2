using GameServer.PacketMethods;
using PangyaAPI;
using PangyaAPI.BinaryModels;
using PangyaAPI.Enums;
using PangyaAPI.Handles;
using PangyaAPI.Models;
using System.Numerics;
using System;
using System.Linq;
using Pangya.DB;



var server = new TcpConnection();
var db = new PangyaDBContext();



server.OnPacketReceived += OnPacketReceived;

//SEASON 2
server.Start("127.0.0.1", 20202, maxConnections: 30000);

void OnPacketReceived(Player player, Packet packet)
{
    _ = (GamePacketEnum)packet.Id switch
    {
        GamePacketEnum.PLAYER_LOGIN => new Method_PLAYER_LOGIN(player),


        _ => null as object
    };
    Console.WriteLine("O server recebeu o Packet: " + packet.Id);
}

for (; ; )
{
    var comando = Console.ReadLine().Split(new char[] { ' ' }, 2);

    switch (comando[0].ToLower())
    {
        case "mglobal":
            {

                var mglobal = new PangyaBinaryWriter(new byte[] { 0x04 });
                mglobal.WritePStr(comando[1]);
                server.SendToAllPlayers(mglobal);
                Console.WriteLine("Enviando menssagem global ");

            }
            break;        
        case "comando3":
            {
                var chat = new PangyaBinaryWriter(new byte[] { 0x02, 0x00 });
                chat.WritePStr("Vitinho");
                chat.WritePStr(comando[1]);
                server.SendToAllPlayers(chat);
                Console.WriteLine("Enviando menssagem no chat ");

            }
            break;
        default:
            {
                Console.WriteLine("Comando inexistente");
            }
            break;

        case "room":
            {
                //var resposta = new PangyaBinaryWriter(new byte[] {
                //0x0D, 0x00, 0x00, 0x6E, 0x6F, 0x6D,
                //0x65, 0x73, 0x61, 0x6C, 0x61, 0x00,
                //0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                //0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                //0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                //0x00, 0x00, 0x00, 0x00, 0x00, 0x73,
                //0x65, 0x6E, 0x68, 0x61, 0x73, 0x61,
                //0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                //0x00, 0x00, 0x00, 0x00, 0x01, 0x03,
                //0x01, 0x00, 0x1E, 0x12, 0x00, 0x00,
                //0x00, 0x00, 0xC0, 0xD4, 0x01, 0x00,
                //0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                //0x00, 0x00, 0x00, 0x00, 0x0A });

                //var resposta2 = new PangyaBinaryWriter(new byte[] {
                //0x0A, 0x00, 0x01, 0x00, 0x00, 0x00,
                //0x00, 0x31, 0x00, 0x00, 0x00, 0x00,
                //0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                //0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                //0x00, 0x00, 0x00, 0x00, 0x00, 0x42,
                //0x61, 0x69, 0x74, 0x6F, 0x6C, 0x61,
                //0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                //0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                //0x00, 0x00, 0x02, 0x00, 0x00, 0x00,
                //0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                //0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                //0x00, 0x00, 0x00, 0x01, 0x00, 0x00,
                //0x00, 0x00, 0x00, 0x00, 0x00, 0x30,
                //0x00, 0x00, 0x00, 0x04, 0x06, 0x00,
                //0x00, 0x38, 0x0A, 0x00, 0x40, 0x38,
                //0x00, 0x00, 0x00, 0x00, 0x07, 0x00,
                //0xC0, 0x38, 0x00, 0x00, 0x00, 0x00,
                //0x08, 0x65, 0x0A, 0x65 });

                var roomlobby = new PangyaBinaryWriter(new byte[] {
                    0x09,
                    0x02, //quantidade de salas no lobby
                    0x00 });


                roomlobby.WriteStr("NomeSala", 20);
                roomlobby.Write(new byte[] {
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 
                0x00, 0x03, //status da sala
                //Sumary
                //00,00 = sala cheia ou em jogo;01,01 = sala livre ;00,03 = sala com senha

                0x04,//Maxima da sala 
                0x03,//QUANTIDADE DE PESSOAS NA SALA 
                0x00,
                0x00,
                0x012,//QUANTIDADE DE HOLES
                0x00, // tipo da sala
                //   Sumary Tipo da Sala
                // 00 = Stroke ; 01 = Match ; 02  = Desafio Individual ;
                // 3 = Torneio ; 4 = Torneio Por times ; 5 = Bug ; 6 = Batalha por Pangs ; 7> = Bug

                0x01,//ID SALA 1
                0x00,
                0x05,//MAPA SALA 1
                0x00});


                roomlobby.WriteStr("Sala Teste 2", 20);
                // roomlobby.WriteStr("", 20);
                roomlobby.Write(new byte[] {
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00,
                0x00, 0x03, //status da sala
                //Sumary
                //00,00 = sala cheia ou em jogo;01,01 = sala livre ;00,03 = sala com senha

                0x04,//Maxima da sala 
                0x03,//QUANTIDADE DE PESSOAS NA SALA 
                0x00,
                0x00,
                0x012,//QUANTIDADE DE HOLES
                0x00, // tipo da sala
                //   Sumary Tipo da Sala
                // 00 = Stroke ; 01 = Match ; 02  = Desafio Individual ;
                // 3 = Torneio ; 4 = Torneio Por times ; 5 = Bug ; 6 = Batalha por Pangs ; 7> = Bug

                0x01,//ID SALA 2
                0x00,
                0x07,//MAPA SALA 2
                0x00});

                server.SendToAllPlayers(roomlobby);
                Console.WriteLine("Sala Criada");

            }
            break;      
            
    }
            
    
}