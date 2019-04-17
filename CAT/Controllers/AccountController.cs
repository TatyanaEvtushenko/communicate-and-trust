using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CAT.DataLayer.Models;
using CAT.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CAT.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("register")]
        public void RegisterAccount([FromBody]RegisterViewModel account)
        {
            //if (ModelState.IsValid)
            //{
            //    User user = new User { Email = model.Email, UserName = model.Email, Year = model.Year };
            //    // добавляем пользователя
            //    var result = await _userManager.CreateAsync(user, model.Password);
            //    if (result.Succeeded)
            //    {
            //        // установка куки
            //        await _signInManager.SignInAsync(user, false);
            //        return RedirectToAction("Index", "Home");
            //    }
            //    else
            //    {
            //        foreach (var error in result.Errors)
            //        {
            //            ModelState.AddModelError(string.Empty, error.Description);
            //        }
            //    }
            //}
            //return View(model);
        }
    }
}
