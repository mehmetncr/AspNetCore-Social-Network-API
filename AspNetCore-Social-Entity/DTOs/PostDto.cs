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
		public int PostId { get; set; }
		public int PostUserId { get; set; }
		public DateTime PostCreateDate { get; set; }
		public string PostTextContent { get; set; }
		public string PostImageUrl { get; set; }
		public string PostVideoUrl { get; set; }
		public string PostYoutubeUrl { get; set; }
		public int PostCommentNumber { get; set; }
		public int PostLikeNumber { get; set; }
		public int PostDislikeNumber { get; set; }
		public string PostLink { get; set; }
		public string PostType { get; set; }

		public virtual List<CommentDto> CommentsDto { get; set; }
		public virtual UserDto PostUserDto { get; set; }

	}
}
