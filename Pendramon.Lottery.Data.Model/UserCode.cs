﻿using Pendramon.Lottery.Data.Model.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pendramon.Lottery.Data.Model
{
    [Table("UserCodes")]
    public class UserCode : IEntity
    {

        #region Primary Key

        [Key]
        [Column("UserCodeID", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        #endregion

        #region Foreign Keys

        [Column("CodeID")]
        public int CodeId { get; set; }

        #endregion

        #region Public Properties

        public Code Code { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime SentAt { get; set; }

        #endregion

    }
}
