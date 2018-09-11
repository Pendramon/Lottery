using Pendramon.Lottery.View.Model;
using System.Collections.Generic;

namespace Pendramon.Lottery.Service.Interfaces
{
    public interface ILotteryService
    {
        AwardModel CheckCode(UserCodeModel userCode);

        List<UserCodeAwardModel> GetAllWinners();
    }
}
