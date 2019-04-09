namespace OdeToFood.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [Route("[controller]")]
    public class AboutController
    {
        [Route("[action]")]
        public string Phone()
        {
            return "123-456-7890";
        }

        [Route("[action]")]
        public string Address()
        {
            return "USA";
        }
    }
}
