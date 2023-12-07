using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Entity.Entities
{
    public class Friends
    {
        public int FriendsId { get; set; }
        public int FriendsUserId { get; set; }
        public int FriendId { get; set; }

        public virtual User Friend { get; set; }
	}
}
