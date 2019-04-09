namespace OdeToFood.Services.Interfaces
{
    using OdeToFood.Models;
    using System.Collections.Generic;

    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        Restaurant GetRestaurantById(int id);
        Restaurant Add(Restaurant newRestaurant);
    }
}
