using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Practical_18.Contract;
using Practical_18.Data;
using Practical_18.Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Practical_18.Repositories
{
    public class AuthenticationRepositories : GenericRepository<UserVM>, IAuthenticationRepositories
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IConfiguration configration;

        public AuthenticationRepositories(ApplicationDbContext Context
            , UserManager<User> userManager,
            SignInManager<User> signInManager,
             IConfiguration configration
            ) : base(Context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configration = configration;
        }

        public async Task<IdentityResult> SignUp(UserVM user)
        {
            var CurrentUser = new User()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                UserName=user.Email
            };
            return await userManager.CreateAsync(CurrentUser, user.Password);
        }

        public async Task<string> Login(SignInModel signInModel)
        {
            var result = await signInManager.PasswordSignInAsync(signInModel.Email, signInModel.Password, false, false);
            if (!result.Succeeded)
            {
                return null;
            }
            var authclient = new List<Claim>
            {
                new Claim(ClaimTypes.Name,signInModel.Email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            var authsignKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configration["JWT:Secret"]));

            var token = new JwtSecurityToken
            (
                issuer: configration["JWT:ValidIssuer"],
                audience: configration["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(1),
                claims: authclient,
                signingCredentials: new SigningCredentials(authsignKey, SecurityAlgorithms.HmacSha256Signature)
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
