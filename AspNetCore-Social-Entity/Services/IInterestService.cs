using AspNetCore_Social_Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Entity.Services
{
    public  interface IInterestService
    {
        Task<string> AddInterest(Interest model);
        Task<string> DeleteInterest(Interest model);
    }
}
