using Project.JwtProject.Business.Interfaces;
using Project.JwtProject.Business.StringInfos;
using Project.JwtProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.JwtProject.WebApi
{
    public static class JwtIdentityInitializer
    {
        public static async Task Seed(IAppUserService appUserService,IAppUserRoleService appUserRoleService,IAppRoleService appRoleService)
        {
            var adminRole = await appRoleService.FindByName(RoleInfo.Admin);
            if (adminRole == null)
            {
                await appRoleService.Add(new AppRole
                {
                    Name = RoleInfo.Admin
                });
            }
            var memberRole = await appRoleService.FindByName(RoleInfo.Member);
            if (memberRole == null)
            {
                await appRoleService.Add(new AppRole
                {
                    Name = RoleInfo.Member
                });
            }
            var adminUser = await appUserService.FindByUserName("irem");
            if (adminUser == null)
            {
                await appUserService.Add(new AppUser
                {
                    FullName = "irem kaya",
                    UserName = "irem",
                    Password = "1"
                });
                var role = await appRoleService.FindByName(RoleInfo.Admin);
                var admin = await appUserService.FindByUserName("irem");
                await appUserRoleService.Add(new AppUserRole
                {
                    AppUserId = admin.Id,
                    AppRoleId = role.Id
                });
            }

        }
    }
}
