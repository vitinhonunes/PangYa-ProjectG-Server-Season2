using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.DB.Models
{
    [Table("pangya_caddie_information", Schema = "pangya")]
    [Keyless]
    public class Caddie_InformationModel
    {
        public int item_id { get; set; }
        public long UID { get; set; }
        public int typeid { get; set; }
        public int parts_typeid { get; set; }
        public short gift_flag { get; set; }
        public short cLevel { get; set; }
        public int Exp { get; set; }
        public System.DateTime RegDate { get; set; }
        public short Period { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public short RentFlag { get; set; }
        public short Purchase { get; set; }
        public Nullable<System.DateTime> parts_EndDate { get; set; }
        public short CheckEnd { get; set; }
        public short Valid { get; set; }
    }
}
