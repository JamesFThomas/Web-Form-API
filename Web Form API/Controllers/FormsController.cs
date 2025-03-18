using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Form_API.Classes;
using Web_Form_API.Data;
using Web_Form_API.Models;
using Web_Form_API.Repository;

namespace Web_Form_API.Controllers
{

    // TODO update FormBase to include new fields for login/register process -> UserName & Email Address
    // TODO -> Create a route that searches for user name || email addresses to confirm login / registration 



    [ApiController]
    [Route("[controller]")]
    public class FormsController : ControllerBase
    {


        // use generic repository access in controller
        private IGenericRepository<FormBase> _genericRepo;

        // use FormsRepository for Form specific route
        private readonly IFormsRespository _formsRespository;


        // instantiate this controller using the generic repo class type
        public FormsController(IGenericRepository<FormBase> genericRepo, IFormsRespository formsRepo)
        {
            _genericRepo = genericRepo;
            _formsRespository = formsRepo;

        }


        // get all forms 
        [HttpGet]
        public ActionResult<IEnumerable<FormBase>> Get()
        {
            var forms = _genericRepo.GetAll(); // use methods defined in generic repository class
            
            return Ok(forms);
        }

        // get form by id
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<FormBase>> Get(int id)
        {

            var foundForm = _genericRepo.GetById(id);

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

            _genericRepo.Add(newForm);

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

            _genericRepo.Update(newForm);

            return NoContent();

        }


        // delete form by id
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {

            _genericRepo.Delete(id);

            return NoContent();
        }


        // get completed forms
        [HttpGet("completed")]
        public ActionResult<IEnumerable<FormBase>> GetCompletedForms()
        {

            var foundForm = _formsRespository.GetCompletedForms();

            if (foundForm == null)
            {
                return NotFound();
            }

            return Ok(foundForm);

        }


    }
}
