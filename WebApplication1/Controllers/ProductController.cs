using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ProductDbContext context;

        public ProductDbContext Context { get => context; set => context = value; }

        public ProductController(ProductDbContext context)
        {
            this.Context = context;
        }

        // GET: api/Products
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return Context.Products;
        }

        // GET: api/Products/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var existing = Context.Products.FirstOrDefault(product => product.Id == id);
            if (existing == null)
            {
                return NotFound();
            }

            return Ok(existing);
        }

        // POST: api/Products
        [HttpPost]
        public void Post([FromBody] Product product)
        {
            Context.Products.Add(product);
            Context.SaveChanges();
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product product)
        {
            var existing = Context.Products.AsNoTracking().FirstOrDefault(f => f.Id == id);
            if (existing == null)
            {
                Context.Products.Add(product);
                Context.SaveChanges();
                return Ok(product);
            }
            product.Id = id;
            Context.Products.Update(product);
            Context.SaveChanges();
            return Ok(product);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = Context.Products.FirstOrDefault(product => product.Id == id);
            if (existing == null)
            {
                return NotFound();
            }
            Context.Products.Remove(existing);
            Context.SaveChanges();
            return Ok();
        }
    }
}
