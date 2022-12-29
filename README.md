Welcome to my Grocery List demo app


You will need each of the following to run the projects:
- a local instance of SQL server express
- .NET 6
- Visual Studio or similar IDE with the following NuGet Packages:
	- Microsoft.EntityFrameworkCore
	- Microsfot.EntityFrameworkCore.Design
	- Microsoft.EntityFrameworkCore.SqlServer
	- Microsoft.EntityFrameworkCore.Tools
- In order to run GroceryLogicTest project, you will need additional NuGet Packages
	- Moq
	- xunit
	- Microsoft.NET.Test.Sdk


- VS Code or similar IDE with node.js and latest angular/Cli (15.0.4) installed


Steps to setup and run the back end:
1. Open 'grocery-api' solution in visual studio
2. Ensure necessary NuGet packages are installed
3. Open package manager console and run 'update-database' to initialize the database. This should include seeded data.
4. Optionally, run the xUnit tests included in 'GroceryLogicTest' project
5. Finally, Run the 'grocery-api' project

Steps to setup and run the front end:
1. Open 'grocery-list-app' folder in VS Code
2. Run 'ng version' to ensure latest angular/Cli is installed
3. Run npm i to install additonal packages
4. Run ng serve --open to launch the application in browser

