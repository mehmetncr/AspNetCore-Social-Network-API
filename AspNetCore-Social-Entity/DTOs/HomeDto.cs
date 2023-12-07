using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Entity.DTOs
{
	public class HomeDto
	{
		public List<PostDto> PostDtos { get; set; }	//Postlar
		public List<FriendsDto> OnlineFriendsDtos { get;set; }	//Online kullanıcılar
		public List<UserDto> OfferUserDtos { get; set; }	//Önerilen arkadaşlar
	}
}
