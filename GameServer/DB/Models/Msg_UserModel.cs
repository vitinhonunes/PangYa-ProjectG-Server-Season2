using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.DB.Models
{
    [Table("pangya_msg_user", Schema = "pangya")]
    [Keyless]
    public class Msg_UserModel
    {
        public long msg_idx { get; set; }
        public int uid { get; set; }
        public int uid_from { get; set; }
        public short valid { get; set; }
        public string msg { get; set; }
        public System.DateTime reg_date { get; set; }
    }
}
