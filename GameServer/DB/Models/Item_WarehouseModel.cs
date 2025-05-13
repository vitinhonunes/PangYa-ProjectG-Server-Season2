using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.DB.Models
{
    [Table("pangya_item_warehouse", Schema = "pangya")]
    [Keyless]
    public class Item_WarehouseModel
    {
        public long item_id { get; set; }
        public int UID { get; set; }
        public int typeid { get; set; }
        public short valid { get; set; }
        public Nullable<System.DateTime> regdate { get; set; }
        public short Gift_flag { get; set; }
        public short flag { get; set; }
        public Nullable<System.DateTime> Applytime { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public short C0 { get; set; }
        public short C1 { get; set; }
        public short C2 { get; set; }
        public short C3 { get; set; }
        public short C4 { get; set; }
        public short Purchase { get; set; }
        public short ItemType { get; set; }
        public int Level { get; set; }
        public int Up { get; set; }

    }
}
