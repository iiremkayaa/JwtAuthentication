﻿using Project.JwtProject.Business.Interfaces;
using Project.JwtProject.DataAccess.Interfaces;
using Project.JwtProject.Entities.Concrete;
using Project.JwtProject.Entities.Dtos.AppUserDtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.JwtProject.Business.Concrete
{
    public class AppUserManager :GenericManager<AppUser>,IAppUserService
    {
        private readonly IAppUserDal _appUserDal;
        public AppUserManager(IGenericDal<AppUser> genericDal,IAppUserDal appUserDal) : base(genericDal)
        {
            _appUserDal = appUserDal;

        }

        public async Task<bool> CheckPassword(AppUserLoginDto appUserLoginDto)
        {
            var appUser = await _appUserDal.GetByFilter(I => I.UserName == appUserLoginDto.UserName);
            return appUser.Password == appUserLoginDto.Password ? true : false;
        }

        public async Task<AppUser> FindByUserName(string userName)
        {
            return await _appUserDal.GetByFilter(I => I.UserName == userName);
        }

        public async  Task<List<AppRole>> GetRolesByUserName(string userName)
        {
            return await _appUserDal.GetRolesByUserName(userName);
        }
    }
}
