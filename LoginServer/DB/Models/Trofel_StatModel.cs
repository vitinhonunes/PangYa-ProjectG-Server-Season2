using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.DB.Models
{
    [Table("trofel_stat", Schema = "pangya")]
    [Keyless]
    public class Trofel_StatModel
    {
        public long UID { get; set; }
        public short AMA_6_G { get; set; }
        public short AMA_6_S { get; set; }
        public short AMA_6_B { get; set; }
        public short AMA_5_G { get; set; }
        public short AMA_5_S { get; set; }
        public short AMA_5_B { get; set; }
        public short AMA_4_G { get; set; }
        public short AMA_4_S { get; set; }
        public short AMA_4_B { get; set; }
        public short AMA_3_G { get; set; }
        public short AMA_3_S { get; set; }
        public short AMA_3_B { get; set; }
        public short AMA_2_G { get; set; }
        public short AMA_2_S { get; set; }
        public short AMA_2_B { get; set; }
        public short AMA_1_G { get; set; }
        public short AMA_1_S { get; set; }
        public short AMA_1_B { get; set; }
        public short PRO_1_G { get; set; }
        public short PRO_1_S { get; set; }
        public short PRO_1_B { get; set; }
        public short PRO_2_G { get; set; }
        public short PRO_2_S { get; set; }
        public short PRO_2_B { get; set; }
        public short PRO_3_G { get; set; }
        public short PRO_3_S { get; set; }
        public short PRO_3_B { get; set; }
        public short PRO_4_G { get; set; }
        public short PRO_4_S { get; set; }
        public short PRO_4_B { get; set; }
        public short PRO_5_G { get; set; }
        public short PRO_5_S { get; set; }
        public short PRO_5_B { get; set; }
        public short PRO_6_G { get; set; }
        public short PRO_6_S { get; set; }
        public short PRO_6_B { get; set; }
        public short PRO_7_G { get; set; }
        public short PRO_7_S { get; set; }
        public short PRO_7_B { get; set; }
    }
}
