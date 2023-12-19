using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Entity.Entities
{
    public class SocialMediaAccount
    {
        public int SocialMediaAccountId { get; set; }
        public int SocialMediaAccountUserId { get; set; }
        public string SocialMediaAccountName { get; set; }
        public string SocialMediaAccountUrl { get; set; }


    }
}
