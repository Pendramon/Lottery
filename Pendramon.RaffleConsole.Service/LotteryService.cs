using Microsoft.EntityFrameworkCore;
using Pendramon.RaffleConsole.Data;
using Pendramon.RaffleConsole.Data.Model;
using Pendramon.RaffleConsole.Data.Model.Enums;
using Pendramon.RaffleConsole.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Pendramon.RaffleConsole.Service
{
    public class LotteryService : ILotteryService 
    {

        #region Private Members

        private readonly IRepository<Award> awardRepository;
        private readonly IRepository<UserCodeAward> userCodeAwardRepository;
        private readonly IRepository<UserCode> userCodeRepository;

        #endregion

        #region Constructor

        public LotteryService(IRepository<Award> awardRepository, IRepository<UserCodeAward> userCodeAwardRepository, IRepository<UserCode> userCodeRepository)
        {
            this.awardRepository = awardRepository;
            this.userCodeAwardRepository = userCodeAwardRepository;
            this.userCodeRepository = userCodeRepository;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gives out a single award depending on the raffle type as long as it is not of type Immediate
        /// </summary>
        /// <param name="type"></param>
        private void GiveAward(RaffledType type)
        {
            if (type == RaffledType.Immediate)
                throw new ApplicationException("Cannot pass awards of immediate raffle");
            
            // Gets all user codes which are not winning
            var users = this.userCodeRepository.GetAll().Include(x => x.Code).Where(x => !x.Code.IsWinning);

            if (type == RaffledType.PerDay)
            {   
                // If per raffle type is per day get all user codes which are sent that day.
                users = users.Where(x => x.SentAt == DateTime.Now.Date);
            }

            var usersList = users.ToList();

            var userCodeAwards = this.userCodeAwardRepository.GetAll();
            
            // Checks if any of the users have won an award already, if so disqualify them 
            usersList = usersList.Where(x => userCodeAwards.All(y => y.UserCodeId != x.Id)).ToList();

            if (!usersList.Any()) return;

            // TODO: Get random user from list above
            var rnd = new Random();

            var winner = usersList[rnd.Next(0, usersList.Count - 1)];
            // TODO: Get random award per type
            var award = GetRandomAward(type);
            // TODO: Match user with award
            var userCodeAward = new UserCodeAward
            {
                Award = award,
                UserCode = winner,
                WonAt = DateTime.Now
            };
            
            userCodeAwardRepository.Insert(userCodeAward);
        }

        /// <summary>
        /// Gives out all awards specified for defined raffle as long as it is not of type Immediate
        /// </summary>
        /// <param name="type"></param>
        public void GiveAwards(RaffledType type)
        {
            if (type == RaffledType.Immediate)
                throw new ApplicationException("Cannot pass awards of immediate raffle");

            var awards = awardRepository.GetAll().Where(x => x.RuffledType == (byte)type);

            var quantityOfAwards = awards.Select(x => x.Quantity).Sum();

            for (int i = 0; i < quantityOfAwards; i++)
            {
                GiveAward(type);
            }

        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Returns a random award based on the specified raffle type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private Award GetRandomAward(RaffledType type)
        {
            var awards = awardRepository.GetAll().Where(x => x.RuffledType == (byte)type).ToList();

            var awardedAwards = userCodeAwardRepository.GetAll().Where(x => x.Award.RuffledType == (byte)type);

            if (type == RaffledType.PerDay)
            {
                awardedAwards = awardedAwards.Where(x => x.WonAt.Date == DateTime.Now.Date);
            }

            var awardedAwardsGroup = awardedAwards.Select(x => x.Award).GroupBy(x => x.Id).ToList();

            var availableAwards = new List<Award>();

            foreach (var award in awards)
            {
                var numberOfAwardedAwards = awardedAwardsGroup.FirstOrDefault(x => x.Key == award.Id)?.Count() ?? 0;
                var awardsLeft = award.Quantity - numberOfAwardedAwards;
                availableAwards.AddRange(Enumerable.Repeat(award, awardsLeft));
            }

            if (availableAwards.Count == 0)
                throw new ApplicationException("We are out of awards. Sorry!");

            var rnd = new Random();

            var randomAwardIndex = rnd.Next(0, availableAwards.Count - 1);

            return availableAwards[randomAwardIndex];
        }

        #endregion

    }
}
