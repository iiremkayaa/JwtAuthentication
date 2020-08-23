using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.JwtProject.Business.Interfaces;
using Project.JwtProject.Business.StringInfos;
using Project.JwtProject.Entities.Concrete;
using Project.JwtProject.Entities.Dtos.AppUserDtos;
using Project.JwtProject.Entities.Token;
using Project.JwtProject.WebApi.CustomFilters;

namespace Project.JwtProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;
        public AuthController(IJwtService jwtService,IAppUserService appUserService,IMapper mapper)
        {
            _jwtService = jwtService;
            _appUserService = appUserService;
            _mapper = mapper;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> SignIn(AppUserLoginDto appUserLoginDto)
        {
            var appUser = await _appUserService.FindByUserName(appUserLoginDto.UserName);
            if (appUser == null)
            {
                return BadRequest("Username or password is incorrect.");
            }
            else
            {
                if(await _appUserService.CheckPassword(appUserLoginDto))
                {
                    var roles = await _appUserService.GetRolesByUserName(appUserLoginDto.UserName);
                    var token=_jwtService.GenerateJwtToken(appUser, roles);
                    JwtAccessToken jwtAccessToken = new JwtAccessToken();
                    jwtAccessToken.Token = token;
                    return Created("", jwtAccessToken);
                }
                else
                {
                    return BadRequest("Username or password is incorrect.");
                }
            }
            
        }
        [HttpPost("[action]")]
        [ValidModel]
        public async Task<IActionResult> SignUp(AppUserAddDto appUserAddDto,[FromServices]IAppUserRoleService appUserRoleService,[FromServices] IAppRoleService appRoleService) 
        {
            var appUser= await _appUserService.FindByUserName(appUserAddDto.UserName);
            if (appUser != null)
            {
                return BadRequest("Username is already taken.");
            }
            await _appUserService.Add(_mapper.Map<AppUser>(appUserAddDto));
            var user = await _appUserService.FindByUserName(appUserAddDto.UserName);
            var role = await appRoleService.FindByName(RoleInfo.Member);
            await appUserRoleService.Add(new AppUserRole
            {
                AppRoleId = role.Id,
                AppUserId = user.Id
            });
            return Created("", appUserAddDto);
        }

        [HttpGet("[action]")]
        [Authorize]
        public async Task<IActionResult> ActiveUser()
        {
            var user = await _appUserService.FindByUserName(User.Identity.Name);
            var roles = await _appUserService.GetRolesByUserName(User.Identity.Name);
            AppUserDto appUserDto = new AppUserDto
            {
                FullName = user.FullName,
                UserName = user.UserName,
                Roles = roles.Select(I => I.Name).ToList()
            };
            return Ok(appUserDto);

        }
    }
}
