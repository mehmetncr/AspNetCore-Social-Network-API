using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Entity.DTOs
{
    public class ProfileDto
    {
        public UserDto User { get; set; }
        public List<FriendsDto> Friends { get; set; }
        public List<PostDto> Posts { get; set; }


    }
}
