﻿using ScaleDeli.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScaleDeli.Services
{
     public  interface IReceiptsService
    {
        void CreateFromPackage(decimal weight,string packageId, string recipientId);

        IQueryable<Receipt> GetAll();
    }
}
