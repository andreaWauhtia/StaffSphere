using Microsoft.AspNetCore.Builder;
using _3T.StaffSphere.Common;
using _3T.StaffSphere.Application;
using _3T.StaffSphere.Persistence;
using _3T.StaffSphere.Infrastructure;
using _3T.StaffSphere.Domain;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.ConfigureStaffSphereCommonDependencies(builder.Configuration);
builder.Services.BuildStaffSphereApplication(builder.Configuration);
builder.Services.BuildPersistence(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var toto = builder.Host;

builder.Services.AddHttpContextAccessor();



builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();


// Customise default API behaviour
builder.Services.Configure<ApiBehaviorOptions>(options =>
    options.SuppressModelStateInvalidFilter = true);

//builder.Services.AddOpenApiDocument((configure, serviceProvider) =>
//{
//    var fluentValidationSchemaProcessor = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<FluentValidationSchemaProcessor>();

//    // Add the fluent validations schema processor
//    configure.SchemaProcessors.Add(fluentValidationSchemaProcessor);

//    configure.Title = "CleanArchitecture API";
//    configure.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
//    {
//        Type = OpenApiSecuritySchemeType.ApiKey,
//        Name = "Authorization",
//        In = OpenApiSecurityApiKeyLocation.Header,
//        Description = "Type into the textbox: Bearer {your JWT token}."
//    });

//    configure.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));
//});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

// Add the following line to configure routing.
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller}/{action=Index}/{id?}");
});

app.Run();
