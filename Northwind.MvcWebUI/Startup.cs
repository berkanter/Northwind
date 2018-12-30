using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Northwind.Business.Abstract;
using Northwind.Business.Concrete;
using Northwind.DataAccess.Abstract;
using Northwind.DataAccess.Concrete.EntityFramework;
using Northwind.MvcWebUI.Services;

namespace Northwind.MvcWebUI
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
			services.AddScoped<ICategoryService, CategoryManager>();
			services.AddScoped<ICategoryDal, EfCategoryDal>();

			services.AddScoped<IProductService, ProductManager>();
			services.AddScoped<IProductDal, EfProductDal>();

			services.AddSingleton<ICartSessionService, CartSessionService>();
			services.AddScoped<ICartService, CartService>();

			services.AddScoped<IUserService, UserManager>();
			services.AddScoped<IUserDal, EfUserDal>();

			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

			services.AddSession();
			services.AddDistributedMemoryCache();

			services.AddAuthentication("DefaultCookie").AddCookie("DefaultCookie", options => {
				options.LoginPath = "/Account/Login";
			});

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
		}
		
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseSession();
			app.UseAuthentication();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}