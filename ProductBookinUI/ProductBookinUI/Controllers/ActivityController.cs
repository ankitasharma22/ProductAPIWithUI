﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    public class ActivityController : Controller
    {
        // GET: Activity
        public ActionResult GetActivityProducts()
        {
            List<ActivityProduct> list = GetActivityProductsList();

            return View(list);
        }

        public List<ActivityProduct> GetActivityProductsList()
        {
            string url = "http://localhost:49896";

            List<ActivityProduct> activityProduct = new List<ActivityProduct>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("/api/Activity").Result;

                if (response.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    string ActivityProductResponse = response.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    return JsonConvert.DeserializeObject<List<ActivityProduct>>(ActivityProductResponse);

                }
            }
            return activityProduct;
        }

        //Insert
        public List<ActivityProduct> AddProductIntoDB(ActivityProduct activityProduct)
        {
           
            string url = "http://localhost:49896";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                activityProduct.isBooked = false;
                activityProduct.isSaved = false; 
                var httpContent = new StringContent(JsonConvert.SerializeObject(activityProduct), Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync("/api/Activity", httpContent).Result;

                if (response.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    string ActivityProductResponse = response.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    return JsonConvert.DeserializeObject<List<ActivityProduct>>(ActivityProductResponse);

                }
            }
            return null;
        }

        public ActionResult AddActivityProduct()
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

                HttpResponseMessage response = client.PutAsync("/api/Activity/Save/"+productId, httpContent).Result;

                if (response.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    string ActivityProductResponse = response.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    return JsonConvert.DeserializeObject<List<ActivityProduct>>(ActivityProductResponse);

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

                HttpResponseMessage response = client.PutAsync("/api/Activity/Book/" + productId, httpContent).Result;

                if (response.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    string ActivityProductResponse = response.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    return JsonConvert.DeserializeObject<List<ActivityProduct>>(ActivityProductResponse);

                }
            }
            return null;
        }

        public ActionResult SaveActivityProduct()
        {
            return View();
        }

        
    }
}