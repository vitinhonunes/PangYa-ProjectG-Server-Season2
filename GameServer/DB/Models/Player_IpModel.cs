using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.DB.Models
{
    [Table("pangya_player_ip", Schema = "pangya")]
    [Keyless]
    public class Player_IpModel
    {
        public long index { get; set; }
        public int uid { get; set; }
        public string ip { get; set; }
        public byte block_beta { get; set; }
        public short flag_day { get; set; }
        public int change_count { get; set; }
        public Nullable<System.DateTime> change_date { get; set; }

    }
}
