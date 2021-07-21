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
    public class PropertyTraceController : ControllerBase
    {
        private readonly AppDbContext context;

        public PropertyTraceController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<PropertyController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.PropertyTrace.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<PropertyController>/5
        [HttpGet("{id}", Name = "GetPropertyTrace")]
        public ActionResult Get(int id)
        {
            try
            {
                var consultarXid = context.PropertyTrace.FirstOrDefault(g => g.IdPropertyTrace == id);
                return Ok(consultarXid);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<PropertyController>
        [HttpPost]
        public ActionResult Post([FromBody] PropertyTrace objPropertyTrace)
        {
            try
            {
                context.PropertyTrace.Add(objPropertyTrace);
                context.SaveChanges();
                return CreatedAtRoute("GetPropertyTrace", new { id = objPropertyTrace.IdPropertyTrace }, objPropertyTrace);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<PropertyController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] PropertyTrace objPropertyTrace)
        {
            try
            {
                if (objPropertyTrace.IdPropertyTrace == id)
                {
                    context.Entry(objPropertyTrace).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetPropertyTrace", new { id = objPropertyTrace.IdPropertyTrace }, objPropertyTrace);
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
