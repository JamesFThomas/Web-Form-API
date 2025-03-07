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
        
        // local variable used to access/return repository values
        private readonly IFormsRespository _formsRepo;

        public FormsController(IFormsRespository formsRepo)
        {
            _formsRepo = formsRepo;

        }


        // get all forms 
        [HttpGet]
        public ActionResult<IEnumerable<FormBase>> Get()
        {
            var forms = _formsRepo.GetAllForms();
            return Ok(forms);
        }

        // get form by id
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<FormBase>> Get(int id)
        {

            var foundForm = _formsRepo.GetForm(id);

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

            _formsRepo.AddForm(newForm);

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

            _formsRepo.UpdateForm(newForm);
         
            return NoContent();

        }


        // delete form by id
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {

            _formsRepo.DeleteForm(id);

            return NoContent();
        }

    }
}
