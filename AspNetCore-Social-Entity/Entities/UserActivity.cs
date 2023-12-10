using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Entity.Entities
{
    public class UserActivity
    {
        public int UserActivityId { get; set; }
        public DateTime UserActivityDate { get; set; }
        public string UserActivityName { get; set; }


        public int UserId { get; set; }

    }
}
