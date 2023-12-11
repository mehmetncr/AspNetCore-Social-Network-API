using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Entity.Entities
{
    public class PrivacySettings
    {
        public int PrivacySettingsId { get; set; }
        public int PrivacySettingsUserId { get; set; }
        public bool PrivacySettingsFriendRequest { get; set; }
        public bool PrivacySettingsMessageRequest { get; set; }
        public bool PrivacySettingsHiddenProfile { get; set; }
    }
}
