using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.DB.Models
{
    [Table("pangya_notice_list", Schema = "pangya")]
    [Keyless]
    public class Notice_ListModel
    {
        public long notice_id { get; set; }
        public string message { get; set; }
        public int replayCount { get; set; }
        public int refreshTime { get; set; }
    }
}
