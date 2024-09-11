using Restaurant_API.Models;
using Restaurant_API.Models.DTOs;
using Restaurant_API.Repository.IRepository;
using Restaurant_API.Services.IServices;

namespace Restaurant_API.Services
{
	public class CustomerService : ICustomerService
	{
		private readonly ICustomerRepository _customerRepo;
        public CustomerService(ICustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
        }
        public async Task CreateCustomer(CustomerDTO customerDTO)
		{
			await _customerRepo.CreateCustomer(new Customer
			{
				Name = customerDTO.Name,
				Phone = customerDTO.PhoneNr
			});
		}

		public async Task DeleteCustomer(int id)
		{
			await _customerRepo.DeleteCustomer(id);
		}

		public async Task<IEnumerable<CustomerDTO>> GetAllCustomers()
		{
			var customers = await _customerRepo.GetAllCustomers();
			return customers.Select(c => new CustomerDTO
			{
				Name = c.Name,
				PhoneNr = c.PhoneNr,
			}
		}

		public Task<CustomerDTO> GetCustomerById(int id)
		{
			throw new NotImplementedException();
		}

		public Task UpdateCustomer(CustomerDTO customerDTO)
		{
			try
			{
				await _customerRepo.upd(oldDishId, new Dish
				{
					DishName = NewDishdto.DishName,
					IsAvailable = NewDishdto.IsAvailable,
					PriceInSek = NewDishdto.PriceInSek
				});
				return NewDishdto;
			}
			catch
			{
				return null;
			}
		}

		public async Task CreateDish(DishDTO dto)
		{
			ArgumentNullException.ThrowIfNull(dto);

			try
			{
				await _menuRepo.CreateDish(new Dish
				{
					DishName = dto.DishName,
					PriceInSek = dto.PriceInSek,
					IsAvailable = dto.IsAvailable,
				});
			}
			catch
			{
				return null;
			}
		}

		public async Task<DishDTO> UpdateDish(int oldDishId, DishDTO NewDishdto)
		{
			try
			{
				await _menuRepo.UpdateDish(oldDishId, new Dish
				{
					DishName = NewDishdto.DishName,
					IsAvailable = NewDishdto.IsAvailable,
					PriceInSek = NewDishdto.PriceInSek
				});
				return NewDishdto;
			}
			catch
			{
				return null;
			}
		}

		public async Task DeleteDish(int id)
		{
			await _menuRepo.DeleteDish(id); //Try catch in controller
		}

		public async Task<IEnumerable<DishDTO>> GetAllDishes()
		{
			var dishes = await _menuRepo.GetAllDishes();
			var dishesDto = dishes.Select(d => new DishDTO
			{
				DishName = d.DishName,
				IsAvailable = d.IsAvailable,
				PriceInSek = d.PriceInSek
			}).ToList();

			return dishesDto;
		}
	}
}
