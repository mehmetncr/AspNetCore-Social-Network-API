using AspNetCore_Social_Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Entity.DTOs
{
    public class MessageDetailDto
    {
        public int Id { get; set; }
        public int OwnerUserId { get; set; }
        public DateTime SendDate { get; set; }
        public string MessageContent { get; set; }
        public int MessageId { get; set; }

    }
}
