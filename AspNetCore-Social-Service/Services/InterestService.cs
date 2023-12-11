using AspNetCore_Social_Entity.Entities;
using AspNetCore_Social_Entity.Services;
using AspNetCore_Social_Entity.UnitOfWorks;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Service.Services
{
    public class InterestService : IInterestService
    {
        private readonly IUnitOfWork _uow;
        private readonly IAccountService _accountService;

        public InterestService(IUnitOfWork uow, IAccountService accountService)
        {
            _uow = uow;
            _accountService = accountService;
        }

        public async Task<string> AddInterest(Interest model)
        {
            model.UserId= await _accountService.GetUserIdByAppUserId(model.UserId);
            try
            {
                await _uow.GetRepository<Interest>().Add(model);
                await _uow.CommitAsync();
                return "Ok";
            }
            catch (Exception ex)
            { 
                return  ex.Message;
                
            }
          
        }
        public async Task<string> DeleteInterest(Interest model)
        {
            model.UserId = await _accountService.GetUserIdByAppUserId(model.UserId);
            try
            {
               var interest= await _uow.GetRepository<Interest>().Get(x => x.InterestName == model.InterestName && x.UserId == model.UserId);
                _uow.GetRepository<Interest>().Delete(interest);
                await _uow.CommitAsync();
                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message;

            }

        }
    }
}
