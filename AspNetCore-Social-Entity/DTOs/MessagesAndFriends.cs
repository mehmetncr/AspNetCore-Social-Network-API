using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Entity.DTOs
{
    public class MessagesAndFriends
    {
       public  List<MessageDto> Messages { get; set; }
       public  List<FriendsDto> Friends { get; set; }
    }
}
