using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.DB.Models
{
    [Table("pangya_rank_antes", Schema = "pangya")]
    [Keyless]
    public class Rank_AntesModel
    {
        public long index { get; set; }
        public int position { get; set; }
        public int UID { get; set; }
        public short tipo_rank { get; set; }
        public short tipo_rank_seq { get; set; }
        public int valor { get; set; }
        public Nullable<System.DateTime> reg_date { get; set; }
    }
}
