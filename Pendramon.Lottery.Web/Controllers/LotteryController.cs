using Pendramon.Lottery.Service.Interfaces;
using Pendramon.Lottery.View.Model;
using System.Web.Http;

namespace Pendramon.Lottery.Web.Controllers
{
    public class LotteryController : ApiController
    {

        #region Private Members

        private readonly ILotteryService lotteryService;

        #endregion

        #region Constructor

        public LotteryController(ILotteryService lotteryService)
        {
            this.lotteryService = lotteryService;
        }   

        #endregion

        #region Public Methods

        [HttpPost]
        public AwardModel SubmitCode([FromBody] UserCodeModel userCodeModel)
        {
            return lotteryService.CheckCode(userCodeModel);
        }

        #endregion

    }
}
