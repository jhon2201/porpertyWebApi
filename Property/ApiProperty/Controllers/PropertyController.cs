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
    public class PropertyController : ControllerBase
    {
        private readonly AppDbContext context;

        public PropertyController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<PropertyController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Property.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<PropertyController>/5
        [HttpGet("{id}", Name = "GetProperty")]
        public ActionResult Get(int id)
        {
            try
            {
                var consultarXid = context.Property.FirstOrDefault(g => g.idProperty == id);
                return Ok(consultarXid);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<PropertyController>
        [HttpPost]
        public ActionResult Post([FromBody] Property objProperty)
        {
            try
            {
                context.Property.Add(objProperty);
                context.SaveChanges();
                return CreatedAtRoute("GetProperty", new { id = objProperty.idProperty }, objProperty);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<PropertyController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Property objProperty)
        {
            try
            {
                if (objProperty.idProperty == id)
                {
                    context.Entry(objProperty).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetProperty", new { id = objProperty.idProperty }, objProperty);
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
