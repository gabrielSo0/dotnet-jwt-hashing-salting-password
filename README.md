# .NET Web API for Authentication, Password Hashing and Salting

This is a simple .NET 8 web API that use a JWT authentication method and for more security password storing, it uses the password hash and salt standard.

## How to run

You must have the .NET 8 SDK installed.

Run the command 'dotnet restore' and then 'dotnet run' or, if you're using Visual Studio, just run the API.

## How to test it

You can test it on postman or on swagger.

**http://localhost:port/api/v1/account/register - Create User**
>
**http://localhost:port/api/v1/account/login - Login**

The token returned from the create and login can be used for further requests.
ex: Bearer [token]

Note: this API use an InMemory database.