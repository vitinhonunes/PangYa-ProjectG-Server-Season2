using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.DB.Models
{
    [Table("user_info", Schema = "pangya")]
    [Keyless]
    public class User_InfoModel
    {
        public long UID { get; set; }
        public long Tacadas { get; set; }
        public long Putt { get; set; }
        public long Tempo { get; set; }
        public long Tempo_tacadas { get; set; }
        public float Max_distancia { get; set; }
        public long Acerto_pangya { get; set; }
        public int Bunker { get; set; }
        public long O_B { get; set; }
        public long Total_distancia { get; set; }
        public long Holes { get; set; }
        public int Holein { get; set; }
        public long HIO { get; set; }
        public short Timeout { get; set; }
        public long Fairway { get; set; }
        public long Albatross { get; set; }
        public int MaConduta { get; set; }
        public long Acerto_Putt { get; set; }
        public float Long_putt { get; set; }
        public float Chip_in { get; set; }
        public long Xp { get; set; }
        public byte level { get; set; }
        public decimal Pang { get; set; }
        public int Media_score { get; set; }
        public short BestScore0 { get; set; }
        public short BestScore1 { get; set; }
        public short BestScore2 { get; set; }
        public short BestScore3 { get; set; }
        public short BestScore4 { get; set; }
        public long MaxPang0 { get; set; }
        public long maxPang1 { get; set; }
        public long maxPang2 { get; set; }
        public long maxPang3 { get; set; }
        public long maxPang4 { get; set; }
        public long SumPang { get; set; }
        public short EventFlag { get; set; }
        public long Jogado { get; set; }
        public long Quitado { get; set; }
        public long SkinPang { get; set; }
        public int SkinWin { get; set; }
        public int SkinLose { get; set; }
        public int SkinRunHole { get; set; }
        public int SkinStrikePoint { get; set; }
        public int SkinAllinCount { get; set; }
        public long Todos_combos { get; set; }
        public long Combos { get; set; }
        public int TeamWin { get; set; }
        public int TeamGames { get; set; }
        public long Teamhole { get; set; }
        public int LadderPoint { get; set; }
        public int LadderWin { get; set; }
        public int LadderLose { get; set; }
        public int LadderDraw { get; set; }
        public int LadderHole { get; set; }
        public short EventValue { get; set; }
        public int NaoSei { get; set; }
        public int MaxJogoNaoSei { get; set; }
        public int JogosNaoSei { get; set; }
        public int GameCountSeason { get; set; }
        public decimal Cookie { get; set; }
        public long total_pang_win_game { get; set; }
        public int lucky_medal { get; set; }
        public int fast_medal { get; set; }
        public int best_drive_medal { get; set; }
        public int best_chipin_medal { get; set; }
        public int best_puttin_medal { get; set; }
        public int best_recovery_medal { get; set; }
        public short C16bit_naosei { get; set; }
    }
}
