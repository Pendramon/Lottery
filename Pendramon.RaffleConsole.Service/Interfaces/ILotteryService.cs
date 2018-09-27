using Pendramon.RaffleConsole.Data.Model.Enums;

namespace Pendramon.RaffleConsole.Service.Interfaces
{
    public interface ILotteryService
    {
        void GiveAwards(RaffledType type);
    }
}
