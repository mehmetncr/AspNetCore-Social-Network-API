using AspNetCore_Social_Entity.DTOs;
using AspNetCore_Social_Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Entity.Services
{
	public interface IPostService
	{
		Task AddPost(NewPostDto model);
		Task AddComment(NewCommentDto model);
        public Task<List<PostDto>> GetAllPostsWithUserId(int userId);
		Task<List<PostDto>> GetPosts(int userId, string storeProcName);
		Task<PostDto> GetPostById(int postId);
		void UpdatePost(PostDto model);
	}
}
