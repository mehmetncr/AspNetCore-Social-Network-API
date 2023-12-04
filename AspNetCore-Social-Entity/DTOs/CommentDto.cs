
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

		[ForeignKey("UserId")]
		public int UserDtoId { get; set; }
		public virtual UserDto UserDto { get; set; }
		[ForeignKey("PostId")]
		public int PostDtoId { get; set; }
		public virtual PostDto PostDto { get; set; }
	}
}
