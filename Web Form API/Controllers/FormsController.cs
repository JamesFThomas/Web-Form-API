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
            //var forms = _formsRepo.Forms.ToList();
            var forms = _formsRepo.GetAllForms();
            return Ok(forms);
        }

        // get form by id
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<FormBase>> Get(int id)
        {

            //var foundForm = _formsRepo.Forms.FirstOrDefault(form => form.Id == id);

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

            //_formsRepo.Forms.Add(newForm);
            //_formsRepo.SaveChanges(); // must save changes to db tables after actions

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

            //var updatedForm = _formsRepo.Forms.FirstOrDefault(form => form.Id == id);

            //if (updatedForm != null)
            //{
            //    //updatedForm.Id = newForm.Id; // changing id value causes error in program. 
            //    updatedForm.FirstName = newForm.FirstName;
            //    updatedForm.LastName = newForm.LastName;
            //    updatedForm.Message = newForm.Message;

            //    _formsRepo.SaveChanges(); // must save changes to db tables after actions

            //    return Ok(updatedForm); 

            //}

            _formsRepo.UpdateForm(newForm);
            return NoContent();

            //return NotFound();
        }


        // delete form by id
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            //var formToBeRemoved = _formsRepo.Forms.FirstOrDefault(form => form.Id == id);
            
            //if (formToBeRemoved != null)
            //{
            //    _formsRepo.Forms.Remove(formToBeRemoved);
            //    _formsRepo.SaveChanges(); // must save changes to db tables after actions
            //    return Ok($"form id#: {id} was deleted");
            //}

            _formsRepo.DeleteForm(id);

            return NoContent();
        }

    }
}
