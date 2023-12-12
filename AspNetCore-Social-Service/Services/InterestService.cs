using AspNetCore_Social_Entity.DTOs;
using AspNetCore_Social_Entity.Entities;
using AspNetCore_Social_Entity.Services;
using AspNetCore_Social_Entity.UnitOfWorks;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Service.Services
{
    public class InterestService : IInterestService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IAccountService _accountService;

        public InterestService(IUnitOfWork uow, IAccountService accountService, IMapper mapper)
        {
            _uow = uow;
            _accountService = accountService;
            _mapper = mapper;
        }

        public async Task<List<InterestDto>> AddInterest(Interest model)
        {
            model.UserId= await _accountService.GetUserIdByAppUserId(model.UserId);
            try
            {
                await _uow.GetRepository<Interest>().Add(model);
                await _uow.CommitAsync();
                var interests = await _uow.GetRepository<Interest>().GetAll(x=>x.UserId == model.UserId);
                List<InterestDto> mappedInterests = _mapper.Map<List<InterestDto>>(interests);
                return mappedInterests;

            }
            catch (Exception)
            { 
                return  new List<InterestDto>();
                
            }
          
        }
        public async Task<List<InterestDto>> UpdateInterest(Interest model)
        {
            model.UserId = await _accountService.GetUserIdByAppUserId(model.UserId);
            try
            {
               var interest= await _uow.GetRepository<Interest>().Get(x => x.InterestName == model.InterestName && x.UserId == model.UserId);
                _uow.GetRepository<Interest>().Delete(interest);
                await _uow.CommitAsync();
                var interests = await _uow.GetRepository<Interest>().GetAll(x => x.UserId == model.UserId);
                List<InterestDto> mappedInterests = _mapper.Map<List<InterestDto>>(interests);
                return mappedInterests;
            }
            catch (Exception ex)
            {
                return new List<InterestDto>();

            }

        }
        public async Task<List<InterestDto>> GetUserInterests(int appUserId)
        {
           int userId = await _accountService.GetUserIdByAppUserId(appUserId);
           IEnumerable<Interest> intrests=  await _uow.GetRepository<Interest>().GetAll(x => x.UserId == userId); 
            return  _mapper.Map<List<InterestDto>>(intrests.ToList());             
        }
    }
}
