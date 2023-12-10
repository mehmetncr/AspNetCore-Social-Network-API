using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Entity.DTOs
{
    public class UserUpdateDto
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
        public bool UserIsOnline { get; set; }
        public DateTime? UserLastLogin { get; set; }

    }
}
