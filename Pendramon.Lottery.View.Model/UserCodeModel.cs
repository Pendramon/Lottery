namespace Pendramon.Lottery.View.Model
{
    public class UserCodeModel
    {

        #region Public Properties

        public CodeModel Code { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        #endregion

        #region Constructor

        public UserCodeModel()
        {
            this.Code = new CodeModel();
        }

        #endregion

    }
}
