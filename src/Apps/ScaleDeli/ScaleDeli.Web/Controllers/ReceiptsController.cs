﻿using ScaleDeli.Services;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;
using System;
using System.Collections.Generic;
using System.Linq;



using ScaleDeli.Web.ViewModels.Receipts;

public class ReceiptsController : Controller
{ 
    
        private readonly IReceiptsService receiptsService;
        public ReceiptsController(IReceiptsService receiptsService)
        {
            this.receiptsService = receiptsService;
        }

        [Authorize]
        public IActionResult Index()
        {
        var viewModel = this.receiptsService.GetAll().Select(
            x => new ReceiptViewModel
            {
                Id = x.Id,
                Fee = x.Fee,
                IssuedOn = x.IssuedOn,
                RecipientName = x.Recipient.Username
            }).ToList();
            return this.View(viewModel);
        }
   
}
