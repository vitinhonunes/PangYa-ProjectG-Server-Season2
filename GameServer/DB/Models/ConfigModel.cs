using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.DB.Models
{
    [Table("pangya_config", Schema = "pangya")]
    [Keyless]
    public class ConfigModel
    {
        public int UID { get; set; }
        public short PangRate { get; set; }
        public short ExpRate { get; set; }
        public short ChuvaRate { get; set; }
        public short AngelEvent { get; set; }

    }
}
