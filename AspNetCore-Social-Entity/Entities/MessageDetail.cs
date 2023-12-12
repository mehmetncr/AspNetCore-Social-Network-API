using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Entity.Entities
{
    public class MessageDetail
    {
        public int Id { get; set; }
        public int OwnerUserId { get; set; }
        public DateTime SendDate { get; set; }
        public string MessageContent { get; set; }
        public int MessageId { get; set; }
        public Message Message { get; set; }

    }
}
