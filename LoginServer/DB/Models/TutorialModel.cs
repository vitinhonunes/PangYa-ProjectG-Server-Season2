using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.DB.Models
{
    [Table("tutorial", Schema = "pangya")]
    [Keyless]
    public class TutorialModel
    {
        public long UID { get; set; }
        public int Rookie { get; set; }
        public int Beginner { get; set; }
        public int Advancer { get; set; }
    }
}
