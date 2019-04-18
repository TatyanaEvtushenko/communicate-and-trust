﻿using System.Threading.Tasks;
using CAT.BusinessLayer.Services.AccountServices.Interfaces;
using CAT.BusinessLayer.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CAT.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IAccountService userService;

        public AccountController(IAccountService userService)
        {
            this.userService = userService;
        }

        [HttpPost("register")]
        public async Task<IdentityResult> RegisterAccount([FromBody]RegisterAccountViewModel model)
        {
            return await userService.RegisterUser(model);
        }
    }
}
