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
        public PostService(IUnitOfWork uow, IFriendService friendService, IMapper mapper, SocialContext socialContext)
        {
            _uow = uow;
            _friendService = friendService;
            _mapper = mapper;
            _socialContext = socialContext;
        }

        public async Task<List<PostDto>> GetAllPostsWithUserId(int userId)
        {
            List<Friends> friends = await _friendService.GetFriends(userId);
            Friends user = new Friends()
            {
                FriendsUserId = userId,
            };
            friends.Add(user);
            var list = await _uow.GetRepository<Post>().GetAll(x => friends.Select(f => f.FriendsUserId).Contains(x.PostUserId), x => x.OrderByDescending(x => x.PostCreateDate), x => x.Comments);
            return _mapper.Map<List<PostDto>>(list);
        }


        public async Task<List<Post>> GetPosts(int userId)
        {       

            var userIdParameter = new SqlParameter("@userId", userId);
            var postCountParameter = new SqlParameter("@postCount", 10);

            using (DbConnection connection = _socialContext.Database.GetDbConnection())
            {
                connection.Open();

                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "sp_DinamikSorgu";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(userIdParameter);
                    command.Parameters.Add(postCountParameter);

                    using (DbDataReader reader = command.ExecuteReader())
                    {

                        if (reader.HasRows)
                        {
                            List<Post> posts = new List<Post>();
                            while (reader.Read())
                            {
                                int postId = reader.IsDBNull("PostId") ? default(int) : reader.GetInt32("PostId");

                                // Check if the post already exists in the list
                                Post existingPost = posts.FirstOrDefault(p => p.PostId == postId);

                                if (existingPost == null)
                                {
                                    // If the post doesn't exist, create a new post
                                    existingPost = new Post
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
                                        Comments = new List<Comment>() // Initialize the Comments list

                                    };

                                    // Add the new post to the list
                                    posts.Add(existingPost);
                                }

                                int commentId = reader.IsDBNull("CommentId") ? default(int) : reader.GetInt32("CommentId");

                                // Check if the comment already exists in the post's Comments list
                                Comment existingComment = existingPost.Comments.FirstOrDefault(c => c.CommentId == commentId);

                                if (existingComment == null)
                                {
                                    // Create a new Comment and add it to the existing post's Comments list
                                    Comment comment = new Comment
                                    {
                                        CommentId = commentId,
                                        CommentUserId = reader.IsDBNull("CommentUserId") ? default(int) : reader.GetInt32("CommentUserId"),
                                        CommentContent = reader.IsDBNull("CommentContent") ? string.Empty : reader.GetString("CommentContent"),
                                        CommentDate = reader.IsDBNull("CommentDate") ? default(DateTime) : reader.GetDateTime("CommentDate"),
                                        CommentUser = FillUserCommentDetails(reader, "CommentUserId"),
                                        ReplyComments = new List<ReplyComment>() // Initialize the ReplyComments list
                                    };

                                    existingPost.Comments.Add(comment);
                                }
                                Comment existingCommentt = existingPost.Comments.FirstOrDefault(c => c.CommentId == commentId);
                                int replyCommentId = reader.IsDBNull("ReplyCommentId") ? default(int) : reader.GetInt32("ReplyCommentId");

                                // Check if the reply comment already exists in the comment's ReplyComments list
                                ReplyComment existingReplyComment = existingCommentt.ReplyComments.FirstOrDefault(rc => rc.ReplyCommentId == replyCommentId);

                                if (existingReplyComment == null)
                                {
                                    // Create a new ReplyComment and add it to the existing comment's ReplyComments list
                                    ReplyComment replyComment = new ReplyComment
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
                            return posts;

                            User FillUserPostDetails(DbDataReader reader, string userIdColumnName)
                            {
                                int userId = reader.IsDBNull(userIdColumnName) ? default(int) : reader.GetInt32(userIdColumnName);

                                // Burada User sınıfınıza ait özelliklere uygun şekilde doldurma yapabilirsiniz.
                                User user = new User
                                {
                                    UserId = userId,
                                    UserFirstName = reader.IsDBNull("PostUserFirstName") ? string.Empty : reader.GetString("PostUserFirstName"),
                                    UserLastName = reader.IsDBNull("PostUserLastName") ? string.Empty : reader.GetString("PostUserLastName"),
                                    UserProfilePicture = reader.IsDBNull("PostUserProfilePicture") ? string.Empty : reader.GetString("PostUserProfilePicture"),
                                    // Diğer özellikleri ekleyebilirsiniz.
                                };

                                return user;
                            }
                            User FillUserCommentDetails(DbDataReader reader, string userIdColumnName)
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

                                return user;
                            }
                            User FillUserReplyCommentDetails(DbDataReader reader, string userIdColumnName)
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

                                return user;
                            }


                        }
                        else
                        {
                            connection.Close();
                            return null;
                        }

                    }


                }
            }
        }

    
    }
}


