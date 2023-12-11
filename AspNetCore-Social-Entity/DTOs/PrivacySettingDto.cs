using AspNetCore_Social_Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Entity.DTOs
{
	public class PrivacySettingDto
	{
		public int PrivacySettingsId { get; set; }
		public int PrivacySettingsUserDtoId { get; set; }
		public bool PrivacySettingsFriendRequest { get; set; }
		public bool PrivacySettingsMessageRequest { get; set; }
		public bool PrivacySettingsHiddenProfile { get; set; }

	}
}
