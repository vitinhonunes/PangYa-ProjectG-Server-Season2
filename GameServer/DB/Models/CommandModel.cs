using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.DB.Models
{
    [Table("pangya_command", Schema = "pangya")]
    [Keyless]
    public class CommandModel
    {
        public long idx { get; set; }
        public int command_id { get; set; }
        public int arg1 { get; set; }
        public int arg2 { get; set; }
        public int arg3 { get; set; }
        public int arg4 { get; set; }
        public int arg5 { get; set; }
        public int target { get; set; }
        public System.DateTime regDate { get; set; }
        public Nullable<System.DateTime> reserveDate { get; set; }
        public short flag { get; set; }
        public short valid { get; set; }


    }
}
