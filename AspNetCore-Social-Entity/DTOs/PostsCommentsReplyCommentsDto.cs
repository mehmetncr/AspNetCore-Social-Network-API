using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Entity.DTOs
{
	public class PostsCommentsReplyCommentsDto
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
		public int CommentId { get; set; }
		public DateTime CommentDate { get; set; }
		public string CommentContent { get; set; }
		public int CommentUserId { get; set; }
		public int CommentPostId { get; set; }
		public int ReplyCommentId { get; set; }
		public DateTime ReplyCommentDate { get; set; }
		public string ReplyCommentContent { get; set; }
		public int ReplyCommentUserId { get; set; }
		public int ReplyCommentCommentId { get; set; }
	}
}
