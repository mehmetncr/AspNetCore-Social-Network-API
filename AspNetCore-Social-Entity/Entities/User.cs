using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Entity.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public DateTime? UserBirthDate { get; set; }
        public string? UserGender { get; set; }
        public string? UserProfilePicture { get; set; }
        public string? UserCoverPicture { get; set; }
        public string? UserBiography { get; set; }
        public string? UserLocation { get; set; }

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
        public virtual List<SocialMediaAccount> SocialMediaAccounts { get; set; }
        public bool UserIsOnline { get; set; }
        public DateTime? UserLastLogin { get; set; }
        public virtual List<UserActivity> ActivityHistory { get; set; }
        public virtual List<Notification> Notification { get; set; }

        public int? UserPrivacySettingsId { get; set; }
        public virtual PrivacySettings UserPrivacySettings { get; set; }

        public virtual List<Friends> Friends { get; set; }
        public virtual List<Interest> Interests { get; set; }

        public virtual List<Post> Posts { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<ReplyComment> ReplyComments { get; set; }
        public virtual List<FriendRequest> FriendRequests { get; set; }

    }
}
