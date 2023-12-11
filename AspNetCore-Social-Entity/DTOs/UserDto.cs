
using AspNetCore_Social_Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Entity.DTOs
{
	public class UserDto
	{
		public int UserId { get; set; }
		public string UserFirstName { get; set; }
		public string UserLastName { get; set; }
		public string UserEmail { get; set; }
		public DateTime? UserBirthDate { get; set; }
		public string? UserGender { get; set; }
		public string? UserProfilePicture { get; set; }
		public string? UserCoverPicture { get; set; }
		public string? UserBiography { get; set; }
		public string? UserLocation { get; set; }
		public string AccessToken { get; set; }

		public int? UserFollowerCount { get; set; }
		public int? UserFollowingCount { get; set; }
		public DateTime? UserCreatedAt { get; set; }
		public string? UserPhoneNumber { get; set; }
		public string? UserWebsite { get; set; }
		public string? UserJobInfo { get; set; }
		public string? UserEducationInfo { get; set; }

		public string? UserLanguage1 { get; set; }
		public string? UserLanguage2 { get; set; }
		public string? UserLanguage3 { get; set; }

		public virtual List<SocialMediaAccountDto> SocialMediaAccounts { get; set; }


		public bool UserIsOnline { get; set; }
		public DateTime? UserLastLogin { get; set; }
		public virtual List<UserActivityDto> ActivityHistory { get; set; }
		public virtual List<NotificationDto> Notification { get; set; }

		public int? UserPrivacySettingsId { get; set; }
		public virtual PrivacySettingDto UserPrivacySettings { get; set; }

		public virtual List<FriendsDto> Friends { get; set; }
		public virtual List<InterestDto> Interests { get; set; }

		public virtual List<PostDto> Posts { get; set; }
		public virtual List<CommentDto> Comments { get; set; }
		public virtual List<ReplyCommentDto> ReplyComments { get; set; }
        public virtual List<FriendRequestDto> FriendRequest { get; set; }
    }
}
