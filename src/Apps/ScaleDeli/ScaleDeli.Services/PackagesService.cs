using ScaleDeli.Data;
using ScaleDeli.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScaleDeli.Services
{
    public class PackagesService : IPackagesService
    {
        private readonly ScaleDeliDbContext  db;
        public PackagesService(ScaleDeliDbContext db)
        {
            this.db = db;

        }

        void Create(string description, decimal weight, string shippingAddress, string recipientName)
        {
            var userId = this.db.Users.Where(x => x.Username == recipientName).Select(x=>x.Id).FirstOrDefault();
            if ( userId ==null)
            {
                return;
            }
            var package = new Package
            {
                Description = description,
                Weight = weight,
                Status = PackageStatus.Pending,
                ShippingAddress = shippingAddress,
                RecipientId = userId
            };

            this.db.Packages.Add(package);
            this.db.SaveChanges();
        }
    }
}
