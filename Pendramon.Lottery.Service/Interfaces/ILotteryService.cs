using Pendramon.Lottery.View.Model;

namespace Pendramon.Lottery.Service.Interfaces
{
    public interface ILotteryService
    {
        AwardModel CheckCode(UserCodeModel userCode);
    }
}
