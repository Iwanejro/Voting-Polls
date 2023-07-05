using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using VotingPolls.Configurations;
using VotingPolls.Contracts;
using VotingPolls.Data;
using VotingPolls.Repositories;

namespace VotingPolls
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
            var databaseUri = new Uri(databaseUrl);
            //var databaseUri = new Uri("xxx"); // for development:
            var userInfo = databaseUri.UserInfo.Split(':');

            var npgConnBuilder = new NpgsqlConnectionStringBuilder
            {
                Host = databaseUri.Host,
                Port = databaseUri.Port,
                Username = userInfo[0],
                Password = userInfo[1],
                Database = databaseUri.LocalPath.TrimStart('/'),
                SslMode = SslMode.Require,
                TrustServerCertificate = true
            };

            var connectionString = npgConnBuilder.ConnectionString;

            //var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            //builder.Services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(connectionString));
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);


            builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped<IVotingPollRepository, VotingPollRepository>();
            builder.Services.AddScoped<IAnswerRepository, AnswerRepository>();
            builder.Services.AddScoped<IVoteRepository, VoteRepository>();
            builder.Services.AddScoped<ICommentRepository, CommentRepository>();

            builder.Services.AddAutoMapper(typeof(MapperConfig));


            builder.Services.AddControllersWithViews();

            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();
            
            app.Run();
        }
    }

    
}