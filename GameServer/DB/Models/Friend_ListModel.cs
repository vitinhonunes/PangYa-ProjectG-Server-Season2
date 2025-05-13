using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.DB.Models
{
    [Table("pangya_friend_list", Schema = "pangya")]
    [Keyless]
    public class Friend_ListModel
    {
        public int uid { get; set; }
        public int uid_friend { get; set; }
        public string apelido { get; set; }
        public int unknown1 { get; set; }
        public int unknown2 { get; set; }
        public int unknown3 { get; set; }
        public int unknown4 { get; set; }
        public int unknown5 { get; set; }
        public int unknown6 { get; set; }
        public short flag1 { get; set; }
        public byte state_flag { get; set; }
        public byte flag5 { get; set; }


    }
}
