# Animal Shelter API :tm:

An API that catalogs cats :cat:, dogs :dog:, and other small animals :rabbit: :hamster: :mouse: from the Animal Shelter's inventory. A user may View List, Add, Edit, and Delete animals as needed and interact with the  the API using Postman.
#### Authored by Erika Debelis

## Technologies Used

* _C#_
* _MySQL_
* _My SQL Workbench_
* _VS Code_
* _Git BASH_
* _LINQ_
* _ASP .NET CORE MVC_
* _Entity Framework Core_
* _Postman_
* _Swagger_
* _Swashbuckle_

## Setup/Installation Requirements

1. Download or clone the https://github.com/ErikaDebelis/AnimalShelterAPI.Solution to your local machine

2. Open git BASH terminal and navigate to the AnimalShelter folder within the directory

3. Create appsettings.json file in the Factory directory of AnimalShelter.Solution and add the following code to the file:
    ``touch appsettings.json``

```
{
  "Logging":
  {
    "LogLevel":
    {
      "Default": "Warning",
      "System": "Information",
      "Microsoft": "Information"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings":
  {
    "DefaultConnection": "Server=localhost;Port=3306;database=animal_shelter;uid={YOUR_USERNAME_NAME};pwd={YOUR_PASSWORD};"
  }
}
```
Be sure to remove the ``{YOUR_USERNAME_NAME}`` and ``{YOUR_PASSWORD}`` and fill in the the code snippet with your username for MySQL, and MySQL password _Do not include the curly brackets in your code snippet of appsettings.json_

4. Make sure EF Core is installed to create and utilize migrations. Run the following code in the git BASH terminal to install.
    ``$ dotnet tool install --global dotnet-ef --version 3.0.0``

5. Run "dotnet restore" in the git BASH terminal to install needed dependencies.
    ``$ dotnet restore``

6. Run "dotnet build" in the git BASH terminal to minify the code.
    ``$ dotnet build``

7. Run "dotnet ef database update" in the git BASH terminal create the database outlined from the Model within the project.
    ``$ dotnet ef database update``

8. Run "dotnet run" in the git BASH terminal to  minify the code, and run the project in the terminal.
    ``$ dotnet watch run``

9. View the API by downloading Postman and entering http://localhost:5000/api/cats or http://localhost:5000/api/dogs as a GET!

#### API Documentation

##### API Endpoints
* HTTP Request URL: ``http://localhost:5000``
* General request structure:
``` 
GET /api/Cats
POST /api/Cats
GET /api/Cats/{id}
PUT /api/Cats/{id}
DELETE /api/Cats/{id} 
```

_substitute Cats with Dogs or SmallAnimals depending on the intended query results_

###### _examples of a request URL query string:_
* _``https://localhost:5001/api/Cats?name=Kimmy``_
* _``https://localhost:5001/api/Dogs?name=Muffin``_
* _``https://localhost:5001/api/SmallAnimals?name=Bacon``_


##### Documentation utilized for further explorations:
* _``https://www.infoworld.com/article/3327562/how-to-enable-cors-in-aspnet-core.html``_ (CORS)
* _``https://docs.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-5.0``_ (CORS)
* _``https://www.c-sharpcorner.com/article/how-to-do-paging-with-asp-net-web-api/``_ (pagination)
* _``https://jasonwatmore.com/post/2018/10/17/c-pure-pagination-logic-in-c-aspnet``_ (pagination)
* _``https://stackoverflow.com/questions/41246614/entity-framework-core-add-unique-constraint-code-first/41257827``_ (creating unique constraints to avoid duplicate animals)
* _``https://docs.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger?view=aspnetcore-5.0&viewFallbackFrom=aspnetcore-50``_ (Swagger)

## Bugs

_no known bugs at this time_

## License

_MIT_

_Copyright :copyright: 2021 Erika Debelis_

if any issues are discovered while navigating the site, please let me know! It will help me learn and grow!

## Contact Information

Erika Debelis _erika.debelis@gmail.com_