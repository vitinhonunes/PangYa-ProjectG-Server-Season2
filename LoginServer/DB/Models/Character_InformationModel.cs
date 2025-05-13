using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.DB.Models
{
    [Table("pangya_character_information", Schema = "pangya")]
    [Keyless]
    public class Character_InformationModel
    {

        public long item_id { get; set; }
        public int typeid { get; set; }
        public int UID { get; set; }
        public int parts_1 { get; set; }
        public int parts_2 { get; set; }
        public int parts_3 { get; set; }
        public int parts_4 { get; set; }
        public int parts_5 { get; set; }
        public int parts_6 { get; set; }
        public int parts_7 { get; set; }
        public int parts_8 { get; set; }
        public int parts_9 { get; set; }
        public int parts_10 { get; set; }
        public int parts_11 { get; set; }
        public int parts_12 { get; set; }
        public int parts_13 { get; set; }
        public int parts_14 { get; set; }
        public int parts_15 { get; set; }
        public int parts_16 { get; set; }
        public int parts_17 { get; set; }
        public int parts_18 { get; set; }
        public int parts_19 { get; set; }
        public int parts_20 { get; set; }
        public int parts_21 { get; set; }
        public int parts_22 { get; set; }
        public int parts_23 { get; set; }
        public int parts_24 { get; set; }
        public short default_hair { get; set; }
        public short default_shirts { get; set; }
        public short gift_flag { get; set; }
        public short PCL0 { get; set; }
        public short PCL1 { get; set; }
        public short PCL2 { get; set; }
        public short PCL3 { get; set; }
        public short PCL4 { get; set; }
        public short Purchase { get; set; }

    }
}
