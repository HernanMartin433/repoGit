using ApiGestores.context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiGestores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class gestoresController : ControllerBase
    {
        private readonly AppDbContext context;
        public gestoresController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<gestoresController>
        [HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        public ActionResult Get()
        {
            try
            {
                return Ok(context.gestores_bd.ToList());
            }
            catch (Exception ex)
            { 
                return BadRequest(ex.Message);  
            }
        }

        // GET api/<gestoresController>/5
        [HttpGet("{id}",Name ="GetGestor")]
        //public string Get(int id)
        //{
        //    return "value";
        //}
        public ActionResult Get(int id)
        {
            try
            {
                var gestor = context.gestores_bd.FirstOrDefault(g => g.id == id);
                return Ok(gestor);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<gestoresController>
        [HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}
        public ActionResult Post([FromBody] models.gestores_bd gestor)
        {
            try
            {
                context.gestores_bd.Add(gestor);
                context.SaveChanges();
                return CreatedAtRoute("GetGestor", new { id = gestor.id }, gestor);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<gestoresController>/5
        [HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}
        public ActionResult Put(int id,[FromBody] models.gestores_bd gestor)
        {
            try
            {
                if(gestor.id==id)
                {
                    context.Entry(gestor).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetGestor", new {id = gestor.id}, gestor);   
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

        // DELETE api/<gestoresController>/5
        [HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
        public ActionResult Delete(int id)
        {
            try
            {
                var gestor = context.gestores_bd.FirstOrDefault(g => g.id == id);
                if (gestor !=null)
                {
                    context.gestores_bd.Remove(gestor);
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
