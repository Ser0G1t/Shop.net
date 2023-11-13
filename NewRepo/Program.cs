using Microsoft.AspNetCore.Identity;
using NewRepo.Context;
using NewRepo.Entity;
using NewRepo.Facade;
using NewRepo.IRepository;
using NewRepo.IService;
using NewRepo.Middleware;
using NewRepo.Profiles;
using NewRepo.Repository;
using NewRepo.Service;
using System.Text.Json.Serialization;

namespace NewRepo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //repositories
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IInvoiceCrudRepository, InvoiceRepository>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();

            //services
            builder.Services.AddScoped<IProductService, ProductCrudService>();
            builder.Services.AddScoped<IInvoiceService, InvoiceService>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IPrintService, PrintService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IImportService, ImportService>();

            //facade
            builder.Services.AddScoped<IOrderFacade, OrderFacade>();

            //mappers injections
            builder.Services.AddAutoMapper(typeof(ProductProfile));
            builder.Services.AddAutoMapper(typeof(OrderProfile));

            //other
            builder.Services.AddScoped<CoreContext>();
            builder.Services.AddScoped<ExceptionHandler>();
            builder.Services.AddScoped<IPasswordHasher<User>,PasswordHasher<User>> ();
            //enum conventer
            builder.Services.AddMvc().AddJsonOptions(opts =>{
                var enumConverter = new JsonStringEnumConverter();
                opts.JsonSerializerOptions.Converters.Add(enumConverter);
            });
            //json serializers for collections
            builder.Services.AddControllersWithViews()
            .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            var app = builder.Build();
            app.UseMiddleware<ExceptionHandler>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}