# Web Form API
 
# Web Form API
 
 Web Form API is a C#, entity framework core application that persists submitted form information into a local SQL server instance.   
 
 ## Purpose:
 
 This application is an ongoing project to learn C#, improve my backend development skills, and further my understanding of software engineering.
 
 *** This project is meant to be used with the Web Form Frontend project ***
 
 Web Form Frontend => https://github.com/JamesFThomas/Web-Form-Frontend 
  
 As the form grows in complexity the database and subsequent routes will updated to accommodate those upgrades. 
 
 
 ## Installation:
 
 Packages_ 
 - Microsoft.AspNetCore.Mvc.Versioning - v4.2.0
 - Microsoft.EntityFrameworkCore - v3.1.32
 - Microsoft.EntityFrameworkCore.Design - v3.1.32
 - Microsoft.EntityFrameworkCore.SqlServer - v3.1.32
 - Microsoft.EntityFrameworkCore.Tools - v3.1.32
 - Swashbuckle.AspNetCore - v5.6.3

 
 
 DB setup_

 To create migration files 

 ```Text
 Add-Migration <Migration name>
 ```

 To create local dbinstance 

 ```text
 Update-Database
 ```

  
 
 ### Routes:
 Forms
 - GET /Forms
 - GET /Forms/{id}
 - GET /Forms/{completed}
 - PUT /Forms/{id}
 - DELETE /Forms/{id}
 
 Users
 - GET /Users
 - GET /Users/{email}
 - POST /User


 ![current routes in swagger](http://drive.google.com/file/d/1FIrX-NsZC_ierihH_YkmUukU33FZesVK/view?usp=sharing)
 
 
 example User
 ``` C#
     public class UserBase
     {
         public int Id { get; set; }
         public string Username { get; set; }
         public string Email { get; set; }
     }
 ```
 
 
 example Form
 ``` C#
  public class FormBase
     {
         public int Id { get; set; }
         public string FirstName { get; set; }
         public string LastName { get; set; }
         public string Message { get; set; }
         public bool Completed { get; set; }
     }
 ```
 
 
 ### TODO:
 - Update the project to modern versions of all packages
 - Add tests for each route 
 - Add web tokens/user authorization 
 


 