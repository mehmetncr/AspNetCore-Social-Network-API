using AspNetCore_Social_Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Entity.DTOs
{
	public class FriendsDto
	{
		public int FriendsId { get; set; }
		public int FriendsUserDtoId { get; set; }
		public int FriendsFriendsUserId { get; set; }

		public virtual UserDto FriendsUserDto { get; set; }
	}
}
