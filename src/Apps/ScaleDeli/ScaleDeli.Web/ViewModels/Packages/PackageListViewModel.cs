using System;
using System.Collections.Generic;
using System.Text;

namespace ScaleDeli.Web.ViewModels.Packages
{
    public class PackageListViewModel
    {
        public IEnumerable<PackageViewModel> Packages { get; set; }
    }
}
