using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Entity.Entities
{
    public class InterestUser
    {
        public int InterestId { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual Interest Interest { get; set; }
    }
}
