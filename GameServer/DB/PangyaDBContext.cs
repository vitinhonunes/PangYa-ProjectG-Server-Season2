using GameServer.DB.Models;
using Microsoft.EntityFrameworkCore;

namespace Pangya.DB
{
    public class PangyaDBContext : DbContext
    {
        //public PangyaDBContext(DbContextOptions<PangyaDBContext> options)
        //    : base(options)
        //{
            
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DEEJHAYVN\\SQLEXPRESS;Initial Catalog=pangya_s2;User ID=sa;Password=123456;TrustServerCertificate=True;");
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }


        public DbSet<AccountModel> Account { get; set; }
        public DbSet<Caddie_InformationModel> pangya_caddie_information { get; set; }
        public DbSet<Character_InformationModel> pangya_character_information { get; set; }
        public DbSet<Character_Part_PadraoModel> pangya_character_part_padrao { get; set; }
        public DbSet<CommandModel> pangya_command { get; set; }
        public DbSet<IpTtableModel> pangya_ip_table { get; set; }
        public DbSet<Item_WarehouseModel> pangya_item_warehouse { get; set; }
        public DbSet<Msg_UserModel> pangya_msg_user { get; set; }
        public DbSet<Notice_ListModel> pangya_notice_list { get; set; }
        public DbSet<Parts_ListModel> pangya_parts_list { get; set; }
        public DbSet<Player_IpModel> pangya_player_ip { get; set; }
        public DbSet<Rank_AntesModel> pangya_rank_antes { get; set; }
        public DbSet<Rank_AtualModel> pangya_rank_atual { get; set; }
        public DbSet<Rank_Atual_CharacterModel> pangya_rank_atual_character { get; set; }
        public DbSet<Rank_ConfigModel> pangya_rank_config { get; set; }
        public DbSet<Trofel_EspecialModel> pangya_trofel_especial { get; set; }
        public DbSet<User_EquipModel> pangya_user_equip { get; set; }
        public DbSet<Char_Equip_s4Model> td_char_equip_s4 { get; set; }
        public DbSet<Trofel_StatModel> trofel_stat { get; set; }
        public DbSet<TutorialModel> tutorials { get; set; }
        public DbSet<User_InfoModel> user_info { get; set; }
        public DbSet<ConfigModel> pangya_config { get; set; }
        public DbSet<Cookie_Point_Item_LogModel> pangya_cookie_point_item_log { get; set; }
        public DbSet<Cookie_Point_LogModel> pangya_cookie_point_log { get; set; }
        public DbSet<Friend_ListModel> pangya_friend_list { get; set; }
        public DbSet<Item_BuffModel> pangya_item_buff { get; set; }
        public DbSet<Item_MailModel> pangya_item_mail { get; set; }
        public DbSet<Mac_TableModel> pangya_mac_table { get; set; }
        public DbSet<Player_LocationModel> pangya_player_location { get; set; }
        public DbSet<RecordModel> pangya_record { get; set; }
        public DbSet<Server_ListModel> pangya_server_list { get; set; }
        public DbSet<User_MacroModel> pangya_user_macro { get; set; }

    }

}
