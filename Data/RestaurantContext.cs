﻿using Microsoft.EntityFrameworkCore;
using Restaurant_API.Models;

namespace Restaurant_API.Data
{
	public class RestaurantContext : DbContext
	{
        public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
		public DbSet<Dish> Menu { get; set; }
		public DbSet<Reservation> Reservations { get; set; }
		public DbSet<Table> Tables { get; set; }
	}
}