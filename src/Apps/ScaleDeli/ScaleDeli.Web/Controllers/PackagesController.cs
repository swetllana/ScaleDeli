﻿using ScaleDeli.Data.Models;
using ScaleDeli.Services;
using ScaleDeli.Web.ViewModels.Packages;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [Authorize]
        public IActionResult Create()
        {
            var list = this.usersService.GetUserNames();

            return this.View(list);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(CreateInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Packages/Create");
            }

            this.packagesService.Create(input.Description, input.Weight, input.ShippingAddress,input.RecipientName);
            return  this.Redirect("/Packages/Pending");
        }

        [Authorize]
        public IActionResult Delivered()
        {
            var packages = this.packagesService.GetAllByStatus(PackageStatus.Delivered)
                .Select(x => new PackageViewModel
                {
                    Description = x.Description,
                    Id = x.Id,
                    ShippingAddress = x.ShippingAddress,
                    Weight = x.Weight,
                    RecipientName = x.Recipient.Username

                }).ToList()  ;
            return this.View(new PackageListViewModel { Packages = packages });
        }

        [Authorize]
        public IActionResult Pending()
        {
            var packages = this.packagesService.GetAllByStatus(PackageStatus.Pending)
                .Select(x => new PackageViewModel
                {
                    Description = x.Description,
                    Id = x.Id,
                    ShippingAddress = x.ShippingAddress,
                    Weight = x.Weight,
                    RecipientName = x.Recipient.Username

                }).ToList();
            return this.View(new PackageListViewModel { Packages = packages } );
        }

        [Authorize]
        public IActionResult Deliver (string id)
        {
            packagesService.Deliver(id);
            return this.Redirect("/Packages/Delivered");
        }
    }
}
