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
		public int ReplyCommentId { get; set; }
		public DateTime ReplyCommentDate { get; set; }
		public string ReplyCommentContent { get; set; }


		public int ReplyCommentUserDtoId { get; set; }
		public virtual UserDto ReplyCommentUserDto { get; set; }

		public int ReplyCommentCommentDtoId { get; set; }
		public virtual CommentDto ReplyCommentCommentDto { get; set; }

	}
}
