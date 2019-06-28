namespace OdeToFood.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using OdeToFood.Data;
    using OdeToFood.Models;
    using OdeToFood.Services.Interfaces;


    public class SqlRestaurantData : IRestaurantData
    {
        private OdeToFoodDbContext _odeToFoodDbContext;

        public SqlRestaurantData(OdeToFoodDbContext odeToFoodDbContext)
        {
            _odeToFoodDbContext = odeToFoodDbContext;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            _odeToFoodDbContext.Restaurants.Add(newRestaurant);
            _odeToFoodDbContext.SaveChanges();
            return newRestaurant;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _odeToFoodDbContext.Restaurants.OrderBy(r => r.Name);
        }

        public Restaurant GetRestaurantById(int id)
        {
            return _odeToFoodDbContext.Restaurants.FirstOrDefault(r => r.Id == id);
        }
    }
}
