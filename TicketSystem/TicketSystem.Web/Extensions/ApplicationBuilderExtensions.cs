using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TicketSystem.Common.Contstants;
using TicketSystem.Data;
using TicketSystem.Data.Models;

namespace TicketSystem.Web.Extensions
{
    public  static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseDatabaseMigration( this IApplicationBuilder app )
        {
            using ( var serviceScope =
                app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope() )
            {
                serviceScope.ServiceProvider.GetService<TicketSystemDbContext>().Database.Migrate();

                var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();
                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                Task
                    .Run( async () =>
                    {
                        var adminName = WebConstants.AdminRole;

                        var roles = new[]
                        {
                            adminName,
                            WebConstants.OrganizerRole
                        };

                        foreach ( var role in roles )
                        {
                            var roleExists = await roleManager.RoleExistsAsync( role );

                            if ( !roleExists )
                            {
                                await roleManager.CreateAsync( new IdentityRole
                                {
                                    Name = role
                                } );
                            }
                        }

                        var adminEmail = "xXxADMINxXx@ticketsystem.com";

                        var adminUser = await userManager.FindByEmailAsync( adminEmail );

                        if ( adminUser == null )
                        {
                            adminUser = new User
                            {
                                Email = adminEmail,
                                UserName = adminName,
                                Name = "Admin"
                            };

                            //TODO: below had var = 
                            await userManager.CreateAsync( adminUser, "admin12" );

                            await userManager.AddToRoleAsync( adminUser, adminName );
                        }
                    } )
                    .Wait();
            }

            return app;
        }
    }
}