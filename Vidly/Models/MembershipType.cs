using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MembershipType
    {

        public byte Id { get; set; }

        public string membershipName { get; set; }
        public short signupFee { get; set; }
        public byte durationInMonths { get; set; }
        public byte DiscountRate { get; set; }


        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;


    }
}