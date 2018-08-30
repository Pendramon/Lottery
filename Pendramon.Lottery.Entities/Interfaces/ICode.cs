using System;
using System.Collections.Generic;
using System.Text;

namespace Pendramon.Lottery.Entities.Interfaces
{
    public interface ICode
    {
        int CodeID { get; }
        string CodeKey { get; }
        bool IsUsed { get; }
    }
}
