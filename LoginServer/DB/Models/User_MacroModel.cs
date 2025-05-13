using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.DB.Models
{
    [Table("pangya_user_macro", Schema = "pangya")]
    [Keyless]
    public class User_MacroModel
    {
        public int UID { get; set; }
        public string Macro1 { get; set; }
        public string Macro2 { get; set; }
        public string Macro3 { get; set; }
        public string Macro4 { get; set; }
        public string Macro5 { get; set; }
        public string Macro6 { get; set; }
        public string Macro7 { get; set; }
        public string Macro8 { get; set; }
        public string Macro9 { get; set; }
        public string Macro10 { get; set; }
    }
}
