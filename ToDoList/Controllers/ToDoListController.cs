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
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class ToDoListController : ApiController
    {
        private ToDoMSsqlDBContext db = new ToDoMSsqlDBContext();

        // GET: api/ToDoList
        public IQueryable<ToDo> GetToDoList()
        {
            return db.ToDoList;
        }

        // GET: api/ToDoList/5
        [ResponseType(typeof(ToDo))]
        public async Task<IHttpActionResult> GetToDo(int id)
        {
            ToDo toDo = await db.ToDoList.FindAsync(id);
            if (toDo == null)
            {
                return NotFound();
            }

            return Ok(toDo);
        }

        // PUT: api/ToDoList/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutToDo(int id, ToDo toDo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != toDo.ToDoID)
            {
                return BadRequest();
            }

            db.Entry(toDo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToDoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ToDoList
        [ResponseType(typeof(ToDo))]
        public async Task<IHttpActionResult> PostToDo(ToDo toDo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ToDoList.Add(toDo);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = toDo.ToDoID }, toDo);
        }

        // DELETE: api/ToDoList/5
        [ResponseType(typeof(ToDo))]
        public async Task<IHttpActionResult> DeleteToDo(int id)
        {
            ToDo toDo = await db.ToDoList.FindAsync(id);
            if (toDo == null)
            {
                return NotFound();
            }

            db.ToDoList.Remove(toDo);
            await db.SaveChangesAsync();

            return Ok(toDo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ToDoExists(int id)
        {
            return db.ToDoList.Count(e => e.ToDoID == id) > 0;
        }
    }
}