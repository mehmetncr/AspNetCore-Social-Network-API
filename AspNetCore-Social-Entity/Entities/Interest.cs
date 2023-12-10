using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Entity.Entities
{
    public class Interest
    {
        public int InterestId { get; set; }
        public string InterestName { get; set; }

        public int UserId { get; set; }



    }
}
