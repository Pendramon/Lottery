using Pendramon.Lottery.Data.Model.Interfaces;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pendramon.Lottery.Data.Model
{
    [Table("Codes")]
    public class Code : IEntity
    {

        #region Primary Key

        [Key]
        [Column("CodeID", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        #endregion

        #region Public Properties

        public string CodeValue { get; set; }

        public bool IsWinning { get; set; }

        [DefaultValue(false)]
        public bool IsUsed { get; set; }

        #endregion

    }
}
