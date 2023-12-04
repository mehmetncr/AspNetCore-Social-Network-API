
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Entity.DTOs
{
	public class UserDto
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime BirthDate { get; set; }
		public string Gender { get; set; }
		public string ProfilePicture { get; set; }
		public string CoverPicture { get; set; }
		public string Biography { get; set; }
		public string Location { get; set; }

		public int FollowerCount { get; set; }
		public int FollowingCount { get; set; }
		public DateTime CreatedAt { get; set; }
		public string PhoneNumber { get; set; }
		public string Website { get; set; }
		public string JobInfo { get; set; }
		public string EducationInfo { get; set; }

		public string? Language1 { get; set; }
		public string? Language2 { get; set; }
		public string? Language3 { get; set; }
		public virtual List<SocialMediaAccountDto> SocialMediaAccountsDto { get; set; }

		public DateTime LastLogin { get; set; }
		public virtual List<UserActivityDto> ActivityHistoryDto { get; set; }
		public virtual List<NotificationDto> NotificationDto { get; set; }

		public int PrivacySettingsId { get; set; }
		public virtual PrivacySettingDto PrivacySettingsDto { get; set; }

		public virtual List<FriendsDto> FriendsDto { get; set; }
		public virtual List<InterestDto> InterestsDto { get; set; }

		public virtual List<PostDto> PostsDto { get; set; }
		public virtual List<CommentDto> CommentsDto { get; set; }
		public virtual List<ReplyCommentDto> ReplyCommentsDto { get; set; }
	}
}
