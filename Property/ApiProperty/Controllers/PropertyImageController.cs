using ApiProperty.Context;
using ApiProperty.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiProperty.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyImageController : ControllerBase
    {
        private readonly AppDbContext context;

        public PropertyImageController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<PropertyController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.PropertyImage.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<PropertyController>/5
        [HttpGet("{id}", Name = "GetPropertyImage")]
        public ActionResult Get(int id)
        {
            try
            {
                //var consultarXid = context.PropertyImage.FirstOrDefault(g => g.idProperty== id);
                var consultarXid = context.PropertyImage.Where(g => g.idProperty == id).ToList();
                 //   context.PropertyImage.Select(g => g.idProperty== id).ToList();
                return Ok(consultarXid);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<PropertyController>
        [HttpPost]
        public ActionResult Post([FromBody] PropertyImage objPropertyImage)
        {
            try
            {
                context.PropertyImage.Add(objPropertyImage);
                context.SaveChanges();
                return CreatedAtRoute("GetPropertyImage", new { id = objPropertyImage.idPropertyImage }, objPropertyImage);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<PropertyController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] PropertyImage objPropertyImage)
        {
            try
            {
                if (objPropertyImage.idPropertyImage == id)
                {
                    context.Entry(objPropertyImage).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetPropertyImage", new { id = objPropertyImage.idPropertyImage }, objPropertyImage);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<PropertyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
