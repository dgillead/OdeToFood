namespace OdeToFood.Services
{
    using OdeToFood.Models;
    using OdeToFood.Services.Interfaces;
    using System.Collections.Generic;
    using System.Linq;

    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> _restaurants;

        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>
            {
                new Restaurant { Id = 1, Name = "Test Restaurant One" },
                new Restaurant { Id = 2, Name = "Test Restaurant Two" },
                new Restaurant { Id = 3, Name = "Test Restaurant Three" }
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants.OrderBy(r => r.Name);
        }

        public Restaurant GetRestaurantById(int id)
        {
            return _restaurants.FirstOrDefault(x => x.Id == id);
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            newRestaurant.Id = _restaurants.Count + 1;
            _restaurants.Add(newRestaurant);
            return newRestaurant;
        }
    }
}
