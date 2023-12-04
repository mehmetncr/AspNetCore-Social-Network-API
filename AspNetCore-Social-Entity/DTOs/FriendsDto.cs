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
		public int Id { get; set; }
		public int UserDtoId { get; set; }
		public int FriendsUserId { get; set; }

		public virtual UserDto UserDto { get; set; }
	}
}
