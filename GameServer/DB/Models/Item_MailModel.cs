using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.DB.Models
{
    [Table("pangya_item_mail", Schema = "pangya")]
    [Keyless]
    public class Item_MailModel
    {
        public int Msg_ID { get; set; }
        public int item_id { get; set; }
        public int item_typeid { get; set; }
        public short Flag { get; set; }
        public Nullable<System.DateTime> GET_DATE { get; set; }
        public int Quantidade_item { get; set; }
        public int Quantidade_Dia { get; set; }
        public long Pang { get; set; }
        public long Cookie { get; set; }
        public int GM_ID { get; set; }
        public int Flag_Gift { get; set; }
        public string UCC_IMG_MARK { get; set; }
        public short Type { get; set; }
        public short valid { get; set; }



    }
}
