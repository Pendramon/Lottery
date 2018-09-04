using Pendramon.Lottery.Data.Model.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pendramon.Lottery.Data.Model
{
    [Table("UserCodeAwards")]
    public class UserCodeAward : IEntity
    {

        #region Primary Key

        [Key]
        [Column("UserCodeAwardID", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        #endregion

        #region ForeignKeys

        [Column("UserCodeID")]
        public int UserCodeId { get; set; }

        [Column("AwardID")]
        public int AwardId { get; set; }

        #endregion

        #region Public Properties

        public UserCode UserCode { get; set; }

        public Award Award { get; set; }

        public DateTime WonAt { get; set; }

        #endregion

    }
}
