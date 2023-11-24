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
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Gender { get; set; }
        public string? ProfilePicture { get; set; }
        public string? CoverPicture { get; set; }
        public string? Biography { get; set; }
        public string? Location { get; set; }

        public int? FollowerCount { get; set; }
        public int? FollowingCount { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Website { get; set; }
        public string? JobInfo { get; set; }
        public string? EducationInfo { get; set; }

        public string? Language1 { get; set; }
        public string? Language2 { get; set; }
        public string? Language3 { get; set; }
        public virtual List<SocialMediaAccount> SocialMediaAccounts { get; set; }

        public DateTime? LastLogin { get; set; }
        public virtual List<UserActivity> ActivityHistory { get; set; }
        public virtual List<Notification> Notification { get; set; }

        public int? PrivacySettingsId { get; set; }
        public virtual PrivacySettings PrivacySettings { get; set; }

        public virtual List<Friends> Friends { get; set; }
        public virtual List<Interest> Interests { get; set; }

        public virtual List<Post> Posts { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<ReplyComment> ReplyComments { get; set; }

    }
}
