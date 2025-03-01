using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Form_API.Models;

namespace Web_Form_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FormsController : ControllerBase
    {

        // make a list to hold the form data
        // private static readonly Dictionary<int, FormBase> _Forms = new Dictionary<int, FormBase>()
        private static readonly List<FormBase> _Forms = new List<FormBase>()
        {
            new FormBase { Id=1, FirstName="Johhny", LastName="Fives", Message="This is test data" },
            new FormBase { Id=2, FirstName="Emily", LastName="Smith", Message="Sample message for testing" },
            new FormBase { Id=3, FirstName="John", LastName="Doe", Message="Another test entry" },
            new FormBase { Id=4, FirstName="Sophia", LastName="Brown", Message="Testing data input format" },
            new FormBase { Id=5, FirstName="Liam", LastName="Johnson", Message="Example of a form submission" },
            new FormBase { Id=6, FirstName="Olivia", LastName="Miller", Message="Checking the message field" },
            new FormBase { Id=7, FirstName="Noah", LastName="Davis", Message="Ensuring proper formatting" },
            new FormBase { Id=8, FirstName="Ava", LastName="Wilson", Message="Test message for system validation" },
            new FormBase { Id=9, FirstName="James", LastName="Anderson", Message="FormBase test entry number 9" },
            new FormBase { Id=10, FirstName="Emma", LastName="Taylor", Message="Final test data input" },
            new FormBase { Id=22, FirstName="Remove", LastName="Me", Message="Test the delete endpoint" },
        };


        //private readonly ILogger<FormsController> _logger;


        /*
            public FormsController(ILogger<FormsController> logger)
            {
                _logger = logger;
            }
        */

        // get all forms 
        [HttpGet]
        public ActionResult<IEnumerable<FormBase>> Get()
        {
            return Ok(_Forms);
        }

        // post form to list
        [HttpPost]
        public ActionResult Post([FromBody]FormBase newForm)
        {
            _Forms.Add(newForm);
            return CreatedAtAction(nameof(Get), new { id = newForm.Id }, newForm);

        }

        // get form by id
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<FormBase>> Get(int id)
        {
            
            var foundForm = _Forms.Where(form => form.Id == id);

            if (foundForm.Count() == 0)
            {
                return NotFound();
            }
            return Ok(foundForm);

        }

        // update form by id
        [HttpPut("{id}")]
        public ActionResult<string> Put(int id, [FromBody]FormBase newForm)
        {
            var updatedForm = _Forms.FirstOrDefault(form => form.Id == id);

            if (updatedForm != null)
            {
                updatedForm.Id = newForm.Id;
                updatedForm.FirstName = newForm.FirstName;
                updatedForm.LastName = newForm.LastName;
                updatedForm.Message = newForm.Message;

                return Ok(updatedForm); 
            }

            return NotFound();
        }


        // delete form by id
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            var formToBeRemoved = _Forms.FirstOrDefault(form => form.Id == id);
            
            if (formToBeRemoved != null)
            {
                _Forms.Remove(formToBeRemoved);
                return Ok($"form id#: {id} was deleted");
            }        
            
            return NotFound();
        }

    }
}
