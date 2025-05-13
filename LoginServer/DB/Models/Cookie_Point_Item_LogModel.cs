using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.DB.Models
{
    [Table("pangya_cookie_point_item_log", Schema = "pangya")]
    [Keyless]
    public class Cookie_Point_Item_LogModel
    {
        public long index { get; set; }
        public Nullable<long> cp_id_log { get; set; }
        public Nullable<int> typeid { get; set; }
        public Nullable<int> qnty { get; set; }
        public Nullable<long> price { get; set; }

    }
}
