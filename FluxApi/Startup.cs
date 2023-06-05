using AuthCore.Repositories.Abstract;
using AuthCore.Repositories.Concrete;
using AuthCore.Services.Abstract;
using AuthCore.Services.Concrete;
using Flux.Data.DataContext;
using GameCore.Repositories.Abstract;
using GameCore.Repositories.Concrete;
using GamesCore.ModelData;
using GamesCore.Services.Abstract;
using GamesCore.Services.Concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using PaymentApi.Repositories.Abstract;
using PaymentApi.Repositories.Concrete;
using PaymentApi.Services.Abstract;
using PaymentApi.Services.Concrete;
using PlayersCore.Repositories.Abstract;
using PlayersCore.Repositories.Concrete;
using Stripe;
using System.Text;
using TeamsCore.Repositories.Abstract;
using TeamsCore.Repositories.Concrete;
using TeamsCore.Services.Abstract;
using TeamsCore.Services.Concrete;


namespace FluxApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true, 
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = "https://localhost:5001",
                        ValidAudience = "https://localhost:5001",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("variblehere@345"))
                    };
                });
            services.AddCors(options =>
            {
                options.AddPolicy("FluxCorsPlicy",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200/", "*")
                                .AllowAnyMethod() 
                                .AllowAnyHeader();
                                           
                    });
                    
            });
            services.AddDbContext<FluxDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllers();
            //services.AddControllers().AddNewtonsoftJson();
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IPlayerService, PlayerService>();
            services.AddTransient<ITeamService, TeamService>();
            services.AddTransient<IGameService, GameService>();
            services.AddTransient<IPaymentDetailService, PaymentDetailService>();
            services.AddTransient<IAuthRepository, AuthRepository>();
            services.AddTransient<IPlayersRepository,PlayersRepository>();
            services.AddTransient<ITeamRepository,TeamRepository>();
            services.AddTransient<IGameRepository, GameRepository>();
            services.AddTransient<IPaymentRepository, PaymentRepository>();
            //services.AddTransient<IFluxFileManagerService, FluxFileManagerService>();
            //services.AddTransient<IFluxFileManagerRepository, FluxFileManagerRepository>();
            services.AddMvc();
            services
                 .AddGraphQLServer()
                 .AddType<UpcomingGamesType>();
                 //.AddQueryType<Query>()
                 //.AddMutationType<Mutation>()
                 //.AddSubscriptionType<Subscription>()
                 //.AddFiltering()
                // .AddSorting();



        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
                IdentityModelEventSource.ShowPII = true;
            }

            StripeConfiguration.ApiKey = "sk_test_51HmMK1Dkg1t2kwCzSkqjEUoJeExNLwxE4r61bvI2RlhtZRouWdu6pvj1IwXVqW3Ofs4mTPxjxaYGPSIfjEgiKR6W00ErbyYaLd";
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseStaticFiles();
            app.UseCors(builder => builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed((host) => true)
                .AllowCredentials());
            app.UseAuthentication();
            app.UseAuthorization();
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //    //endpoints.MapControllerRoute(
            //    //name: "default",
            //    //pattern: "{controller=Player}/{action=Index}/{id?}"); ;
            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
               // endpoints.MapGraphQLPlayground();
            });


        }
    }
}
