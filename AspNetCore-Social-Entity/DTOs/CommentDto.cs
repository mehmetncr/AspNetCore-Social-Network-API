
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Entity.DTOs
{
	public class CommentDto
	{
		public int Id { get; set; }
		public DateTime CommentDate { get; set; }
		public string Content { get; set; }

		
		public int UserId { get; set; }
		//public virtual UserDto User { get; set; }
	
		public int PostId { get; set; }
		//public virtual PostDto Post { get; set; }
		public List<ReplyCommentDto> ReplyComments { get; set; }
	}
}
