step 1: cd (project location)
step 2: change ur conection string to your db
step 3: at nuget package manager console run: dotnet ef migrations add InitialMigrationDB
step 4: at nuget package manager console run: dotnet ef database update