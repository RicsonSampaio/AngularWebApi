using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.Data.Services;
using WebAPI.Domain.Models;

namespace WebAPI.API.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {
        private IProductRepository _db;

        public ProductsController(IProductRepository db)
        {
            _db = db;
        }

        //[HttpGet]
        //[Route()]
        //public IHttpActionResult GetAllProducts()
        //{
        //    try
        //    {
        //        return Ok(_db.GetAllProducts());
        //    }
        //    catch (Exception ex)
        //    {
        //        // TODO logging
        //        return InternalServerError(ex);
        //    }

        //}

        [HttpGet]
        [Route()]
        public async Task<IHttpActionResult> GetAllProducts()
        {
            try
            {
                return Ok(await _db.GetAllProducts());
            }
            catch (Exception ex)
            {
                // TODO logging
                return InternalServerError(ex);
            }

        }

        [HttpGet]
        [Route("{id:int}", Name = "GetProduct")]
        public async Task<IHttpActionResult> GetProduct(int id)
        {
            Product product = await _db.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.Id)
            {
                return BadRequest();
            }

            //_db.Entry(product).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!GetProduct(id))
                //{
                //    return NotFound();
                //}
                //else
                //{
                //    throw;
                //}
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPost]
        [Route("createProduct")]
        public async Task<IHttpActionResult> CreateProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.CreateProduct(product);

            if (await _db.SaveChangesAsync())
            {
                return CreatedAtRoute("GetProduct", new { id = product.Id }, product);
            }
            else
            {
                return InternalServerError();
            }
        }

        // DELETE: api/Products/5
        [ResponseType(typeof(Product))]
        public async Task<IHttpActionResult> DeleteProduct(int id)
        {
            Product product = await _db.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }

            _db.DeleteProduct(id);
            await _db.SaveChangesAsync();

            return Ok(product);
        }
    }
}