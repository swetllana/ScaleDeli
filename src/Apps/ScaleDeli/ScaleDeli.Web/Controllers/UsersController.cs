﻿using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Result;
using ScaleDeli.Web.ViewModels.Users;
using ScaleDeli.Services;
using SIS.MvcFramework.Attributes.Security;

namespace ScaleDeli.Web.Controllers
{
    public  class UsersController : Controller
    {
        private readonly IUsersService usersService;
        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

       public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(LoginInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return Redirect("/Users/Login");
            }
            var user = this.usersService.GetUserOrNull(input.Username, input.Password);
            if (user == null )
            {
                return Redirect("/Users/Login");
            }

            this.SignIn(user.Id,user.Username,user.Email);
            return this.Redirect("/");
        }

        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Users/Register");
            }

            if (input.Password != input.ConfirmPassword)
            {
                return this.Redirect("/Users/Register");
            }

            var userId = this.usersService.CreateUser(input.Username, input.Email , input.Password);
            this.SignIn(userId,input.Username, input.Email);

            return this.Redirect("/");
        }

        [Authorize]
        public IActionResult Logout ()
        {
            this.SignOut();
            return this.Redirect("/");
        }
    }

}
