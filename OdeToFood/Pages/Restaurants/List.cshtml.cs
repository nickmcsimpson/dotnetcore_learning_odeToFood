using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Data;
using OdeToFood.Core;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration configuration;
        private readonly IRestaurantData restaurantData;
        [BindProperty(SupportsGet = true)]// Looks for value before onGet, only on Post without flag
        public string SearchTerm { get; set; } // property can be output or input model

        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }

        public ListModel(IConfiguration configuration, 
                        IRestaurantData restaurantData) {
            this.configuration = configuration;
            this.restaurantData = restaurantData;
        }
        public void OnGet() // (string searchTerm) will look for this value by name, null by default, string works with this
        {
            // For all razor pages, access but better to use binding ^
            // HttpContext.Request.QueryString

            // SearchTerm = searchTerm; There is an easier way

            Message = configuration["Message"];
            // Restaurants = restaurantData.GetRestaurants();
            // Using model binding for input data
            Restaurants = restaurantData.GetRestaurantsByName(SearchTerm);
            // This grabbs search term from the queryString, but doesn't keep the value in the input box
        }
    }
}