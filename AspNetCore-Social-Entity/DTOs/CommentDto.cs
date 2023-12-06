
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
		public int CommentId { get; set; }
        public DateTime CommentDate { get; set; }
        public string CommentContent { get; set; }


		[ForeignKey("UserId")]
		public int CommentUserDtoId { get; set; }
		public virtual UserDto CommentUserDto { get; set; }
		[ForeignKey("PostId")]
		public int CommentPostDtoId { get; set; }
		public virtual PostDto CommentPostDto { get; set; }

	}
}
