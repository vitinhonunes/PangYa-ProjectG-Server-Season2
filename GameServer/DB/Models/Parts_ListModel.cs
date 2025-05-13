using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.DB.Models
{
    [Table("pangya_parts_list", Schema = "pangya")]
    [Keyless]
    public class Parts_ListModel
    {
        public long index { get; set; }
        public int typeid { get; set; }
        public int tipo { get; set; }
        public int equip_flag { get; set; }

    }
}
