﻿using AspNetCore_Social_Entity.Entities;
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
		public int FriendsUserId { get; set; }
        public string FriendsStatus { get; set; }
        public int FriendId { get; set; }
		public virtual UserDto Friend { get; set; }
	}
}
