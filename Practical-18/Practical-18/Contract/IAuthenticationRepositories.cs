using Microsoft.AspNetCore.Identity;
using Practical_18.Data;
using Practical_18.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practical_18.Contract
{
    public interface IAuthenticationRepositories : IGenericRepository<UserVM>
    {

        Task<IdentityResult> SignUp(UserVM user);

        Task<string> Login(SignInModel signInModel);
    }
}
