using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreAPI.Data.DAL;
using StoreAPI.Data.Entites;
using StoreAPI.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _context;
        public ProductsController(StoreContext context)
        {
            _context = context;
        }
        public IActionResult GetAll()
        {
            return Ok(_context.Products.ToList());
        }
        [Route("{id}")]
        [HttpGet]
        public IActionResult Get(int id)
        {
            Product product = _context.Products.FirstOrDefault(x => x.Id == id);
            if(product==null)
            {
                return StatusCode(404, new { message = "bele bir mehsul yoxdur" });
            }
            //return Ok(product);
            return StatusCode(200, product);
        }
        [HttpPost]
        public IActionResult Create([FromForm]ProductPostDTO productDTO)
        {
            Product product = new Product
            {
                Name = productDTO.Name,
                Price = productDTO.Price
            };
            if(product.Id!=0)
            {
                return BadRequest();
            }
            _context.Products.Add(product);
            _context.SaveChanges();
            return StatusCode(201, _context.Products.ToList());
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromForm]ProductPostDTO productDTO,int id)
        {
            Product old = _context.Products.FirstOrDefault(x => x.Id ==id);
            if(old==null)
            {
                return StatusCode(404, new { message = "Bele bir mehsul yoxdur" });
            }
            old.Name = productDTO.Name;
            old.Price = productDTO.Price;
            _context.SaveChanges();
            return NoContent();
            
        }
        [HttpDelete("{id}")]
        public IActionResult Delete([FromForm]int id)
        {
            Product product = _context.Products.FirstOrDefault(x => x.Id == id);
            if (product == null) { NotFound(); }
            _context.Products.Remove(product);
            _context.SaveChanges();
            return NoContent();

        }
    }
}
