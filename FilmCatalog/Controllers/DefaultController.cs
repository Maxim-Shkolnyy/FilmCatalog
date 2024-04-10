using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FilmCatalog.Controllers
{
    public class DefaultController : ApiController
    {
        private static List<string> categories = new List<string> { "Action", "Comedy", "Drama", "Horror" };

        // GET: api/Default
        public IEnumerable<string> Get()
        {
            return categories;
        }

        // GET: api/Default/5
        public IHttpActionResult Get(int id)
        {
            if (id >= 0 && id < categories.Count)
            {
                return Ok(categories[id]);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/Default
        public IHttpActionResult Post([FromBody] string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                categories.Add(value);
                return Ok();
            }
            else
            {
                return BadRequest("Category value cannot be empty");
            }
        }

        // PUT: api/Default/5
        public IHttpActionResult Put(int id, [FromBody] string value)
        {
            if (id >= 0 && id < categories.Count && !string.IsNullOrEmpty(value))
            {
                categories[id] = value;
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE: api/Default/5
        public IHttpActionResult Delete(int id)
        {
            if (id >= 0 && id < categories.Count)
            {
                categories.RemoveAt(id);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}

