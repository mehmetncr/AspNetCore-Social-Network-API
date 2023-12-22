using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Entity.Entities
{
    public class MessageInfo
    {
        public int MessageInfoId { get; set; }
        public int MessageInfoOwnerUserId { get; set; } 
        public DateTime MessageInfoCreateDate { get; set; }
        public string MessageInfoContent { get; set; }
        public int MessageInfoMessageId { get; set; }
        public int MessageInfoUserId { get; set; }
        public virtual User MessageInfoOwnerUser { get; set; }
    }
}
