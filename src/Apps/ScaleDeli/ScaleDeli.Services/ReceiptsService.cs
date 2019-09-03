using ScaleDeli.Data;
using ScaleDeli.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScaleDeli.Services
{
    public class ReceiptsService : IReceiptsService
    {
        private readonly ScaleDeliDbContext db;
        public ReceiptsService(ScaleDeliDbContext db)
        {
            this.db = db;
        }
        public void CreateFromPackage(decimal weight, string packageId, string recipientId)
        {
            var receipt = new Receipt
            {
                PackageId = packageId,
                RecipientId = recipientId,
                Fee = weight * 2.67M,
                IssuedOn = DateTime.UtcNow
            };

            this.db.Receipts.Add(receipt);
            this.db.SaveChanges();
        }

        public IQueryable <Receipt> GetAll()
        {
            return this.db.Receipts;
        }
    }
}
