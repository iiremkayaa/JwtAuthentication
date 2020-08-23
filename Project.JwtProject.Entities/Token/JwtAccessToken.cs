using Project.JwtProject.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.JwtProject.Entities.Token
{
    public class JwtAccessToken :IToken
    {
        public string Token { get; set; }
    }
}
