﻿using ScaleDeli.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScaleDeli.Services
{
    public interface IUsersService
    {
        string CreateUser(string username, string email, string password);

        User GetUserOrNull(string username, string password);
    }

    
}
