using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Form_API.Models;

namespace Web_Form_API.Repository
{
    public interface IFormsRespository : IGenericRepository<FormBase>
    {

        // route specifc for the Forms data not used by teh generic repository class
        IEnumerable<FormBase> GetCompletedForms();

    }
}
