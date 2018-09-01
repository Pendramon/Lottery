

namespace Pendramon.Lottery.Data.Model
{
    public class Code
    {
        public int CodeID { get; set; }

        public string CodeKey { get; set; }

        public bool IsWinning { get; set; }

        public bool IsUsed { get; set; }
    }
}
