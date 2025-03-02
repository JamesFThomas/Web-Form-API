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
        private static readonly Dictionary<int, FormBase> _Forms = new Dictionary<int, FormBase>()
        {
            { 1, new FormBase { Id=1, FirstName="Johhny", LastName="Fives", Message="This is test data" }},
            { 2, new FormBase { Id=2, FirstName="Emily", LastName="Smith", Message="Sample message for testing" } },
            { 3, new FormBase { Id=3, FirstName="John", LastName="Doe", Message="Another test entry" }},
            { 4, new FormBase { Id=4, FirstName="Sophia", LastName="Brown", Message="Testing data input format" }},
            { 5, new FormBase { Id=5, FirstName="Liam", LastName="Johnson", Message="Example of a form submission" }},
            { 6, new FormBase { Id=6, FirstName="Olivia", LastName="Miller", Message="Checking the message field" }},
            { 7, new FormBase { Id=7, FirstName="Noah", LastName="Davis", Message="Ensuring proper formatting" }},
            { 8, new FormBase { Id=8, FirstName="Ava", LastName="Wilson", Message="Test message for system validation" }},
            { 9, new FormBase { Id=9, FirstName="James", LastName="Anderson", Message="FormBase test entry number 9" }},
            { 10, new FormBase { Id=10, FirstName="Emma", LastName="Taylor", Message="Final test data input" }},
            { 22, new FormBase { Id=22, FirstName="Remove", LastName="Me", Message="Test the delete endpoint" }},
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
            return Ok(_Forms.Values.ToList());
        }

        // post form to list
        [HttpPost]
        public ActionResult Post(int id, [FromBody]FormBase newForm)
        {
            bool isKeyPresent = _Forms.ContainsKey(id);

            if(!isKeyPresent)
            {
                _Forms.Add(id, newForm);
                return CreatedAtAction(nameof(Get), new { id = newForm.Id }, newForm);
            }

            return BadRequest($"ID#: {id} already exists, use a different key to save form data");

        }

        // get form by id
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<FormBase>> Get(int id)
        {
            
            var foundForm = _Forms.FirstOrDefault(form => form.Value.Id == id);

            if (foundForm.Value == null)
            {
                return NotFound();
            }

            return Ok(foundForm.Value);

        }

        // update form by id
        [HttpPut("{id}")]
        public ActionResult<string> Put(int id, [FromBody]FormBase newForm)
        {
            var updatedForm = _Forms.FirstOrDefault(form => form.Value.Id == id);

            if (updatedForm.Value != null)
            {
                updatedForm.Value.Id = newForm.Id;
                updatedForm.Value.FirstName = newForm.FirstName;
                updatedForm.Value.LastName = newForm.LastName;
                updatedForm.Value.Message = newForm.Message;

                return Ok(updatedForm.Value); 
            }

            return NotFound();
        }


        // delete form by id
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            var formToBeRemoved = _Forms.FirstOrDefault(form => form.Value.Id == id);
            
            if (formToBeRemoved.Value != null)
            {
                _Forms.Remove(id);
                return Ok($"form id#: {id} was deleted");
            }        
            
            return NotFound();
        }

    }
}
