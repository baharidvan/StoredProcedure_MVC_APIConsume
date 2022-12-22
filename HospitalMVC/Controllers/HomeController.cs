using HospitalMVC.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HospitalMVC.Controllers
{
    public class HomeController:Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            //var model = new List<object>();
            var client = _httpClientFactory.CreateClient();
            var doctorListResponse = await client.GetAsync("https://localhost:7080/api/Home/GetDoctors");
            var doctorDepartmentResponse = await client.GetAsync("https://localhost:7080/api/Home/Index");
            if (doctorListResponse.StatusCode == System.Net.HttpStatusCode.OK && doctorDepartmentResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonDataDL = await doctorListResponse.Content.ReadAsStringAsync();
                var resultDL = JsonConvert.DeserializeObject<List<DoctorListModel>>(jsonDataDL);
                var jsonDataDD = await doctorListResponse.Content.ReadAsStringAsync();
                var resultDD = JsonConvert.DeserializeObject<List<DoctorDepartmentModel>>(jsonDataDD);

                //model.Add(result);
                var model = new HomePageViewModel
                {
                    DoctorListModels = resultDL,
                    DoctorDepartmentModels = resultDD
                };
                return View(model);
            }
            else
            {
                return View(null);
            }
        }
    }
}
