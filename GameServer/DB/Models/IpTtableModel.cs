using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.DB.Models
{
    [Table("pangya_ip_table", Schema = "pangya")]
    [Keyless]
    public class IpTtableModel
    {
        public long index { get; set; }
        public string ip { get; set; }
        public string mask { get; set; }
        public System.DateTime date { get; set; }
    }
}
