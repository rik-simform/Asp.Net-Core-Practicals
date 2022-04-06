using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Practical_18.Contract;
using Practical_18.Data;
using Practical_18.Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Practical_18.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Authentication : ControllerBase
    {
        private readonly IAuthenticationRepositories authenticationRepositories;
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IConfiguration configration;

        public Authentication(
                IAuthenticationRepositories authenticationRepositories
                ,IMapper mapper,
             UserManager<User> userManager,
            SignInManager<User> signInManager,
            IConfiguration configration)
        {
            this.authenticationRepositories = authenticationRepositories;
            this.mapper = mapper;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configration = configration;
        }

        // GET: api/Students
        //sigup method call
        [HttpPost("SignUp")]
        public async Task<IActionResult> OnsignPostAsync([FromBody]UserVM user)
        {
            var result = await authenticationRepositories.SignUp(user);
            if (result.Succeeded)
            {
                return Ok();
            }
            return Unauthorized();
        }


        [HttpPost("LogIn")]
        public async Task<IActionResult> LoginAsyn([FromBody] SignInModel signInModel)
        {
            var result = await authenticationRepositories.Login(signInModel);
            if (string.IsNullOrEmpty(result))
            {
                return Ok();
            }
            return Ok(result);
        }
    }
}
