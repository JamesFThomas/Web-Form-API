using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Form_API.Classes;
using Web_Form_API.Data;
using Web_Form_API.Models;

namespace Web_Form_API.Repository
{
    public class FormsRespository : GenericRepository<FormBase>, IFormsRespository
    {
        // local variable to access / return db data 
        private readonly DbContext _formDBContext;

        // access the database here is the repository
        public FormsRespository(FormDBContext formDBContext) : base(formDBContext)
        {
            _formDBContext = formDBContext;

        }

        public IEnumerable<FormBase> GetCompletedForms()
        {
            return _dbSet.Where(form => form.Completed == true).ToList();
        }



    }
}
