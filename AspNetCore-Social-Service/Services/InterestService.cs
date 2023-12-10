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

        public InterestService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<string> AddInterest(Interest model)
        {
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
    }
}
