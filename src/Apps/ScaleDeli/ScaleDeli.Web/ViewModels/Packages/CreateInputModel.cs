using SIS.MvcFramework.Attributes.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ScaleDeli.Web.ViewModels.Packages
{
    public class CreateInputModel
    {
        [RequiredSis]
        public string  Description { get; set; }

        public decimal Weight { get; set; }

        public string ShippingAddress { get; set; }

        [RequiredSis]
        public string  RecipientName { get; set; }
    }
}
