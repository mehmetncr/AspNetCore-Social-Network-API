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
		public int Id { get; set; }
		public int UserDtoId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public virtual UserDto UserDto { get; set; }
	}
}
