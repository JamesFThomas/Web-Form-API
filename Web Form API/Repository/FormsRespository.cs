using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Form_API.Data;
using Web_Form_API.Models;

namespace Web_Form_API.Repository
{
    public class FormsRespository : IFormsRespository
    {
        // local variable to access / return db data 
        private readonly FormDBContext _formDBContext;

        // access the database here is the repository
        public FormsRespository(FormDBContext formDBContext)
        {
            _formDBContext = formDBContext;

        }

        // methods to access database
        public IEnumerable<FormBase> GetAllForms()
        {
            return _formDBContext.Forms.ToList();
        }

        public FormBase GetForm(int id)
        {
            return _formDBContext.Forms.FirstOrDefault(form => form.Id == id);
        }

        public void AddForm(FormBase newForm)
        {
            _formDBContext.Forms.Add(newForm);
            _formDBContext.SaveChanges(); // persist db interaction by saving
        }

        public void DeleteForm(int id)
        {
            var formToBeRemoved = _formDBContext.Forms.FirstOrDefault(form => form.Id == id);

            if (formToBeRemoved != null)
            {
                _formDBContext.Forms.Remove(formToBeRemoved);
                _formDBContext.SaveChanges(); // persist db interaction by saving
            }

        }


        public void UpdateForm(FormBase newForm)
        {
            var updatedForm = _formDBContext.Forms.FirstOrDefault(form => form.Id == newForm.Id);

            if (updatedForm != null)
            {
                // Changing id# causes error in program, only chnage form details  
                updatedForm.FirstName = newForm.FirstName;
                updatedForm.LastName = newForm.LastName;
                updatedForm.Message = newForm.Message;

                _formDBContext.Entry(updatedForm).State = EntityState.Modified;

                _formDBContext.SaveChanges(); // persist db interaction by saving

            }
        }
    }
}
