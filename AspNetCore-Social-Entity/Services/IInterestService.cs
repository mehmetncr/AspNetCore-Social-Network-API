﻿using AspNetCore_Social_Entity.DTOs;
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
        Task<List<InterestDto>> AddInterest(Interest model);
        Task<List<InterestDto>> UpdateInterest(Interest model);
        Task<List<InterestDto>> GetUserInterests(int appUserId);
    }
}
