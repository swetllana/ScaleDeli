using ScaleDeli.Data;
using ScaleDeli.Services;
using SIS.MvcFramework;
using SIS.MvcFramework.DependencyContainer;
using SIS.MvcFramework.Routing;

namespace ScaleDeli.Web
{
    class StartUp : IMvcApplication
    {
        public void Configure(IServerRoutingTable serverRoutingTable)
        {
            // Once on start
            using (var db = new ScaleDeliDbContext())
            {
                db.Database.EnsureCreated();
            }
        }

        public void ConfigureServices(IServiceProvider serviceProvider)
        {
            serviceProvider.Add<IUsersService, UsersService>();
        }
    }
}
