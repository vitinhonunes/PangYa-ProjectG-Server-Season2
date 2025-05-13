using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.DB.Models
{
    [Table("pangya_server_list", Schema = "pangya")]
    [Keyless]
    public class Server_ListModel
    {
        public string Name { get; set; }
        public int UID { get; set; }
        public string IP { get; set; }
        public int Port { get; set; }
        public int MaxUser { get; set; }
        public int CurrUser { get; set; }
        public short Type { get; set; }
        public System.DateTime UpdateTime { get; set; }
        public short State { get; set; }
        public short PCBangUser { get; set; }
        public int PangRate { get; set; }
        public string ServerVersion { get; set; }
        public string ClientVersion { get; set; }
        public int property { get; set; }
        public int AngelicWingsNum { get; set; }
        public short EventFlag { get; set; }
        public int ExpRate { get; set; }
        public int RareItemRate { get; set; }
        public int CookieItemRate { get; set; }
        public int ServiceControl { get; set; }
        public short ImgNo { get; set; }
        public short AppRate { get; set; }
        public short ScratchRate { get; set; }
        public int EventMap { get; set; }
        public int EventDropRate { get; set; }
        public int HanbitUser { get; set; }
        public int ParanUser { get; set; }
        public short AuthState { get; set; }
        public short ChuvaRate { get; set; }


    }
}
