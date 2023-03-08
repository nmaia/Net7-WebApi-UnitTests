# Net7-WebApi-UnitTests

Hello there, welcome to the repo. :tada:

So, just to give you an overview about the project stack/structure. These are the concepts covered by the project:

- DDD (Architecture Model)
- Net 7.0
- Web API
- Polly
- EF Core
- xUnit (Unit Tests)
- SOLID
- Repository Pattern
- SQL Server Express

Soome cool stuff I'd like to have more time to improve or add here:

- Add [Fluent Validation](https://docs.fluentvalidation.net/en/latest/): To improve code readbility;
- Add [AutoMapper](https://automapper.org/): To improve code readability and data transfer between objects;
- Add [Docker](https://www.docker.com/) (Docker file, Docker compose, Images, etc): To containerize the applications;
- Add [RabbitMQ](https://www.rabbitmq.com/): To handle booking requests;
- Add [Serilog](https://serilog.net/): To improve the logging stuff;
- Add [DotNet Stryker](https://stryker-mutator.io/docs/stryker-net/introduction/) (Mutation Tests): To improve unit tests reliability;
- Adds code refactoring to the `API Proxy` project to handle `Hotels API` response in a better way;
- Adds code refactoring to improve the API results in terms of retuning friendly messages based on business rules;
- Create workspaces via Postman to test the APIs. So it would be easier to share the API documentation and requests with other devs or so.

Actually, I have other cool projects in my GitHub profile:
- e.g. [AspNetCore2.2-WebAPI-RabbitMQ-MongoDB-Docker](https://github.com/nmaia/AspNetCore2.2-WebAPI-RabbitMQ-MongoDB-Docker)

## Steps to setup/run this project locally:

### For the Hotel API project:

This API will receive requests from the `APIs Proxy project` just to apply the Polly policies.

1. Change the connection string:

![image](https://user-images.githubusercontent.com/92884809/223755001-be37983e-3974-4ed1-9ad6-c0f2bbeaa758.png)

2. Update database in order to apply the EF Migrations

- Run the command `update-database -verbose` in the package manage console tab.

![image](https://user-images.githubusercontent.com/92884809/223755554-74d19c98-d7f0-4655-83a2-aa5660b21dc7.png)

3. Once the `update-databae` command is done. You'll be bale to check the database structure:

![image](https://user-images.githubusercontent.com/92884809/223760617-ae680a5d-5887-4115-a259-4058d511617d.png)

4. Set the `Hotel.API` as the startup project:

![image](https://user-images.githubusercontent.com/92884809/223759759-0e99c761-449b-409a-89ea-5be732d96f5d.png)

5. Run the project pressing `F5`.

![image](https://user-images.githubusercontent.com/92884809/223760276-dd993c03-b3a4-4cde-98fc-44f39b56ace7.png)

:warning: It's important to check the port is being used by the API. We hope it's using the port 7112 from `https` profile. This is the port the API Proxy will use to consume the `Hotel.API`.

![image](https://user-images.githubusercontent.com/92884809/223761618-e4ec5ba3-dd00-470c-a39b-dd0cb0e4c51e.png)

6. Endpoints working:

![image](https://user-images.githubusercontent.com/92884809/223763739-a3f127fd-c146-4e67-9023-9a63eb1f1f7c.png)

### For the API Proxy project:

1. Just run the project pressing `F5`.

![image](https://user-images.githubusercontent.com/92884809/223762216-2194841a-3704-4a40-a2fc-6f98e16d0727.png)

2. Endpoints working:

![image](https://user-images.githubusercontent.com/92884809/223763153-107be93d-b4ef-492e-9ec4-98ba9a4d2446.png)

### Unit Tests passing

![image](https://user-images.githubusercontent.com/92884809/223762669-d0f38ddf-10ef-456c-9e18-0fe01cbb4d99.png)

I hope you enoy it. :v:
