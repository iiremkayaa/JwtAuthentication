using Project.JwtProject.DataAccess.Interfaces;
using Project.JwtProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.JwtProject.DataAccess.Concrete.Repositories
{
    public class EfAppUserRoleRepository :EfGenericRepository<AppUserRole>,IAppUserRoleDal
    {
    }
}
