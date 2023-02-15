using Microsoft.Extensions.DependencyInjection;
using ApexRestaurant.Repository.RCustomer;
using Microsoft.EntityFrameworkCore;


using System.Reflection;

namespace ApexRestaurant.Repository
{
    public static class RepositoryModule
    {
        public static void Register(IServiceCollection services)
        {
            services.AddDbContext<RestaurantContext>(options => options.UseMySQL(
                @"Server=127.0.0.1;port=8800;database=ApexRestaurantDB;uid=root;password=password",
                builder => builder.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name)
            ));

            services.AddTransient<ICustomerRepository, CustomerRepository>();
        }
    }
}
// @"Server=127.0.0.1;Initial Catalog=ApexRestaurantDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"