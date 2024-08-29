
using Microsoft.EntityFrameworkCore;
using Restaurant_API.Data;
using Restaurant_API.Repository;
using Restaurant_API.Repository.IRepository;
using Restaurant_API.Services;
using Restaurant_API.Services.IServices;

namespace Restaurant_API
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
			builder.Services.AddDbContext<RestaurantContext>(options =>
			{
				options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
			});
			builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
			builder.Services.AddScoped<ITableRepository, TableRepository>();
			builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
			builder.Services.AddScoped<IReservationService, ReservationService>();

			var app = builder.Build();

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
