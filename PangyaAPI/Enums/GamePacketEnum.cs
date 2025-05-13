namespace PangyaAPI.Enums
{
    public enum LoginServerPacketEnum
    {
        /// <summary>
        /// Player digita o usuário e senha e clica em login
        /// </summary>
        PLAYER_LOGIN_RESULT = 0x0001,

        /// <summary>
        /// Usuário selecionou o servidor
        /// </summary>
        PLAYER_SELECT_CHARACTER = 0x003E,
    }

    public enum GamePacketEnum
    {
        PLAYER_LOGIN = 0x0002,
        UNKNOWN_6A = 0x006A, //VERIFICAR O QUE É
        PLAYER_LOBBY = 0x0007, //entrada do player no lobby
        PLAYER_SAI_LOBBY = 0X0008,//SAIDA DO LOBBY
        PLAYER_CANAIS = 0X0013,//SAIDA DO LOBBY
        PLAYER_CHAT = 0x0005, //packet do chat
        PLAYER_C_ROOM = 0x000E, //criar sala
        
    }
        
}
