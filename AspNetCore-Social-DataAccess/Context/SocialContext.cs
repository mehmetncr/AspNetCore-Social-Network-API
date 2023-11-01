using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_DataAccess.Context
{
    public class SocialContext : DbContext
    {
        public SocialContext(DbContextOptions options) : base(options)
        {
        }
    }
}
