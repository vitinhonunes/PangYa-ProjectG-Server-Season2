using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.DB.Models
{
    [Table("pangya_character_part_padrao", Schema = "pangya")]
    [Keyless]
    public class Character_Part_PadraoModel
    {
        public long index { get; set; }
        public int char_typeid { get; set; }
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
    }
}
