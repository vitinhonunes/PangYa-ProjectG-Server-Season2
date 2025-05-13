using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.DB.Models
{
    [Table("td_char_equip_s4", Schema = "pangya")]
    [Keyless]
    public class Char_Equip_s4Model
    {
        public long SEQ { get; set; }
        public int UID { get; set; }
        public int CHAR_ITEMID { get; set; }
        public int ITEMID { get; set; }
        public Nullable<System.DateTime> IN_DATE { get; set; }
        public int EQUIP_NUM { get; set; }
        public int EQUIP_TYPE { get; set; }
        public string USE_YN { get; set; }

    }
}
