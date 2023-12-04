using AspNetCore_Social_Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Entity.DTOs
{
	public class ReplyCommentDto
	{
		public int Id { get; set; }
		public DateTime CommentDate { get; set; }
		public string Content { get; set; }


		public int UserDtoId { get; set; }
		public virtual UserDto UserDto { get; set; }

		public int CommentDtoId { get; set; }
		public virtual CommentDto CommentDto { get; set; }
	}
}
