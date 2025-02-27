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
    public class WebFormController : ControllerBase
    {

        // create a class/model that defines the form data - done


        // make a list to hold the form data
        private static readonly List<FormBase> Forms = new List<FormBase>()
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


        private readonly ILogger<WebFormController> _logger;


        public WebFormController(ILogger<WebFormController> logger)
        {
            _logger = logger;
        }

        // get all forms 
        [HttpGet]
        [Route("GetAllForms")]
        public IEnumerable<FormBase> GetAllForms()
        {
            return Forms.ToArray();
        }

        // get form by id
        [HttpGet]
        [Route("GetFormById")]
        public IEnumerable<FormBase> GetFormById(int id)
        {
            return Forms.Where(form => form.Id == id);
        }


        // delete form by id
        [HttpDelete]
        [Route("DeleteFormById")]
        public string DeleteFormById(int id)
        {
            var formToBeRemoved = Forms.SingleOrDefault(form => form.Id == id);
            
            if (formToBeRemoved != null)
            {
                Forms.Remove(formToBeRemoved);
                return $" The Form with id#: {id} was deleted";
            }        
            
            return $" Form not found";
        }

        // update form by id
        [HttpPut]
        [Route("UpdateFormById")]
        public string UpdateFormById(int id, [FromBody]FormBase newForm)
        {
            var indexOfForm = Forms.FindIndex(form => form.Id == id); 

            if (indexOfForm != -1)
            {
                Forms[indexOfForm] = newForm;
                return $" The Form with id#: {id} was updated";
            }

            return $" Form not found";
        }


    }
}
