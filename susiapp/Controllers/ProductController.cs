using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace susi_app.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private ICustomerAppService _customerAppService;

        public ProductController(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService;
        }
        private static IList<Product> Products = new List<Product>() {
            new Product() { 
                Description= "Tenis Adidas",
                Code = "KOP210",
                ProductPrice = new { value=300.39} ,
                Brand = new { Description = "Adidas"},
                Model = new { Nome = "A200"} },
            new Product() {
                Description= "Tenis Nike",
                Code = "COP22",
                ProductPrice = new { value=120.39} ,
                Brand = new { Description = "Nike"},
                Model = new { Nome = "AIR"} },
            new Product() {
                Description= "Tenis Nike",
                Code = "COP222",
                ProductPrice = new { value=200.00} ,
                Brand = new { Description = "Nike"},
                Model = new { Nome = "AIR 2"} },
        };

        [HttpGet("[action]")]
        public IList<Product> GetAllProduct()
        {
            return Products.ToArray();
        }


        [HttpGet("[action]")]
        public Product GetProduct(String description)
        {
            //var result =  _customerAppService.GetAll();

            var result = Products.Where(x => x.Description.Equals(description)).First();
            return result;
        }


        public class Product
        {
            public string Description { get; set; }
            public Object Model { get; set; }
            public Object Brand { get; set; }
            public string Code { get; set; }
            public Object ProductPrice { get; set; }
        }
    }
}
