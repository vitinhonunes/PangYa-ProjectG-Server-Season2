using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.DB.Models
{
    [Table("pangya_rank_config", Schema = "pangya")]
    [Keyless]
    public class Rank_ConfigModel
    {
        public long index { get; set; }
        public int refresh_time_H { get; set; }
        public Nullable<System.DateTime> reg_date { get; set; }

    }
}
