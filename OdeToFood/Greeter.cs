namespace OdeToFood
{
    using Microsoft.Extensions.Configuration;
    using OdeToFood.Services.Interfaces;

    public class Greeter : IGreeter
    {
        private readonly IConfiguration _configuration;

        public Greeter(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetMessageOfTheDay()
        {
            return _configuration["Greeting"];
        }
    }
}
