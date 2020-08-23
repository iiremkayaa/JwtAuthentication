using Project.JwtProject.Business.Interfaces;
using Project.JwtProject.DataAccess.Interfaces;
using Project.JwtProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.JwtProject.Business.Concrete
{
    public class AppUserRoleManager :GenericManager<AppUserRole>,IAppUserRoleService
    {
        public AppUserRoleManager(IGenericDal<AppUserRole> genericDal):base(genericDal)
        {

        }
    }
}
