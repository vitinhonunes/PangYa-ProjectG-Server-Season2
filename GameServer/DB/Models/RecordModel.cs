using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.DB.Models
{
    [Table("pangya_record", Schema = "pangya")]
    [Keyless]
    public class RecordModel
    {
        public int UID { get; set; }
        public short tipo { get; set; }
        public short course { get; set; }
        public short best_score { get; set; }
        public long best_pang { get; set; }
        public int character_typeid { get; set; }
        public short event_score { get; set; }
        public int tacada { get; set; }
        public int putt { get; set; }
        public int hole { get; set; }
        public int fairway { get; set; }
        public int puttin { get; set; }
        public int total_score { get; set; }
        public int holein { get; set; }

    }
}
