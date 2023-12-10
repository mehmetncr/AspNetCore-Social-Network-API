using AspNetCore_Social_Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Entity.DTOs
{
	public class InterestDto
	{
		public int InterestId { get; set; }
		public string InterestName { get; set; }

		public int UserId { get; set; }

	}
}
