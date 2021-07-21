#region using
using ApiProperty.Context;
using ApiProperty.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
#endregion

namespace ApiOwner.Controllers
{
    /// <summary>
    /// Controlador inicial de la clase Owner
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        /// <summary>
        ///referencia al contexto de la aplicacion 
        /// </summary>
        private readonly AppDbContext context;

        /// <summary>
        /// Constructor de la clase que inicializa el contexto
        /// </summary>
        /// <param name="context"></param>
        public OwnerController(AppDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Get obtiene listado completo de Owners
        /// </summary>
        /// <returns>listado de Owners</returns>
        // GET: api/<OwnerController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Owner.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get obtiene listado completo de Owners filtrado por ID
        /// </summary>
        /// <param name="id">identificador de la tabla</param>
        /// <returns>listado completo de Owners filtrado por ID</returns>
        // GET api/<OwnerController>/5
        [HttpGet("{id}", Name = "GetOwner")]
        public ActionResult Get(int id)
        {
            try
            {
                var consultarXid = context.Owner.FirstOrDefault(g => g.idOwner == id);
                return Ok(consultarXid);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// metodo post del Owner para que este sea actulizado.
        /// </summary>
        /// <param name="objOwner"></param>
        /// <returns>Objeto tipo owner actualizado</returns>
        // POST api/<OwnerController>
        [HttpPost]
        public ActionResult Post([FromBody] Owner objOwner)
        {
            try
            {
                context.Owner.Add(objOwner);
                context.SaveChanges();
                return CreatedAtRoute("GetOwner", new { id = objOwner.idOwner }, objOwner);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        ///  metodo post del Owner para que este sea insertado.
        /// </summary>
        /// <param name="id"> identificado del Owner</param>
        /// <param name="objOwner"> objeto tipo Json con la informacion del Owner</param>
        /// <returns>Objeto tipo owner insertado</returns>
        // PUT api/<OwnerController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Owner objOwner)
        {
            try
            {
                if (objOwner.idOwner == id)
                {
                    context.Entry(objOwner).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetOwner", new { id = objOwner.idOwner }, objOwner);
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

        // DELETE api/<OwnerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
