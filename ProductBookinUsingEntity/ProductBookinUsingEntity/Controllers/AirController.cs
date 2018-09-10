﻿using Newtonsoft.Json.Linq;
using SQLConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProductBookinUsingEntity.Controllers
{
    public class AirController : ApiController, IProduct
    {

        ProductBookingWebAPIEntities1 entity = new ProductBookingWebAPIEntities1();
        AirProduct airProduct = new AirProduct();
        public IEnumerable<AirProduct> GetValue()
        {
            return entity.AirProducts.ToList();
        }
         
      
        [HttpPost]
        public void Post([FromBody]JObject jsonFormatInput)
        {
            AirStrategy strategy = new AirStrategy(); 
            AirProduct product = entity.AirProducts.Add(jsonFormatInput.ToObject<AirProduct>());
            product.Price = strategy.FareCalculation(product.Price);
            entity.SaveChanges();
        }

        [HttpPut]
        [Route("api/Air/Book/{id}")]
        public void Book([FromUri] int id)
        {
           
            airProduct = entity.AirProducts.Find(id); 
                airProduct.isBooked = true; 
            entity.SaveChanges();
        }


        [HttpPut]
        [Route("api/Air/Save/{id}")]
        public void Save([FromUri] int id)
        {
            
            airProduct = entity.AirProducts.Find(id); 
                airProduct.isSaved = true; 
            entity.SaveChanges();
        }


        [HttpGet]
        [Route("api/Air/GetSavedItems")]
        public IEnumerable<AirProduct> GetSavedItems()
        {
            IEnumerable<AirProduct> enumerable = GetValue();
            List<AirProduct> airItems = enumerable.ToList();
            List<AirProduct> airSavedItems = new List<AirProduct>();

            for (int i = 0; i < airItems.Count; i++)
            {
                airProduct = airItems[i];
                if (airProduct.isSaved == true)
                {
                    airSavedItems.Add(airProduct);
                }
            }
            return airSavedItems;
        }


        [HttpGet]
        [Route("api/Air/GetBookedItems")]
        public IEnumerable<AirProduct> GetBookedItems()
        {
            IEnumerable<AirProduct> enumerable = GetValue();
            List<AirProduct> airItems = enumerable.ToList();
            List<AirProduct> airBookedItems = new List<AirProduct>();

            for (int i = 0; i < airItems.Count; i++)
            {
                airProduct = airItems[i];
                if (airProduct.isBooked == true)
                {
                    airBookedItems.Add(airProduct);
                }
            }
            return airBookedItems;
        }
    }
}
