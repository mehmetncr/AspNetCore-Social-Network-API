using AspNetCore_Social_DataAccess.Context;
using AspNetCore_Social_Entity.DTOs;
using AspNetCore_Social_Entity.Entities;
using AspNetCore_Social_Entity.Services;
using AspNetCore_Social_Entity.UnitOfWorks;
using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Service.Services
{


    public class PostService : IPostService
    {
        private readonly IUnitOfWork _uow;
        private readonly IFriendService _friendService;
        private readonly IMapper _mapper;
        private readonly SocialContext _socialContext;
        private readonly ICommentService _commentService;

        public PostService(IUnitOfWork uow, IFriendService friendService, IMapper mapper, SocialContext socialContext, ICommentService commentService)
        {
            _uow = uow;
            _friendService = friendService;
            _mapper = mapper;
            _socialContext = socialContext;
            _commentService = commentService;
        }


        public async Task<List<PostDto>> GetAllPostsWithUserId(int userId)
        {
            List<FriendsDto> friends = await _friendService.GetFriends(userId);
            FriendsDto user = new FriendsDto()
            {
                FriendsUserId = userId,
            };
            friends.Add(user);
            var list = await _uow.GetRepository<Post>().GetAll(x => friends.Select(f => f.FriendsUserId).Contains(x.PostUserId), x => x.OrderByDescending(x => x.PostCreateDate), x => x.Comments);
            return _mapper.Map<List<PostDto>>(list);
        }
        public async Task<List<PostDto>> GetPosts(int userId, string storeProcName)
        {       

            var userIdParameter = new SqlParameter("@userId", userId);
            var postCountParameter = new SqlParameter("@postCount", 100);

            using (DbConnection connection = _socialContext.Database.GetDbConnection())
            {
                connection.Open();

                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = storeProcName;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(userIdParameter);
                    command.Parameters.Add(postCountParameter);

                    using (DbDataReader reader = command.ExecuteReader())
                    {

                        if (reader.HasRows)
                        {
                            List<PostDto> posts = new List<PostDto>();
                            while (reader.Read())
                            {
                                int postId = reader.IsDBNull("PostId") ? default(int) : reader.GetInt32("PostId");

								// Check if the post already exists in the list
								PostDto existingPost = posts.FirstOrDefault(p => p.PostId == postId);

                                if (existingPost == null)
                                {
                                    // If the post doesn't exist, create a new post
                                    existingPost = new PostDto
									{
                                        PostId = postId,
                                        PostUserId = reader.IsDBNull("PostUserId") ? default(int) : reader.GetInt32("PostUserId"),
                                        PostCreateDate = reader.IsDBNull("PostCreateDate") ? default(DateTime) : reader.GetDateTime("PostCreateDate"),
                                        PostTextContent = reader.IsDBNull("PostTextContent") ? string.Empty : reader.GetString("PostTextContent"),
                                        PostImageUrl = reader.IsDBNull("PostImageUrl") ? string.Empty : reader.GetString("PostImageUrl"),
                                        PostVideoUrl = reader.IsDBNull("PostVideoUrl") ? string.Empty : reader.GetString("PostVideoUrl"),
                                        PostYoutubeUrl = reader.IsDBNull("PostYoutubeUrl") ? string.Empty : reader.GetString("PostYoutubeUrl"),
                                        PostCommentNumber = reader.IsDBNull("PostCommentNumber") ? default(int) : reader.GetInt32("PostCommentNumber"),
                                        PostLikeNumber = reader.IsDBNull("PostLikeNumber") ? default(int) : reader.GetInt32("PostLikeNumber"),
                                        PostDislikeNumber = reader.IsDBNull("PostDislikeNumber") ? default(int) : reader.GetInt32("PostDislikeNumber"),
                                        PostLink = reader.IsDBNull("PostLink") ? string.Empty : reader.GetString("PostLink"),
                                        PostType = reader.IsDBNull("PostType") ? string.Empty : reader.GetString("PostType"),
                                        PostUser = FillUserPostDetails(reader, "PostUserId"),
                                        Comments = new List<CommentDto>() // Initialize the Comments list

                                    };

                                    // Add the new post to the list
                                    posts.Add(existingPost);
                                }

                                int commentId = reader.IsDBNull("CommentId") ? default(int) : reader.GetInt32("CommentId");

                                // Check if the comment already exists in the post's Comments list
                                CommentDto existingComment = existingPost.Comments.FirstOrDefault(c => c.CommentId == commentId);

                                if (existingComment == null)
                                {
                                    // Create a new Comment and add it to the existing post's Comments list
                                    CommentDto comment = new CommentDto
                                    {
                                        CommentId = commentId,
                                        CommentUserId = reader.IsDBNull("CommentUserId") ? default(int) : reader.GetInt32("CommentUserId"),
                                        CommentContent = reader.IsDBNull("CommentContent") ? string.Empty : reader.GetString("CommentContent"),
                                        CommentDate = reader.IsDBNull("CommentDate") ? default(DateTime) : reader.GetDateTime("CommentDate"),
                                        CommentPostId = reader.IsDBNull("CommentPostId") ? default(int) : reader.GetInt32("CommentPostId"),
                                        CommentUser = FillUserCommentDetails(reader, "CommentUserId"),
                                        ReplyComments = new List<ReplyCommentDto>() // Initialize the ReplyComments list
                                    };

                                    existingPost.Comments.Add(comment);
                                }
                                CommentDto existingCommentt = existingPost.Comments.FirstOrDefault(c => c.CommentId == commentId);
                                int replyCommentId = reader.IsDBNull("ReplyCommentId") ? default(int) : reader.GetInt32("ReplyCommentId");

                                // Check if the reply comment already exists in the comment's ReplyComments list
                                ReplyCommentDto existingReplyComment = existingCommentt.ReplyComments.FirstOrDefault(rc => rc.ReplyCommentId == replyCommentId);

                                if (existingReplyComment == null)
                                {
                                    // Create a new ReplyComment and add it to the existing comment's ReplyComments list
                                    ReplyCommentDto replyComment = new ReplyCommentDto
                                    {
                                        ReplyCommentId = replyCommentId,
                                        ReplyCommentUserId = reader.IsDBNull("ReplyCommentUserId") ? default(int) : reader.GetInt32("ReplyCommentUserId"),
                                        ReplyCommentContent = reader.IsDBNull("ReplyCommentContent") ? string.Empty : reader.GetString("ReplyCommentContent"),
                                        ReplyCommentDate = reader.IsDBNull("ReplyCommentDate") ? default(DateTime) : reader.GetDateTime("ReplyCommentDate"),
                                        ReplyCommentUser = FillUserReplyCommentDetails(reader, "ReplyCommentUserId"),
                                    };

                                    existingCommentt.ReplyComments.Add(replyComment);
                                }
                            }

                            // Now, the `posts` list should contain unique posts with their corresponding comments and reply comments.
                            connection.Close();

                            // mapp eklenecek!!!!!!!!!!!!!!!!!!!!!
                            return _mapper.Map<List<PostDto>>(posts);

                            UserDto FillUserPostDetails(DbDataReader reader, string userIdColumnName)
                            {
                                int userId = reader.IsDBNull(userIdColumnName) ? default(int) : reader.GetInt32(userIdColumnName);

                                // Burada User sınıfınıza ait özelliklere uygun şekilde doldurma yapabilirsiniz.
                                User user = new User
                                {
                                    UserId = userId,
                                    UserFirstName = reader.IsDBNull("PostUserFirstName") ? string.Empty : reader.GetString("PostUserFirstName"),
                                    UserLastName = reader.IsDBNull("PostUserLastName") ? string.Empty : reader.GetString("PostUserLastName"),
                                    UserProfilePicture = reader.IsDBNull("PostUserProfilePicture") ? string.Empty : reader.GetString("PostUserProfilePicture"),
                                    UserCoverPicture = reader.IsDBNull("PostUserCoverPicture") ? string.Empty : reader.GetString("PostUserCoverPicture"),
                                    // Diğer özellikleri ekleyebilirsiniz.
                                };

                                return _mapper.Map<UserDto>(user);
                            }
                            UserDto FillUserCommentDetails(DbDataReader reader, string userIdColumnName)
                            {
                                int userId = reader.IsDBNull(userIdColumnName) ? default(int) : reader.GetInt32(userIdColumnName);

                                // Burada User sınıfınıza ait özelliklere uygun şekilde doldurma yapabilirsiniz.
                                User user = new User
                                {
                                    UserId = userId,
                                    UserFirstName = reader.IsDBNull("CommentUserFirstName") ? string.Empty : reader.GetString("CommentUserFirstName"),
                                    UserLastName = reader.IsDBNull("CommentUserLastName") ? string.Empty : reader.GetString("CommentUserLastName"),
                                    UserProfilePicture = reader.IsDBNull("CommentUserProfilePicture") ? string.Empty : reader.GetString("CommentUserProfilePicture"),
                                    // Diğer özellikleri ekleyebilirsiniz.
                                };

                                return _mapper.Map<UserDto>(user);
                            }
                            UserDto FillUserReplyCommentDetails(DbDataReader reader, string userIdColumnName)
                            {
                                int userId = reader.IsDBNull(userIdColumnName) ? default(int) : reader.GetInt32(userIdColumnName);

                                // Burada User sınıfınıza ait özelliklere uygun şekilde doldurma yapabilirsiniz.
                                User user = new User
                                {
                                    UserId = userId,
                                    UserFirstName = reader.IsDBNull("ReplyCommentUserFirstName") ? string.Empty : reader.GetString("ReplyCommentUserFirstName"),
                                    UserLastName = reader.IsDBNull("ReplyCommentUserLastName") ? string.Empty : reader.GetString("ReplyCommentUserLastName"),
                                    UserProfilePicture = reader.IsDBNull("ReplyCommentUserProfilePicture") ? string.Empty : reader.GetString("ReplyCommentUserProfilePicture"),
                                    // Diğer özellikleri ekleyebilirsiniz.
                                };

                                return _mapper.Map<UserDto>(user);
                            }


                        }
                        else
                        {
                            return null;
                        }

                    }


                }
            }
        }
        public async Task AddPost(NewPostDto model)
        {
            model.PostCreateDate = DateTime.Now;
            try
            {
				await _uow.GetRepository<Post>().Add(_mapper.Map<Post>(model));
			}
            catch (Exception)
            {

                throw;
            }
            try
            {
				_uow.Commit();
			}
            catch (Exception)
            {

                throw;
            }
        }

        public async Task AddComment(NewCommentDto model)
        {
            try
            {
				var post = await _uow.GetRepository<Post>().Get(x => x.PostId == model.CommentPostId);
				post.PostCommentNumber++;
                this.UpdatePost(_mapper.Map<PostDto>(post));
			}
            catch (Exception)
            {

                throw;
            }
            try
            {
                await _uow.GetRepository<Comment>().Add(_mapper.Map<Comment>(model));
            }
            catch (Exception)
            {

                throw;
            }
            try
            {
                _uow.Commit();
            }
            catch (Exception)
            {

                throw;
            }
        }

		public async Task<PostDto> GetPostById(int postId)
		{
            var post = await _uow.GetRepository<Post>().Get(x => x.PostId == postId);     
            return _mapper.Map<PostDto>(post);
		}
        public async Task<PostDto> GetPostWithCommentsById(int postId)
        {
            var post = await _uow.GetRepository<Post>().Get(x => x.PostId == postId, null, x => x.PostUser);      //yorumlarla userler includeli gelimiyor
            post.Comments = _mapper.Map<List<Comment>>(await _commentService.GetCommentsByPostId(postId));
            
            
            return _mapper.Map<PostDto>(post);
        }
        public void UpdatePost(PostDto model)
        {
            try
            {
				_uow.GetRepository<Post>().Update(_mapper.Map<Post>(model));
			}
            catch (Exception)
            {

                throw;
            }
            try
            {
				_uow.Commit();
			}
            catch (Exception)
            {

                throw;
            }
            
        }
	}
}


