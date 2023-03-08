using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics;
using ToweBones.Models;
using ToweBones.Data;
namespace ToweBones.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
        private UserManager<User> _userManager;
        private SkeleDAL _dal { get; set; }
		public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
		{
			_logger = logger;
			_dal = new SkeleDAL(context);
		}

		public IActionResult Index()
		{
            return View(_dal);
            //var user = _dal.GetUserByUsername(User.Identity.Name);
          
			
            //need to read up on how the MongoClient works in .NET before this works
            //	List<User> users = dali.GetUsers();
            //testUsr = users.First();
            return View(_dal);
		}
		public IActionResult Game()
		{
			return View();
		}

        public IActionResult Homepage()
        {
            return View(_dal);
        }



        public IActionResult Story()
		{
			WeatherNet.ClientSettings.SetApiKey("324b97110943279b777a4de1e5ea9f13");

			DaStory storytext;
			//https://api.open-meteo.com/v1/forecast?latitude=40.77&longitude=-111.89&hourly=rain,showers,snowfall,weathercode,cloudcover
			String wAPI;
			//int longi = LocationService.GetLongitude();
			//	int lat = LocationService.GetLatitude();
			GoogleApi.Entities.Maps.Geolocation.Request.GeolocationRequest req = new GoogleApi.Entities.Maps.Geolocation.Request.GeolocationRequest();
			req.Key = "AIzaSyBASJdBhRwVCwkBprmQ_BK7rgOzpakLoFo";
			double longi = GoogleApi.GoogleMaps.Geolocation.Query(req).Location.Longitude;
			double lat = GoogleApi.GoogleMaps.Geolocation.Query(req).Location.Latitude;
			/*	wAPI = "https://api.open-meteo.com/v1/forecast?latitude=" + lat + "&longitude=" + longi + "&hourly=weathercode";
				HttpClient httpClient;
				httpClient = new HttpClient();
				HttpResponseMessage response = httpClient.GetAsync(wAPI).Result;
				string json = response.Content.ReadAsStringAsync().Result;
				WeatherCodes weather 
			*/
			DaStory.Weather weat;
			var current = WeatherNet.Clients.CurrentWeather.GetByCoordinates(lat, longi);
			if (current.Success)
			{
				switch (current.Item.Title.ToLower())
				{
					case "clear":
						weat = DaStory.Weather.SUNNY;
						break;
					case "rain":
					case "drizzle":
						weat = DaStory.Weather.RAIN;
						break;
					case "snow":
						weat = DaStory.Weather.SNOW;
						break;
					case "clouds":
						weat = DaStory.Weather.CLOUDY;
						break;
					default:
						weat = DaStory.Weather.INSANEO_STYLE;
						break;
				}
			}
			else
			{
				weat = DaStory.Weather.INSANEO_STYLE;
			}
			storytext = new DaStory(weat);

			return View(storytext);

		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}