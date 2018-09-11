using Pendramon.Lottery.Data;
using Pendramon.Lottery.Data.Model;
using Pendramon.Lottery.Data.Model.Enums;
using Pendramon.Lottery.Mapper;
using Pendramon.Lottery.Service.Interfaces;
using Pendramon.Lottery.Service.UoW;
using Pendramon.Lottery.View.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Pendramon.Lottery.Service
{
    public class LotteryService : ILotteryService
    {

        #region Private Members

        private readonly DbContext dbContext;
        private readonly IRepository<Code> codeRepository;
        private readonly IRepository<Award> awardRepository;
        private readonly IRepository<UserCode> userCodeRepository;
        private readonly IRepository<UserCodeAward> userCodeAwardRepository;

        #endregion

        #region Constructor

        public LotteryService(IRepository<Code> codeRepository, IRepository<Award> awardRepository, IRepository<UserCode> userCodeRepository, IRepository<UserCodeAward> userCodeAwardRepository, DbContext dbContext)
        {
            this.codeRepository = codeRepository;
            this.awardRepository = awardRepository;
            this.userCodeRepository = userCodeRepository;
            this.userCodeAwardRepository = userCodeAwardRepository;
            this.dbContext = dbContext;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Checks if a code is a winner and registers code in database for future ruffles
        /// </summary>
        /// <param name="userCodeModel"></param>
        /// <returns></returns>
        public AwardModel CheckCode(UserCodeModel userCodeModel)
        { 
            using (var unitOfWork = new UnitOfWork(dbContext))
            {            
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

                userCodeRepository.Insert(userCode);

                Award award = null;

                if (code.IsWinning)
                {
                    award = GetRandomAward(RuffledType.Immediate);

                    var userCodeAward = new UserCodeAward
                    {
                        Award = award,
                        UserCode = userCode,
                        WonAt = DateTime.Now
                    };

                    userCodeAwardRepository.Insert(userCodeAward);
                }

                code.IsUsed = true;

                unitOfWork.Commit();

                return award?.Map<Award, AwardModel>();
            }
        }

        public List<UserCodeAwardModel> GetAllWinners()
        {
            using (UnitOfWork uow = new UnitOfWork(dbContext))
            {
                var winners = userCodeAwardRepository.GetAll().Include(x => x.UserCode.Code).Include(x => x.Award).ToList();

                return winners.Select(x => x.Map<UserCodeAward, UserCodeAwardModel>()).ToList();
            }
        }

        #endregion

        #region Private Methods

        private Award GetRandomAward(RuffledType type)
        {
            var awards = awardRepository.GetAll().Where(x => x.RuffledType == (byte)type).ToList();
            var awardedAwards = userCodeAwardRepository.GetAll().Where(x => x.Award.RuffledType == (byte)type).Select(x => x.Award).GroupBy(x => x.Id).ToList();

            var availableAwards = new List<Award>();

            foreach (var award in awards)
            {
                var numberOfAwardedAwards = awardedAwards.FirstOrDefault(x => x.Key == award.Id)?.Count() ?? 0;
                var awardsLeft = award.Quantity - numberOfAwardedAwards;
                availableAwards.AddRange(Enumerable.Repeat(award, awardsLeft));
            }

            if (availableAwards.Count == 0)
                throw new ApplicationException("We are out of awards. Sorry!");

            var rnd = new Random();

            var randomAwardIndex = rnd.Next(0, availableAwards.Count);

            return availableAwards[randomAwardIndex];
        }

        #endregion
    }
}
