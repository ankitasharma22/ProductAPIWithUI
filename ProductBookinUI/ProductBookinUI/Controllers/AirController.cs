using ProductBookinUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Text;

namespace ProductBookinUI.Controllers
{
    public class AirController : Controller
    {
        public ActionResult GetAirProducts()
        {
            List<AirProduct> list = GetAirProductsList();

            return View(list);
        }

        public List<AirProduct> GetAirProductsList()
        {
            string url = "http://localhost:49896";
            List<AirProduct> airProduct = new List<AirProduct>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("/api/Air").Result;

                if (response.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    string AirProductResponse = response.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    return JsonConvert.DeserializeObject<List<AirProduct>>(AirProductResponse);

                }
            }
            return airProduct;
        }

        //Insert
        public List<AirProduct> AddProductIntoDB(AirProduct airProduct)
        {

            string url = "http://localhost:49896";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                airProduct.isBooked = false;
                airProduct.isSaved = false;
                var httpContent = new StringContent(JsonConvert.SerializeObject(airProduct), Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync("/api/Air", httpContent).Result;

                if (response.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    string ProductResponse = response.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    return JsonConvert.DeserializeObject<List<AirProduct>>(ProductResponse);

                }
            }
            return null;
        }

        public ActionResult AddAirProduct()
        {
            return View();
        }

        public List<ActivityProduct> SaveProductIntoDB(int productId)
        {

            string url = "http://localhost:49896";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var httpContent = new StringContent(JsonConvert.SerializeObject(productId), Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PutAsync("/api/Air/Save/" + productId, httpContent).Result;

                if (response.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    string ProductResponse = response.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    return JsonConvert.DeserializeObject<List<ActivityProduct>>(ProductResponse);

                }
            }
            return null;
        }

        public List<ActivityProduct> BookProductIntoDB(int productId)
        {

            string url = "http://localhost:49896";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var httpContent = new StringContent(JsonConvert.SerializeObject(productId), Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PutAsync("/api/Air/Book/" + productId, httpContent).Result;

                if (response.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    string ProductResponse = response.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    return JsonConvert.DeserializeObject<List<ActivityProduct>>(ProductResponse);

                }
            }
            return null;
        }

        public ActionResult GetSavedProds()
        {
            List<AirProduct> list = GetSavedProducts();
            return View(list);
        }

        public List<AirProduct> GetSavedProducts()
        {
            string url = "http://localhost:49896";
 
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("/api/Air/GetSavedItems").Result;

                if (response.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    string ActivityProductResponse = response.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    return JsonConvert.DeserializeObject<List<AirProduct>>(ActivityProductResponse);
                }
            }
            return null;

        }

        public ActionResult GetBookedProds()
        {
            List<AirProduct> list = GetBookedProducts();
            return View(list);
        }
        public List<AirProduct> GetBookedProducts()
        {
            string url = "http://localhost:49896";
 

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("/api/Air/GetBookedItems").Result;

                if (response.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    string ActivityProductResponse = response.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    return JsonConvert.DeserializeObject<List<AirProduct>>(ActivityProductResponse);
                }
            }
            return null;

        }
    }
}