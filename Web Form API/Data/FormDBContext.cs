using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Form_API.Models;

namespace Web_Form_API.Data
{
    public class FormDBContext : DbContext
    {
        // class constructor will push options to base class it was extended from
        public FormDBContext(DbContextOptions<FormDBContext> options) : base(options)
        { 
                    
        }

        // create a db table for form data submission
        public DbSet<FormBase> Forms { get; set; }


    }
}
