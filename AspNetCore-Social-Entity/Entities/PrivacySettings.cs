using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Entity.Entities
{
    public class PrivacySettings
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool FriendRequest { get; set; }
        public bool MessageRequest { get; set; }
        public bool HiddenProfile { get; set; }

        public List<User> Users { get; set; }
    }
}
