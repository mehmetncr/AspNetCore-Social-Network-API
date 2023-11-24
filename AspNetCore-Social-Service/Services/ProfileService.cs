using AspNetCore_Social_Entity.DTOs;
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
	public class ProfileService : IProfileService
	{
		private readonly IUnitOfWork _uow;
		private readonly IMapper _mapper;

		public ProfileService(IUnitOfWork uow, IMapper mapper)
		{
			_uow = uow;
			_mapper = mapper;
		}	

		public async Task<UserDto> GetById(int id)
		{
		   return _mapper.Map<UserDto>(await _uow.GetRepository<User>().GetById(id));
		}

	}
}
