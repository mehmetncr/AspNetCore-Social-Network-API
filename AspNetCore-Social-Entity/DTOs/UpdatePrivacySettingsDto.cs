using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Entity.DTOs
{
    public class UpdatePrivacySettingsDto
    {
        public int AppUserId {  get; set; }
        public string SettingName {  get; set; }
    }
}
