using System;
using System.Collections.Generic;
using System.Text;

namespace Pendramon.Lottery.Entities.Interfaces
{
    public interface IAward
    {
        int AwardID { get; }
        string AwardName { get; }
    }
}
