using System;

namespace Pendramon.Lottery.View.Model
{
    public class UserCodeAwardModel
    {

        #region Constructor

        public UserCodeAwardModel()
        {
            UserCode = new UserCodeModel();
            Award = new AwardModel();
        }

        #endregion

        #region Public Properties

        public UserCodeModel UserCode { get; set; }

        public AwardModel Award { get; set; }

        public DateTime WonAt { get; set; }

        #endregion

    }
}
