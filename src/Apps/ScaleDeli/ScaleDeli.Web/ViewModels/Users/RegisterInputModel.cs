using SIS.MvcFramework.Attributes.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ScaleDeli.Web.ViewModels.Users
{
    public class RegisterInputModel
    {
        [RequiredSis]
        public string Username { get; set; }
        [RequiredSis]
        public string Email { get; set; }
        [RequiredSis]
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
