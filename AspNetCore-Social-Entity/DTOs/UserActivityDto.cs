using AspNetCore_Social_Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Entity.DTOs
{
	public class UserActivityDto
	{
		public int UserActivityId { get; set; }
		public DateTime UserActivityDate { get; set; }
		public string UserActivityName { get; set; }


		public int UserActivityUserDtoId { get; set; }
		public virtual UserDto UserActivityUserDto { get; set; }
	}
}
