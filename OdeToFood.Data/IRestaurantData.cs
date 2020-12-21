using System;
using System.Collections.Generic;
using System.Text;
using OdeToFood.Core;
using System.Linq;

namespace OdeToFood.Data {
    public interface IRestaurantData {
        IEnumerable<Restaurant> GetRestaurants();
    }

    public class InMemoryRestaurantData: IRestaurantData {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData() {
            restaurants = new List<Restaurant>() {
                new Restaurant { Id = 1, Name = "Nick's Pizza", Location = "Missouri", Cuisine = CuisineType.Italian},
                new Restaurant { Id = 1, Name = "Nick's Pizza", Location = "Missouri", Cuisine = CuisineType.Mexican},
                new Restaurant { Id = 1, Name = "Nick's Pizza", Location = "Missouri", Cuisine = CuisineType.Indian},
            };
        }

        public IEnumerable<Restaurant> GetRestaurants() {
            return from r in restaurants orderby r.Name select r;
        }
    }
}