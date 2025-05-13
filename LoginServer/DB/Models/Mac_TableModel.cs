using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.DB.Models
{
    [Table("pangya_mac_table", Schema = "pangya")]
    [Keyless]
    public class Mac_TableModel
    {
        public long index { get; set; }
        public string mac { get; set; }
        public System.DateTime date { get; set; }

    }
}
