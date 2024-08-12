using CloudinaryDotNet;
using HR_Management_System.Controllers.AttendanceController.Mutation;
using HR_Management_System.Controllers.AttendanceController.Query;
using HR_Management_System.Controllers.EmployeeController;
using HR_Management_System.Controllers.EmployeeController.Mutation;
using HR_Management_System.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
builder.Services.AddControllers();

// Here we will add the services of the sql Server database
builder.Services.AddDbContext<HRDBContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("HRConnection"))
 );

//Add the services of the graphql
builder.Services.AddGraphQLServer()
                .AddQueryType<EmployeeQuery>()
                .AddMutationType<EmployeeMutation>()
                .AddTypeExtension<DepartmentQuery>()
                .AddTypeExtension<DepartmentMutation>()
                .AddTypeExtension<AttendanceDayMutation>()
                .AddTypeExtension<AttendanceDayQuery>()
                .AddTypeExtension<AttendanceRecordsMutation>()
                .AddTypeExtension<AttendanceRecordsQuery>()
                .AddTypeExtension<LeaveRequestsMutation>()
                .AddTypeExtension<LeaveRequestsQuery>()
                .AddUploadType()
                .AddProjections()
                .AddFiltering()
                .AddSorting();

//Here we add the cors policy authentication

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
    policy =>
    {
        policy.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

// here we add the cloudinary for image storage.
builder.Services.AddSingleton<ImageService>();
builder.Services.AddControllersWithViews();

var cloudinaryAccount = new Account(
        "dbzfyc8rt",
        "797669697474335",
        "fANFiFupKVEkCVF7YDaGwbunnwU"
    );
Cloudinary cloudinary = new Cloudinary(cloudinaryAccount);
builder.Services.AddSingleton(cloudinary);

var app = builder.Build();
app.MapGraphQL();
app.UseCors();
app.Run();