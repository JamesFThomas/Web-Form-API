using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Form_API.Data;
using Web_Form_API.Models;
using Web_Form_API.Repository;

namespace Web_Form_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FormsController : ControllerBase
    {

        // use generic repository access in controller
        private IGenericRepository<FormBase> _formsRepo;

        // instantiate this controller using the generic repo class type
        public FormsController(IGenericRepository<FormBase> formsRepo)
        {
            _formsRepo = formsRepo;

        }


        // get all forms 
        [HttpGet]
        public ActionResult<IEnumerable<FormBase>> Get()
        {
            var forms = _formsRepo.GetAll(); // use methods defined in generic repository class
            
            return Ok(forms);
        }

        // get form by id
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<FormBase>> Get(int id)
        {

            var foundForm = _formsRepo.GetById(id);

            if (foundForm == null)
            {
                return NotFound();
            }

            return Ok(foundForm);

        }

        // post form to list
        [HttpPost]
        public ActionResult Post( [FromBody] FormBase newForm)
        {

           _formsRepo.Add(newForm);

            return CreatedAtAction(nameof(Get), new { id = newForm.Id }, newForm);

        }


        // update form by id
        [HttpPut("{id}")]
        public ActionResult<string> Put(int id, [FromBody]FormBase newForm)
        {
            if ( id != newForm.Id)
            {
                return BadRequest();
            }

            _formsRepo.Update(newForm);

            return NoContent();

        }


        // delete form by id
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {

            _formsRepo.Delete(id);

            return NoContent();
        }

    }
}
