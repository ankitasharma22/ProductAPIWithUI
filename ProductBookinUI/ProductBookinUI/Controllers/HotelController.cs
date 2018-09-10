using Newtonsoft.Json;
using ProductBookinUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ProductBookinUI.Controllers
{
    public class HotelController : Controller
    {
        // GET: Hotel
        public ActionResult GetHotelProducts()
        {
            List<HotelProduct> list = GetHotelProductsList();

            return View(list);
        }

        public List<HotelProduct> GetHotelProductsList()
        {
            string url = "http://localhost:49896";

            List<HotelProduct> hotelProduct = new List<HotelProduct>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("/api/Hotel").Result;

                if (response.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    string HotelProductResponse = response.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    return JsonConvert.DeserializeObject<List<HotelProduct>>(HotelProductResponse);

                }
            }
            return hotelProduct;
        }

        public List<HotelProduct> AddProductIntoDB(HotelProduct Product)
        {

            string url = "http://localhost:49896";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                Product.isBooked = false;
                Product.isSaved = false;
                var httpContent = new StringContent(JsonConvert.SerializeObject(Product), Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync("/api/Hotel", httpContent).Result;

                if (response.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    string ProductResponse = response.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    return JsonConvert.DeserializeObject<List<HotelProduct>>(ProductResponse);

                }
            }
            return null;
        }

        public ActionResult AddHotelProduct()
        {
            return View();
        }

        public List<HotelProduct> SaveProductIntoDB(int productId)
        {

            string url = "http://localhost:49896";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var httpContent = new StringContent(JsonConvert.SerializeObject(productId), Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PutAsync("/api/Hotel/Save/" + productId, httpContent).Result;

                if (response.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    string ProductResponse = response.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    return JsonConvert.DeserializeObject<List<HotelProduct>>(ProductResponse);

                }
            }
            return null;
        }

        public List<HotelProduct> BookProductIntoDB(int productId)
        {

            string url = "http://localhost:49896";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var httpContent = new StringContent(JsonConvert.SerializeObject(productId), Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PutAsync("/api/Hotel/Book/" + productId, httpContent).Result;

                if (response.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    string ProductResponse = response.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    return JsonConvert.DeserializeObject<List<HotelProduct>>(ProductResponse);

                }
            }
            return null;
        }
        public ActionResult GetSavedProds()
        {
            List<HotelProduct> list = GetSavedProducts();
            return View(list);
        }

        public List<HotelProduct> GetSavedProducts()
        {
            string url = "http://localhost:49896";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("/api/Hotel/GetSavedItems").Result;

                if (response.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    string ActivityProductResponse = response.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    return JsonConvert.DeserializeObject<List<HotelProduct>>(ActivityProductResponse);
                }
            }
            return null;

        }

        public ActionResult GetBookedProds()
        {
            List<HotelProduct> list = GetBookedProducts();
            return View(list);
        }
        public List<HotelProduct> GetBookedProducts()
        {
            string url = "http://localhost:49896";


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("/api/Hotel/GetBookedItems").Result;

                if (response.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    string ActivityProductResponse = response.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    return JsonConvert.DeserializeObject<List<HotelProduct>>(ActivityProductResponse);
                }
            }
            return null;

        }
    }
}