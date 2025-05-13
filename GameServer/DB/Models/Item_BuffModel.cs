using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.DB.Models
{
    [Table("pangya_item_buff", Schema = "pangya")]
    [Keyless]
    public class Item_BuffModel
    {
        public long index { get; set; }
        public int uid { get; set; }
        public int typeid { get; set; }
        public System.DateTime reg_date { get; set; }
        public System.DateTime end_date { get; set; }
        public short tipo { get; set; }
        public int percent { get; set; }
        public byte use_yn { get; set; }

    }
}
