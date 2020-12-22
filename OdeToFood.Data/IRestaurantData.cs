using System;
using System.Collections.Generic;
using System.Text;
using OdeToFood.Core;
using System.Linq;

namespace OdeToFood.Data {
    public interface IRestaurantData {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
    }

    public class InMemoryRestaurantData: IRestaurantData {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData() {
            restaurants = new List<Restaurant>() {
                new Restaurant { Id = 1, Name = "Sarpino's", Location = "Kansas", Cuisine = CuisineType.Italian},
                new Restaurant { Id = 1, Name = "Pancho's", Location = "Missouri", Cuisine = CuisineType.Mexican},
                new Restaurant { Id = 1, Name = "Papu's", Location = "Missouri", Cuisine = CuisineType.Greek},
            };
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null) {
            return from r in restaurants 
                where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                orderby r.Name 
                select r;
        }
    }
}