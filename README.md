# Agrovision_Poc

This is an assessment done for AgroVision calculator.
This is a sample micro service made with dot net core using Microsoft Orleans(https://dotnet.github.io/orleans/ )for hosting the service logic, Inter-service communication done using DotNetCore gRPC Services(https://docs.microsoft.com/en-us/aspnet/core/grpc/?view=aspnetcore-3.1) and commucation to the website is done with a standard Web Api and Gateway.


Getting Started:
1. Install the DotNetCore 3.1 sdk.
2. The project uses an mssql database to store pre-configured data(Field sizes, Spraying Agents, Spraying volunms).
3. In the project there will be a SQLdb Project, publish it to the local mssql
4. After the db publish is done, start up the projects in the follow order:
  4.1 First start the silo project located in "Agrovision\spray-calculator\Services\Silo\Agrovision.Spray_Calculator.Services.Silo"
  as soon as the silo runs open the folowing in the browser ( http://localhost:8080/ ) and the dashboard will be visible.
  4.2 Next we need to start up the gRPC Client located in "Agrovision\spray-calculator\gRPC\Agrovision.Spray_Calculator.gRPC", Confirm       that the port is set to 5001 and none ssl(http://localhost:5001).
  4.3 After the Silo and gRPC client is running, we can start up the API endpoint located in 
  "Agrovision\spray-calculator\WebApi\Agrovision.Spray_Calculator.Api" Make sure to run it on port 65315 none ssl(http://localhost:65315)
  we can view swagger on the API and run a few tests.
  4.4 After all of the endpoints are running we can start up the website by running "npm install" and "ng serve".
5. After all of the above steps are done, open http://localhost:4200 create the data needed or sample test the calculator.
  
