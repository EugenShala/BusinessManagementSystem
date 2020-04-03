using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BMS.BusinessLogic.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BMS.DataAccess.Data;
using BMS.DataAccess.Models;

namespace BMS.Presentation.Areas.Admin.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductServiceAPIController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductServiceAPIController(IProductService productService)
        {
            _productService = productService;
        }


        #region Get

        // GET: api/ProductServices
        [HttpGet]
        public IEnumerable<ProductService> Get()
        {
            var service = _productService.GetAllService();
            return service;
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromBody] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ProductService service = _productService.GetById(id);
            if (service == null)
            {
                return NotFound();
            }
            return Ok(service);
        }

        #endregion


        #region Post
        [HttpPost]
        public IActionResult Post([FromBody]ProductService service)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _productService.Add(service);
                _productService.Save();
            }
            catch (Exception ex)
            {
                if (ProductServiceExist(service.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }

            }

            return CreatedAtAction("Get", new { id = service.Id }, service);
        }
        #endregion


        #region Update
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute]int id, [FromBody]ProductService service)
        {
            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
          
            if (id != service.Id)
            {
                return BadRequest();
            }

            try
            {
                _productService.Update(service);
                _productService.Save();
            }
            catch (Exception ex)
            {
                if (!ProductServiceExist(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }
            return Ok(service);
        }
        #endregion

        #region Delete
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute]int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!ProductServiceExist(id))
            {
                return NotFound();
            }

            _productService.Delete(id);
            _productService.Save();

            return Ok();
        }
        #endregion

        private bool ProductServiceExist(int id)
        {
            return _productService.GetById(id) != null;
        }
    }
}
