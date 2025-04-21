using AgricultureOptimization.Data;
using AgricultureOptimization.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Bson;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;


namespace AgricultureOptimization.Pages
{
    public class queryPageModel : PageModel
    {
        private readonly MongoService _mongoService;
        private readonly HttpClient _httpClient;
        public queryPageModel(MongoService mongoService, HttpClient httpClient)
        {
            _mongoService = mongoService;
            _httpClient = httpClient;
        }

        [BindProperty]

        //mongo Dblists to retrieve dataset
        public List<Weather> WeatherData { get; set; }
        public List<SoilComposition> SoilCompositionData { get; set; }
        public List<Crop> CropData { get; set; }

        //userlist to handle the flow of temporary user created rows
        public List<Weather> WeatherDataTemp { get; set; } = new List<Weather>();
        public List<SoilComposition> SoilCompositionsTemp { get; set; } = new List<SoilComposition>();
        public List<Crop> CropTemp { get; set; } = new List<Crop>();
        public IActionResult OnPost()
        {
            if ((Request.Form["action"] == "add"))
            {
                SoilComposition soil = new SoilComposition();
                var soilId = Convert.ToInt32($"{Request.Form["ID"]:f2}");
                soil.soil_moisture = Convert.ToDouble($"{Request.Form["soil_moisture"]:f2}");

                // Pass the soilId and soil_moisture to the view (frontend)
                ViewData["SoilId"] = soilId;
                ViewData["SoilMoisture"] = soil.soil_moisture;

                // Optionally, also pass the weatherId if needed
            }
            return RedirectToPage();
        }

        public async Task OnGetAsync()
        {
            CropData = await _mongoService.GetAllCrops();
            SoilCompositionData = await _mongoService.GetAllSoilComposition();
            WeatherData = await _mongoService.GetAllWeatherData();
        }

        // Method to fetch data from MongoDB and send to Flask API for prediction
        //public async Task<IActionResult> OnPostComputeTHIAsync()
        //{
        //    //if (Request.Form["action"] == "add")
        //    //{

        //    //}
        //        // Retrieve all data from MongoDB
        //        WeatherData = await _mongoService.GetAllWeatherData();
        //    SoilComposition = await _mongoService.GetAllSoilComposition();
        //    Crops = await _mongoService.GetAllCrops();

        //    // Here we assume you're processing the first record in each list
        //    var weather = WeatherData.FirstOrDefault();
        //    var soil = SoilComposition.FirstOrDefault();
        //    var crop = Crops.FirstOrDefault();

        //    // Check if data exists
        //    if (weather == null || soil == null || crop == null)
        //    {
        //        // Return error if any required data is missing
        //        return BadRequest("Missing required data.");
        //    }

        //    // Prepare the data for sending to Flask API
        //    var requestData = new
        //    {
        //        temperature = weather.temperature,
        //        humidity = weather.humidity,
        //        N = soil.N,
        //        P = soil.P,
        //        K = soil.K,
        //        organic_matter = soil.organic_matter,
        //        soil_moisture = soil.soil_moisture,
        //        rainfall = weather.rainfall,
        //        sunlight_exposure = weather.sunlight_exposure,
        //        co2_concentration = weather.co2_concentration
        //    };

        //    // Make the API call to Flask using the injected HttpClient
        //    var response = await _httpClient.PostAsJsonAsync("", requestData);

        //    // Check if the response is successful 
        //    if (response.IsSuccessStatusCode)
        //    {
        //        // Parse the response to update the Weather object (this depends on the Flask response structure)
        //        var predictionResult = await response.Content.ReadFromJsonAsync<Weather>();

        //        // You can then assign the predicted values to the properties of the Weather model
        //        if (predictionResult != null)
        //        {
        //            weather.THI = predictionResult.THI;
        //            weather.WAI = predictionResult.WAI;
        //            weather.PP = predictionResult.PP;
        //        }

        //        // Do something with the updated weather data (e.g., pass it to the view)
        //        ViewData["UpdatedWeather"] = weather;
        //        return Page();
        //    }
        //    else
        //    {
        //        // Handle error from Flask API
        //        return StatusCode((int)response.StatusCode, "Error communicating with Flask API.");
        //    }
        //}
        //public async Task<IActionResult> OnPostComputeNBRAsync()
        //{
        //    //if (Request.Form["action"] == "add")
        //    //{

        //    //}
        //    // Retrieve all data from MongoDB
        //    WeatherData = await _mongoService.GetAllWeatherData();
        //    SoilComposition = await _mongoService.GetAllSoilComposition();
        //    Crops = await _mongoService.GetAllCrops();

        //    // Here we assume you're processing the first record in each list
        //    var weather = WeatherData.FirstOrDefault();
        //    var soil = SoilComposition.FirstOrDefault();
        //    var crop = Crops.FirstOrDefault();

        //    // Check if data exists
        //    if (weather == null || soil == null || crop == null)
        //    {
        //        // Return error if any required data is missing
        //        return BadRequest("Missing required data.");
        //    }

        //    // Prepare the data for sending to Flask API
        //    var requestData = new
        //    {
        //        temperature = weather.temperature,
        //        humidity = weather.humidity,
        //        N = soil.N,
        //        P = soil.P,
        //        K = soil.K,
        //        organic_matter = soil.organic_matter,
        //        soil_moisture = soil.soil_moisture,
        //        rainfall = weather.rainfall,
        //        sunlight_exposure = weather.sunlight_exposure,
        //        co2_concentration = weather.co2_concentration
        //    };

        //    // Make the API call to Flask using the injected HttpClient
        //    var response = await _httpClient.PostAsJsonAsync("http://127.0.0.1:5000/predict", requestData);

        //    // Check if the response is successful
        //    if (response.IsSuccessStatusCode)
        //    {
        //        // Parse the response to update the Weather object (this depends on the Flask response structure)
        //        var predictionResult = await response.Content.ReadFromJsonAsync<SoilComposition>();

        //        // You can then assign the predicted values to the properties of the Weather model
        //        if (predictionResult != null)
        //        {
        //            soil.NBR = predictionResult.NBR;
        //            soil.SFI = predictionResult.SFI;
        //        }

        //        // Do something with the updated weather data (e.g., pass it to the view)
        //        ViewData["UpdatedWeather"] = soil;
        //        return Page();
        //    }
        //    else
        //    {
        //        // Handle error from Flask API
        //        return StatusCode((int)response.StatusCode, "Error communicating with Flask API.");
        //    }
        //}
        // Similarly add methods for NBR, SFI, PP, and WAI
    }
}
