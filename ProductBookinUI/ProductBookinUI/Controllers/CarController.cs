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
    public class CarController : Controller
    {
        // Display Car products
        public ActionResult GetCarProducts()
        {
            List<CarProduct> list = GetCarProductsList();

            return View(list);
        }

        public List<CarProduct> GetCarProductsList()
        {
            string url = "http://localhost:49896";

            List<CarProduct> carProduct = new List<CarProduct>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("/api/Car").Result;

                if (response.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    string CarProductResponse = response.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    return JsonConvert.DeserializeObject<List<CarProduct>>(CarProductResponse);

                }
            }
            return carProduct;
        }

        public List<CarProduct> AddProductIntoDB(CarProduct Product)
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

                HttpResponseMessage response = client.PostAsync("/api/Car", httpContent).Result;

                if (response.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    string ProductResponse = response.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    return JsonConvert.DeserializeObject<List<CarProduct>>(ProductResponse);

                }
            }
            return null;
        }

        public ActionResult AddCarProduct()
        {
            return View();
        }

        public List<CarProduct> SaveProductIntoDB(int productId)
        {

            string url = "http://localhost:49896";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var httpContent = new StringContent(JsonConvert.SerializeObject(productId), Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PutAsync("/api/Car/Save/" + productId, httpContent).Result;

                if (response.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    string ProductResponse = response.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    return JsonConvert.DeserializeObject<List<CarProduct>>(ProductResponse);

                }
            }
            return null;
        }

        public List<CarProduct> BookProductIntoDB(int productId)
        {

            string url = "http://localhost:49896";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var httpContent = new StringContent(JsonConvert.SerializeObject(productId), Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PutAsync("/api/Car/Book/" + productId, httpContent).Result;

                if (response.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    string ProductResponse = response.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    return JsonConvert.DeserializeObject<List<CarProduct>>(ProductResponse);

                }
            }
            return null;
        }

        public ActionResult GetSavedProds()
        {
            List<CarProduct> list = GetSavedProducts();
            return View(list);
        }

        public List<CarProduct> GetSavedProducts()
        {
            string url = "http://localhost:49896";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("/api/Car/GetSavedItems").Result;

                if (response.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    string ActivityProductResponse = response.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    return JsonConvert.DeserializeObject<List<CarProduct>>(ActivityProductResponse);
                }
            }
            return null;

        }

        public ActionResult GetBookedProds()
        {
            List<CarProduct> list = GetBookedProducts();
            return View(list);
        }
        public List<CarProduct> GetBookedProducts()
        {
            string url = "http://localhost:49896";


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("/api/Car/GetBookedItems").Result;

                if (response.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    string ActivityProductResponse = response.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    return JsonConvert.DeserializeObject<List<CarProduct>>(ActivityProductResponse);
                }
            }
            return null;

        }
    }
}