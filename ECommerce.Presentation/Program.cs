using ECommerce.Context;
using ECommerce.Repositories.Contract;
using ECommerce.Repositories.Repository;
using ECommerce.Services;
using ECommerce.Services.MapperProfile;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace ECommerce.Presentation
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddScoped<IProductRepository, ProductRepository>();
			builder.Services.AddScoped<IProductService, ProductService>();
			builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
			builder.Services.AddScoped<ICategoryService, CategoryService>();
			builder.Services.AddScoped<IOrderRepository, OrderRepository>();
			builder.Services.AddScoped<IOrderService, OrderService>();
			builder.Services.AddDbContext<DBContext>(op => {
				op.UseSqlServer(builder.Configuration.GetConnectionString("DB"));
			});

			builder.Services.AddAutoMapper(op =>
			{
				op.AddProfile(new MapperProfile());
			});
			builder.Services.AddControllers();
		

			
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();


			builder.Services.AddIdentity<ApplicationUser, IdentityRole>(op => op.SignIn.RequireConfirmedAccount = false)
			   .AddEntityFrameworkStores<DBContext>();

			builder.Services.AddAuthentication(op =>
			{
				op.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				op.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(op =>
			{
				op.TokenValidationParameters = new TokenValidationParameters
				{
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["jwt:key"])),
					ValidateIssuerSigningKey = true,
					//ValidAudience = builder.Configuration["jwt:audience"],
					//ValidateAudience = true,
					//ValidIssuer = builder.Configuration["jwt:issuer"],
					//ValidateIssuer = true,
					ValidateAudience = false,
					ValidateIssuer = false,
				};
			});

			builder.Services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

				// Define the OAuth2.0 scheme that's in use (i.e., Implicit, Password, Application and AccessCode)
				c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
					Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
					Name = "Authorization",
					In = ParameterLocation.Header,
					Type = SecuritySchemeType.ApiKey,
					Scheme = "Bearer"
				});

				c.AddSecurityRequirement(new OpenApiSecurityRequirement
				   {
					 {
				new OpenApiSecurityScheme
				{
					Reference = new OpenApiReference
					{
						Type = ReferenceType.SecurityScheme,
						Id = "Bearer"
					},
					Scheme = "oauth2",
					Name = "Bearer",
					In = ParameterLocation.Header
				},
				new List<string>()
			}
			   });
			});

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}
			//app.UseAuthentication();
			app.UseAuthentication();
			app.UseAuthorization();
	
			app.MapControllers();

			app.Run();
		}
	}
}