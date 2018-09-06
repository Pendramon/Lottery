using Pendramon.Lottery.Data;
using Pendramon.Lottery.Data.Model;
using Pendramon.Lottery.Data.Model.Enums;
using Pendramon.Lottery.Service.Interfaces;
using Pendramon.Lottery.View.Model;
using System;
using System.Data.Entity;
using System.Linq;

namespace Pendramon.Lottery.Service
{
    public class LotteryServiceV0 : ILotteryService
    {

        #region Public Methods

        /// <summary>
        /// Checks if a code is a winner and registers code in database for future ruffles
        /// </summary>
        /// <param name="userCodeModel"></param>
        /// <returns></returns>
        public AwardModel CheckCode(UserCodeModel userCodeModel)
        {
            var codeRepository = new Repository<Code>(new DbContext("LotteryDb"));

            var code = codeRepository.GetAll().FirstOrDefault(x => x.CodeValue == userCodeModel.Code.CodeValue);

            if (code == null)
            {
                throw new ApplicationException("Invalid code.");
            }

            if (code.IsUsed)
            {
                throw new ApplicationException("Code is used.");
            }

            var userCode = new UserCode
            {
                Code = code,
                Email = userCodeModel.Email,
                FirstName = userCodeModel.FirstName,
                LastName = userCodeModel.LastName,
                SentAt = DateTime.Now
            };

            var userCodeRepository = new Repository<UserCode>(new DbContext("LotteryDb"));
            userCodeRepository.Insert(userCode);

            Award award = new Award()
            {
                RuffledType = (byte)RuffledType.Immediate,
                AwardName = "Another 0.5 Bottle",
                Quantity = 1
            };

            var userCodeAward = new UserCodeAward
            {
                Award = award,
                UserCode = userCode,
                WonAt = DateTime.Now
            };

            var userCodeAwardRepository = new Repository<UserCodeAward>(new DbContext("LotteryDb"));
            userCodeAwardRepository.Insert(userCodeAward);

            code.IsUsed = true;

            return new AwardModel() {
                AwardName = award.AwardName,
                AwardDescription = award.AwardDescription
            };
        
        }

        #endregion

    }
}
