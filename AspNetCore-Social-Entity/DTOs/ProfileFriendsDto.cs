using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Entity.DTOs
{
    public class ProfileFriendsDto
    {
        public List<FriendsDto> friends { get; set; }
        public  List<FriendRequestDto> friendRequests { get; set; }

    }
}
