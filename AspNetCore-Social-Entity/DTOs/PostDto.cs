using AspNetCore_Social_Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Entity.DTOs
{
	public class PostDto
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public DateTime CreateDate { get; set; }
		public string TextContent { get; set; }
		public string ImageUrl { get; set; }
		public string VideoUrl { get; set; }
		public string YoutubeUrl { get; set; }
		public int CommentNumber { get; set; }
		public int LikeNumber { get; set; }
		public int DislikeNumber { get; set; }
		public string PostLink { get; set; }
		public string PostType { get; set; }
		public virtual List<CommentDto> CommentsDto { get; set; }
		public virtual UserDto UserDto { get; set; }
	}
}
