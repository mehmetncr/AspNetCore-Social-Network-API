using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Entity.Entities
{
	public  class Message
	{
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OwnerUserId { get; set; }    
        public User User { get; set; }
        public List<MessageDetail> MessageDetails { get; set; }
    }
}
