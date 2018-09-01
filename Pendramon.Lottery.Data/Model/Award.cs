using Pendramon.Lottery.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pendramon.Lottery.Data.Model
{
    public class Award : IAward
    {
        public int AwardID { get; set; }

        public string AwardName { get; set; }

        public string AwardDescription { get; set; }

        public byte AwardType { get; set; }

        public int Quantity { get; set; }
    }
}