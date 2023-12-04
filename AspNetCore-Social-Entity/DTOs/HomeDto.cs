using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Entity.DTOs
{
	public class HomeDto
	{
		List<PostDto> PostDtos { get; set; }	//Postlar
		List <UserDto> OnlineUserDtos { get;set; }	//Online kullanıcılar
		List<UserDto> OfferUserDtos { get; set; }	//Önerilen arkadaşlar
	}
}
