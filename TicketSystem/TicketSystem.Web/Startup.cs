using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TicketSystem.Data;
using TicketSystem.Data.Models;
using TicketSystem.Web.Extensions;
using TicketSystem.Web.Services;

namespace TicketSystem.Web
{
    public class Startup
    {
        public Startup( IConfiguration configuration )
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices( IServiceCollection services )
        {
            services.AddDbContext< TicketSystemDbContext >( options =>
                options.UseSqlServer( this.Configuration.GetConnectionString( "DefaultConnection" ) ) );

            services.AddIdentity< User, IdentityRole >( options =>
                {
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequireNonAlphanumeric = false;
                } )
                .AddEntityFrameworkStores< TicketSystemDbContext >()
                .AddDefaultTokenProviders();

            services.AddAuthentication().AddFacebook( facebookOptions =>
            {
                facebookOptions.AppId = this.Configuration[ "Authentication:Facebook:AppId" ];
                facebookOptions.AppSecret = this.Configuration[ "Authentication:Facebook:AppSecret" ];
            } );

            services.Configure< MvcOptions >( options => { options.Filters.Add( new RequireHttpsAttribute() ); } );

            services.AddTransient< IEmailSender, EmailSender >();

            services.AddMemoryCache();

            services.AddDomainServices();

            services.AddRouting( opt => opt.LowercaseUrls = true );

            services.AddMvc( options => { options.Filters.Add< AutoValidateAntiforgeryTokenAttribute >(); } );

            services.AddAutoMapper();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure( IApplicationBuilder app, IHostingEnvironment env )
        {
            app.UseDatabaseMigration();

            if ( env.IsDevelopment() )
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler( "/Home/Error" );
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc( routes =>
            {
                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}" );
            } );
        }
    }
}