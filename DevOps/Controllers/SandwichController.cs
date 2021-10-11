using DevOps.Managers;
using DevOps.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevOps.Controllers {
    [ApiController]
    [Route("")]
    public class SandwichController : ControllerBase {
        private readonly SandwichManager _manager = new SandwichManager();

        // GET api/<SandwichController>/<string>
        [EnableCors("allowAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Route("{substring}")]
        [HttpGet]
        public ActionResult<IEnumerable<Sandwich>> Get(string substring) {
            List<Sandwich> re = _manager.GetAll(substring);
            if (re.Count > 0) {
                return Ok(re);
            }

            return NoContent();
        }

        // GET api/<SandwichController>/<string>
        [EnableCors("allowAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult<IEnumerable<Sandwich>> Get() {
            List<Sandwich> re = _manager.GetAll(null);
            if (re.Count > 0) {
                return Ok(re);
            }

            return NoContent();
        }

        // POST api/<SandwichController>
        [DisableCors]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        [HttpPost]
        public IActionResult Post([FromBody] Sandwich value) {
            try {
                _manager.Add(value);
                return Created("http://localhost:5000/", value);
            } catch (Exception e) {
                return StatusCode(406, e.ToString());
            }
        }

        // PUT api/<SandwichController>/5
        [DisableCors]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Sandwich value) {
            _manager.Update(id, value);
        }

        // DELETE api/<SandwichController>/5
        [DisableCors]
        [HttpDelete("{id}")]
        public void Delete(int id) {
            _manager.Delete(id);
        }
    }
}
