using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(ComputerRepairStore.BlazorApp.Areas.Identity.IdentityHostingStartup))]
namespace ComputerRepairStore.BlazorApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}