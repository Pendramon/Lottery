using Pendramon.Lottery.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pendramon.Lottery.Data.Model
{
    public class Code : ICode
    {
        public int CodeID { get; set; }

        public string CodeKey { get; set; }

        public bool IsWinning { get; set; }

        public bool IsUsed { get; set; }
    }
}
