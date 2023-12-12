using AspNetCore_Social_Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Entity.DTOs
{
	public class MessageDto
	{
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OwnerUserId { get; set; }
        public UserDto User { get; set; }
        public List<MessageDetailDto> MessageDetails { get; set; }
    }
}
