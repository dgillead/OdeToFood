namespace OdeToFood.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using OdeToFood.Models;
    using OdeToFood.Services.Interfaces;
    using OdeToFood.ViewModels;

    [Route("")]
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;
        private IGreeter _greeter;

        public HomeController(IRestaurantData restaurantData, IGreeter greeter)
        {
            _restaurantData = restaurantData;
            _greeter = greeter;
        }

        [Route("")]
        public IActionResult Index()
        {
            var model = new HomeIndexViewModel
            {
                Restaurants = _restaurantData.GetAll(),
                CurrentMessage = _greeter.GetMessageOfTheDay()
            };

            return View(model);
        }

        [Route("details/{id}")]
        public IActionResult Details(int id)
        {
            var model = _restaurantData.GetRestaurantById(id);
            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet, Route("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, Route("create")]
        public IActionResult Create(RestaurantEditModel model)
        {
            var newRestaurant = new Restaurant
            {
                Name = model.Name,
                Cuisine = model.Cuisine
            };
            newRestaurant = _restaurantData.Add(newRestaurant);

            return View("Details", newRestaurant);
        }
    }
}
