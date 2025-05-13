using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.DB.Models
{
    [Table("pangya_cookie_point_log", Schema = "pangya")]
    [Keyless]
    public class Cookie_Point_LogModel
    {
        public long id { get; set; }
        public Nullable<int> uid { get; set; }
        public Nullable<byte> type { get; set; }
        public Nullable<int> mail_id { get; set; }
        public Nullable<long> cookie { get; set; }
        public Nullable<int> item_qnty { get; set; }
        public System.DateTime reg_date { get; set; }
    }
}
