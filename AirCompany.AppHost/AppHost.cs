var builder = DistributedApplication.CreateBuilder(args);

var password = builder.AddParameter("DatabasePassword");
var dbName = "air-company";

var airCompanyDb = builder
    .AddPostgres("air-company-db", password: password)
    .AddDatabase(dbName);

builder.AddProject<Projects.AirCompany_Api_Host>("aircompany-api-host")
    .WithReference(airCompanyDb, "Database")
    .WaitFor(airCompanyDb);

builder.Build().Run();