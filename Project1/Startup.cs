using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using BusinessLayer.UserService;
using System.Linq;
using DataAccessLayer.Entities;
using Microsoft.OpenApi.Models;
using BusinessLayer.ComputerService;

namespace Project1
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = new ConfigurationBuilder().AddJsonFile($"appsettings.{environment.EnvironmentName}.json").Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(option =>
            {
            option.UseSqlServer(Configuration["SqlServerConnectionString"],
            b => b.MigrationsAssembly("DataAccessLayer"));
            });

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
           {
               opt.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidateLifetime = true,
                   ValidIssuer = "http://localhost:47233/",
                   ValidAudience = "http://localhost:47233/",
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"))
               };
           });

            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IComputerService, ComputerService>();

            services.AddSwaggerGen(sw =>
            {
                sw.SwaggerDoc("v1", new OpenApiInfo {Title = "Swagger", Version = "version 1"});
            
            });

            services.AddControllersWithViews();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(sw =>
                {
                    sw.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1");
                });
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            SeedDefaultData(app);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    
        public void SeedDefaultData(IApplicationBuilder app)
        {
            var scopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();

            using (var scope = scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                if (dbContext.Users.FirstOrDefault(u => u.firstName == "John") == null)
                {
                    User johndoe = new User
                    {
                        firstName = "john",
                        lastName = "doe"
                    };
                    User andrey = new User
                    {
                        firstName = "and",
                        lastName = "rey"
                    };

                    dbContext.Users.Add(johndoe);
                    dbContext.Users.Add(andrey);
                    dbContext.SaveChanges();
                }
                if (dbContext.ComputerManufactyrers.FirstOrDefault() == null)
                {
                    var computerManufactyrerOne = new ComputerManufactyrer
                    {
                        ManufactyrerName = "Aser"
                    };
                    var computerManufactyrerTwo = new ComputerManufactyrer
                    {
                        ManufactyrerName = "Toshiba"
                    };
                    dbContext.AddRange(computerManufactyrerOne, computerManufactyrerTwo);
                    dbContext.SaveChanges();

                    var computerModelAserOne = new ComtuperModel
                    {
                        ModelName = "A1",
                        ComputerManufactyrerId = computerManufactyrerOne.Id

                    };
                    var computerModelAserTwo = new ComtuperModel
                    {
                        ModelName = "A2",
                        ComputerManufactyrerId = computerManufactyrerOne.Id

                    };
                    var computerModelToshibaOne = new ComtuperModel
                    {
                        ModelName = "Rapid",
                        ComputerManufactyrerId = computerManufactyrerTwo.Id

                    };
                    var computerModelToshibaTwo = new ComtuperModel
                    {
                        ModelName = "More fast",
                        ComputerManufactyrerId = computerManufactyrerTwo.Id
                    };

                    dbContext.AddRange(computerModelAserOne, computerModelAserTwo, computerModelToshibaOne, computerModelToshibaTwo);
                    dbContext.SaveChanges();

                    //var asersTagOne = new ComputerModelTag
                    //{
                    //    TagName = "asersTagOne",
                    //    TagMeta = "asersTagOne_Meta",
                    //    TagExpiration = "4/6/2021",
                    //    ComputerModelId = computerModelAserOne.Id
                    //};
                    //var asersTagTwo = new ComputerModelTag
                    //{
                    //    TagName = "asersTagTwo",
                    //    TagMeta = "asersTagTwo_Meta",
                    //    TagExpiration = "4/18/2021",
                    //    ComputerModelId = computerModelAserOne.Id
                    //};
                    //var asersTagThree = new ComputerModelTag
                    //{
                    //    TagName = "asersTagThree",
                    //    TagMeta = "asersTagThree_Meta",
                    //    TagExpiration = "4/24/2021",
                    //    ComputerModelId = computerModelAserOne.Id
                    //};
                    //var asersTagFour = new ComputerModelTag
                    //{
                    //    TagName = "asersTagFour",
                    //    TagMeta = "asersTagFour_Meta",
                    //    TagExpiration = "4/30/2021",
                    //    ComputerModelId = computerModelAserOne.Id
                    //};

                    //dbContext.AddRange(asersTagOne, asersTagTwo, asersTagThree, asersTagFour);
                    //dbContext.SaveChanges();
                }

                var compModelsTagsExpanded = dbContext.ComputerModelTags.ToList();
            }
        }
    
    }
}
