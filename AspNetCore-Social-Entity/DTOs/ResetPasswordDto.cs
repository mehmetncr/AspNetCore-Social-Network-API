using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Entity.DTOs
{
    public class ResetPasswordDto
    {

        public string Email { get; set; }

        public string Password { get; set; }

        public string? ReqToken { get; set; }
    }
}
