using AspNetCore_Social_DataAccess.Identity;
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
    public class PrivacySettingsService : IPrivacySettingsService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IAccountService _accountService;

        public PrivacySettingsService(IUnitOfWork uow, IMapper mapper, IAccountService accountService)
        {
            _uow = uow;
            _mapper = mapper;
            _accountService = accountService;
        }

        public async Task<PrivacySettingDto> GetPrivacySettings(int userId)
        {           
            PrivacySettings settings =  await _uow.GetRepository<PrivacySettings>().Get(x => x.PrivacySettingsUserId == userId);
            PrivacySettingDto mappedSettings = _mapper.Map<PrivacySettingDto>(settings);
            return mappedSettings;

        }

        public async Task<PrivacySettingDto> UpdatePrivacySettings(UpdatePrivacySettingsDto setting)
        {
          
            PrivacySettings settings = await _uow.GetRepository<PrivacySettings>().Get(x => x.PrivacySettingsUserId == setting.AppUserId);
            if (setting.SettingName == "ReqFriends")
            {
                if (settings.PrivacySettingsFriendRequest==true)
                {
                    settings.PrivacySettingsFriendRequest = false;
                }
                else
                {
                    settings.PrivacySettingsFriendRequest = true;
                }
            }
            else if (setting.SettingName == "ReqMessage")
            {
                if (settings.PrivacySettingsMessageRequest==true)
                {
                    settings.PrivacySettingsMessageRequest = false;
                }
                else
                {
                    settings.PrivacySettingsMessageRequest= true;
                }
            }
            else if (setting.SettingName == "HiddenProfile")
            {
                if (settings.PrivacySettingsHiddenProfile == true)
                {
                    settings.PrivacySettingsHiddenProfile = false;
                }
                else
                {
                   settings.PrivacySettingsHiddenProfile= true;
                }
            }
             _uow.GetRepository<PrivacySettings>().Update(settings);
            _uow.Commit();
            return _mapper.Map<PrivacySettingDto>(settings);
        }
    }
}
