using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Form_API.Data;
using Web_Form_API.Models;

namespace Web_Form_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FormsController : ControllerBase
    {
        
        // local variable used to acess db context and return values
        private readonly FormDBContext _formDBContext;

        public FormsController(FormDBContext formDBContext)
        {
            _formDBContext = formDBContext;

        }


        // get all forms 
        [HttpGet]
        public ActionResult<IEnumerable<FormBase>> Get()
        {
            var forms = _formDBContext.Forms.ToList();
            return Ok(forms);
        }

        // post form to list
        [HttpPost]
        public ActionResult Post(int id, [FromBody]FormBase newForm)
        {

            _formDBContext.Forms.Add(newForm);

            _formDBContext.SaveChanges(); // must save changes to db tables after actions

            return CreatedAtAction(nameof(Get), new { id = newForm.Id }, newForm);

        }

        // get form by id
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<FormBase>> Get(int id)
        {
            
            var foundForm = _formDBContext.Forms.FirstOrDefault(form => form.Id == id);

            if (foundForm == null)
            {
                return NotFound();
            }

            return Ok(foundForm);

        }

        // update form by id
        [HttpPut("{id}")]
        public ActionResult<string> Put(int id, [FromBody]FormBase newForm)
        {
            var updatedForm = _formDBContext.Forms.FirstOrDefault(form => form.Id == id);

            if (updatedForm != null)
            {
                updatedForm.Id = newForm.Id;
                updatedForm.FirstName = newForm.FirstName;
                updatedForm.LastName = newForm.LastName;
                updatedForm.Message = newForm.Message;

                _formDBContext.SaveChanges(); // must save changes to db tables after actions

                return Ok(updatedForm); 
            }

            return NotFound();
        }


        // delete form by id
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            var formToBeRemoved = _formDBContext.Forms.FirstOrDefault(form => form.Id == id);
            
            if (formToBeRemoved != null)
            {
                _formDBContext.Forms.Remove(formToBeRemoved);
                _formDBContext.SaveChanges(); // must save changes to db tables after actions
                return Ok($"form id#: {id} was deleted");
            }        
            
            return NotFound();
        }

    }
}
