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

## How it works?

As a secure measure, we never store plaintext password in the database, if you're database is compromised, every password of every user will be exposure to the person who has access to it. And also, you have to limit internal access even for those who has database visualization.

Hash it's one way, which means, you can't use the same algorithm or function to return to the original value. That's why is secure, but, hackers have ways to know some of those hash original value by using a 'Hash table' which contains thounsands of records of common passwords used and it's equivalent hash. So, if the hacker finds out one password, if anyone else has the same, it will also be compromised.

That's where the 'Salt' comes in. To make it more secure, we choose to follow the hash and salting password pattern.

In this pattern, we combine the salt random number generated, with the password that was processed by the hash function algorithm. For example:

- password plaintext: 123
- password hash: 133ndbdsm233
- password salt: 234382
- hash + salt: 133ndbdsm233234382

This way, even if two people have the same password, the hash generated will be different thanks to Salt, that is unique per each user or Id.