using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.DB.Models
{
    [Table("account", Schema = "pangya")]
    public class AccountModel
    {
        public string ID { get; set; }
        public long UID { get; set; }
        public string PASSWORD { get; set; }
        public long IDState { get; set; }
        public Nullable<System.DateTime> LastLogonTime { get; set; }
        public int BlockTime { get; set; }
        public short Logon { get; set; }
        public short FIRST_LOGIN { get; set; }
        public Nullable<System.DateTime> RegDate { get; set; }
        public string NICK { get; set; }
        public short FIRST_SET { get; set; }
        public int Guild_UID { get; set; }
        public short Sex { get; set; }
        public short doTutorial { get; set; }
        public string UserName { get; set; }
        public string UserIp { get; set; }
        public string ServerID { get; set; }
        public string game_server_id { get; set; }
        public Nullable<System.DateTime> LastLeaveTime { get; set; }
        public long LogonCount { get; set; }
        public Nullable<System.DateTime> BlockRegDate { get; set; }
        public int School { get; set; }
        public int capability { get; set; }
        public short Event { get; set; }
        public short MannerFlag { get; set; }
        public int domainid { get; set; }
        public short ChannelFlag { get; set; }
        public Nullable<System.DateTime> change_nick { get; set; }

        internal SqlDataReader ExecuteReader()
        {
            throw new NotImplementedException();
        }
    }
}
