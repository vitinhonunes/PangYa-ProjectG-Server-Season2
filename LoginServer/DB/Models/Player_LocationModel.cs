using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.DB.Models
{
    [Table("pangya_player_location", Schema = "pangya")]
    [Keyless]
    public class Player_LocationModel
    {
        public int UID { get; set; }
        public short channel { get; set; }
        public short lobby { get; set; }
        public short room { get; set; }
        public short place { get; set; }
    }
}
