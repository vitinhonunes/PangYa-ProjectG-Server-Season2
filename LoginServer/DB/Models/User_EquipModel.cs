using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.DB.Models
{
    [Table("pangya_user_equip", Schema = "pangya")]
    [Keyless]
    public class User_EquipModel
    {
        public int UID { get; set; }
        public int caddie_id { get; set; }
        public int character_id { get; set; }
        public int club_id { get; set; }
        public int ball_type { get; set; }
        public int item_slot_1 { get; set; }
        public int item_slot_2 { get; set; }
        public int item_slot_3 { get; set; }
        public int item_slot_4 { get; set; }
        public int item_slot_5 { get; set; }
        public int item_slot_6 { get; set; }
        public int item_slot_7 { get; set; }
        public int item_slot_8 { get; set; }
        public int item_slot_9 { get; set; }
        public int item_slot_10 { get; set; }
        public int Skin_1 { get; set; }
        public int Skin_2 { get; set; }
        public int Skin_3 { get; set; }
        public int Skin_4 { get; set; }
        public int Skin_5 { get; set; }
        public int Skin_6 { get; set; }

    }
}
