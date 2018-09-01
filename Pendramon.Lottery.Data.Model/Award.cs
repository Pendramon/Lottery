using Pendramon.Lottery.Data.Model.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pendramon.Lottery.Data.Model
{
    [Table("Awards")]
    public class Award : IEntity
    {
        [Key]
        [Column("AwardID", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string AwardName { get; set; }

        public string AwardDescription { get; set; }

        public byte RuffledType { get; set; } // Enum values: Imediate/PerDay/Final

        public int Quantity { get; set; }
    }
}