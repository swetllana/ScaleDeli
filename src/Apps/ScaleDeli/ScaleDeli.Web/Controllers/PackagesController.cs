using ScaleDeli.Services;
using ScaleDeli.Web.ViewModels.Packages;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScaleDeli.Web.Controllers
{
    public class PackagesController : Controller
    {
        private readonly IPackagesService packagesService;
        private readonly IUsersService usersService;
        public PackagesController(IPackagesService packagesService,  IUsersService usersService)
        {
            this.packagesService = packagesService;
            this.usersService = usersService;
        }

        public IActionResult Create()
        {
            var list = this.usersService.GetUserNames();

            return this.View(list);
        }

        [HttpPost]
        public IActionResult Create(CreateInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Packages/Create");
            }
        }
    }
}
