using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Entity.Entities
{
    public class Friends
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FriendsUserId { get; set; }

        public virtual User User { get; set; }
    }
}
