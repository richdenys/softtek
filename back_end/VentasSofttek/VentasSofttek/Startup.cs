using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasSofttek.DAL.DBContext;
using VentasSofttek.DTO.Service;
using VentasSofttek.Models.Common;
using VentasSofttek.Models.GesVentas;
using VentasSofttek.Models.Login;

namespace VentasSofttek
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
            // Add Cors
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddDbContext<VentasSofttekDBContext>(options => options.UseInMemoryDatabase(Configuration.GetConnectionString("MyDb")));


            services.AddControllers();


            var appSettingsSecction = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSecction);

            //JWT

            var appSettings = appSettingsSecction.Get<AppSettings>();
            var llave = Encoding.ASCII.GetBytes(appSettings.Secreto);


            services.AddAuthentication(d =>
            {
                d.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                d.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }
             ).AddJwtBearer(d =>
             {
                 d.RequireHttpsMetadata = false;
                 d.SaveToken = true;
                 d.TokenValidationParameters = new TokenValidationParameters()
                 {
                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = new SymmetricSecurityKey(llave),
                     ValidateIssuer = false,
                     ValidateAudience = false,
                 };
             });



            services.AddScoped<IUserService, UserService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(o =>
            {
                o.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<VentasSofttekDBContext>();
            SeetData(context);
        }


        public static void SeetData(VentasSofttekDBContext context)
        {

            AuthRequest us1 = new AuthRequest()
            {
                ID = 1,
                Email = "demo@demo.pe",
                Password = "123"
            };
            AuthRequest us2 = new AuthRequest()
            {
                ID = 2,
                Email = "rich@demo.pe",
                Password = "123"
            };
            context.MUsers.Add(us1);
            context.MUsers.Add(us2);


            Product product = new Product()
            {
                ID = 1,
                Description = "Software ERP",
                Price = 250,
                Stock = 150
            };
            Product product1 = new Product()
            {
                ID = 2,
                Description = "Paginas Web",
                Price = 600,
                Stock = 500
            };
            context.Prodcuts.Add(product);
            context.Prodcuts.Add(product1);

            Clients c1 = new Clients() {
                ID = 1,
                Nombres = "Richard",
                Apellidos = "De la cruz ",
                DNI = "55656646",
                Email = "rimnmchjc@jdk.com",
                Phone = "950390388"
            };
            Clients c2 = new Clients()
            {
                ID = 2,
                Nombres = "denys",
                Apellidos = "leandro",
                DNI = "55656646",
                Email = "leanbdro@jdk.com",
                Phone = "1848848548"
            };
            context.Clients.Add(c1);
            context.Clients.Add(c2);

            Ventas v1 = new Ventas()
            {
                ID = 1,
                NumDocumento = "00001",
                Cantidad = 2,
                CodClient = "1",
                CodFormaPago = "efectivo",
                CodSucursal = "0001",
                CodVendedor = "1",
                Total = 200,
                Precio=100,
                FechaVenta = DateTime.Now.ToString("yyyy-MM-dd"),
                
            };
            
            Ventas v2 = new Ventas()
            {
                ID = 2,
                NumDocumento = "00002",
                Cantidad = 3,
                CodClient = "1",
                CodFormaPago = "efectivo",
                Total=300,
                CodSucursal = "0001",
                CodVendedor = "1",
                FechaVenta ="01-02-2023",
                Precio = 100,
            };
          

            Ventas v3 = new Ventas()
            {
                ID = 3,
                NumDocumento = "00003",
                Cantidad = 5,
                CodClient = "1",
                CodFormaPago = "efectivo",
                Total = 500,
                Precio=100,
                CodSucursal = "0001",
                CodVendedor = "1",
                FechaVenta = "01-01-2023",

            };

            Ventas v4 = new Ventas()
            {
                ID = 4,
                NumDocumento = "00004",
                Cantidad = 3,
                CodClient = "2",
                CodFormaPago = "tarjeta",
                Total=75,
                Precio=25,
                CodSucursal = "0001",
                CodVendedor = "1",
                FechaVenta = "15-01-2023",

            };

            context.Ventas.Add(v1);
           
            context.Ventas.Add(v2);
           
            context.Ventas.Add(v3);
            
            context.Ventas.Add(v4);
            context.SaveChanges();



        }


    }
}
