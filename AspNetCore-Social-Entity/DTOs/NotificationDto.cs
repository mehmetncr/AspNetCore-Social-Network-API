using AspNetCore_Social_Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Entity.DTOs
{
	public class NotificationDto
	{
		public int NotificationId { get; set; }
		public int NotificationUserDtoId { get; set; }
		public string NotificationTitle { get; set; }
		public string NotificationDescription { get; set; }
		public virtual UserDto NotificationUserDto { get; set; }
	}
}
