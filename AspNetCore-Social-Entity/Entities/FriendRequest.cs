using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Entity.Entities
{
    public class FriendRequest
    {
        [Key]
        public int FriendReqId { get; set; }
        public DateTime FriendReqCreatedDate { get; set; }
        public bool FriendReqStatus { get; set; }
        public int FriendReqUserId { get; set; }
        public int FriendReqFriendReqSenderId { get; set; }
        public User FriendReqFriendReqSender { get; set; }
    }
}
