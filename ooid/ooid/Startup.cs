using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ooid.Context;
using ooid.Models;
using OpenIddict.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ooid
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(); services.AddControllersWithViews();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
                {
                    options.LoginPath = "/account/login";
                });


            services.AddDbContext<ApplicationDbContext>(options =>
            {
                // Configure the context to use an in-memory store.
                options.UseSqlServer(Configuration.GetConnectionString("DbConstring"));


                // Register the entity sets needed by OpenIddict.
                options.UseOpenIddict();
            });

            // OpenID Connect server configuration
            services.AddOpenIddict()
                .AddCore(options => options.UseEntityFrameworkCore().UseDbContext<ApplicationDbContext>())
                .AddServer(options =>
                {
                    // Enable the required endpoints
                    options.SetTokenEndpointUris("/connect/token");
                    options.SetUserinfoEndpointUris("/connect/userinfo");

                    options.AllowPasswordFlow();
                    options.AllowRefreshTokenFlow();
                    // Add all auth flows you want to support
                    // Supported flows are:
                    //      - Authorization code flow
                    //      - Client credentials flow
                    //      - Device code flow
                    //      - Implicit flow
                    //      - Password flow
                    //      - Refresh token flow

                    // Custom auth flows are also supported
                    options.AllowCustomFlow("custom_flow_name");

                    // Using reference tokens means the actual access and refresh tokens
                    // are stored in the database and different tokens, referencing the actual
                    // tokens (in the db), are used in request headers. The actual tokens are not
                    // made public.
                    options.UseReferenceAccessTokens();
                    options.UseReferenceRefreshTokens();

                    // Register your scopes - Scopes are a list of identifiers used to specify
                    // what access privileges are requested.
                    options.RegisterScopes(OpenIddictConstants.Permissions.Scopes.Email,
                                                OpenIddictConstants.Permissions.Scopes.Profile,
                                                OpenIddictConstants.Permissions.Scopes.Roles);

                    // Set the lifetime of your tokens
                    options.SetAccessTokenLifetime(TimeSpan.FromMinutes(30));
                    options.SetRefreshTokenLifetime(TimeSpan.FromDays(7));

                    // Register signing and encryption details
                    options.AddDevelopmentEncryptionCertificate()
                                    .AddDevelopmentSigningCertificate();

                    // Register ASP.NET Core host and configuration options
                    options.UseAspNetCore().EnableTokenEndpointPassthrough();
                })
                .AddValidation(options =>
                {
                    options.UseLocalServer();
                    options.UseAspNetCore();
                });

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = OpenIddictConstants.Schemes.Bearer;
                options.DefaultChallengeScheme = OpenIddictConstants.Schemes.Bearer;
            });
            services.AddIdentity<User, Role>()
    .AddSignInManager()
    .AddUserStore<UserStore>()
    .AddRoleStore<RoleStore>()
    .AddUserManager<UserManager<User>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller=Home}/{action=Index}/{id?}");
            //});
            using var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            context.Database.EnsureCreated();

            var manager = scope.ServiceProvider.GetRequiredService<IOpenIddictApplicationManager>();
            var existingClientApp = manager.FindByClientIdAsync("default-client").GetAwaiter().GetResult();
            if (existingClientApp == null)
            {
                manager.CreateAsync(new OpenIddictApplicationDescriptor
                {
                    ClientId = "default-client",
                    ClientSecret = "499D56FA-B47B-5199-BA61-B298D431C318",
                    DisplayName = "Default client application",
                    PostLogoutRedirectUris = { new Uri("https://localhost:5001/signout-callback-oidc") },
                    RedirectUris = { new Uri("https://localhost:5001/signout-oidc") },
                    Permissions =
        {
            OpenIddictConstants.Permissions.Endpoints.Token,
            OpenIddictConstants.Permissions.GrantTypes.Password
        }
                }).GetAwaiter().GetResult();
            }
            CreateSeedUser(app);
        }
        private static void CreateSeedUser(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var user = new User
            {
                Username = "test_user1",
                UserRoles = new List<UserRole>
                {
                    new UserRole { Role = new Role { Name = "admin1", NormalizedName = "ADMIN1" } }
                }
            };

            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
            var existingUser = userManager.FindByNameAsync(user.Username).GetAwaiter().GetResult();
            if (existingUser == null)
            {
                var hash = userManager.PasswordHasher.HashPassword(user, "Test1234!1");
                user.PasswordHash = hash;
                userManager.CreateAsync(user).GetAwaiter().GetResult();
            }
        }
    }
}
