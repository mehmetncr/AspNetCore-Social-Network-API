using AspNetCore_Social_Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Entity.DTOs
{
    public class FriendRequestDto
    {
        public int FriendReqid { get; set; }
        public DateTime FriendReqCreatedDate { get; set; }
        public bool FriendReqStatus { get; set; }
        public int FriendReqUserId { get; set; }
        public int FriendReqFriendReqSenderid { get; set; }
        public UserDto FriendReqFriendReqSender { get; set; }
    }
}
