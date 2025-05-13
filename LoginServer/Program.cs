using LoginServer.PacketMethods;
using PangyaAPI;
using PangyaAPI.BinaryModels;
using PangyaAPI.Enums;
using PangyaAPI.Models;
using System;
using System.Numerics;


var server = new TcpConnection();
server.OnPacketReceived += OnPacketReceived;

//SEASON 2
server.Start("127.0.0.1", 10101, maxConnections: 30000);
server.Start("127.0.0.1", 10102, maxConnections: 30000);
server.Start("127.0.0.1", 10103, maxConnections: 30000);
server.Start("127.0.0.1", 10104, maxConnections: 30000);
server.Start("127.0.0.1", 10020, maxConnections: 30000);
server.Start("127.0.0.1", 10021, maxConnections: 30000);
server.Start("127.0.0.1", 10022, maxConnections: 30000);
server.Start("127.0.0.1", 10023, maxConnections: 30000);
server.Start("127.0.0.1", 10024, maxConnections: 30000);



void OnPacketReceived(Player player, Packet packet)
{
    _ = (LoginServerPacketEnum)packet.Id switch
    {
        LoginServerPacketEnum.PLAYER_LOGIN_RESULT => new Method_PLAYER_LOGIN(player),
        LoginServerPacketEnum.PLAYER_SELECT_CHARACTER => new Method_Send_Server(player),
        _ => null as object
    };

}
    