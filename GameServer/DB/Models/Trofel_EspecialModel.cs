using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.DB.Models
{
    [Table("pangya_trofel_especial", Schema = "pangya")]
    [Keyless]
    public class Trofel_EspecialModel
    {
        public long item_id { get; set; }
        public int UID { get; set; }
        public int typeid { get; set; }
        public int qntd { get; set; }
    }
}
