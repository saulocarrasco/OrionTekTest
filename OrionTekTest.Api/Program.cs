using OrionTekTest.Configurations.Repository;
using OrionTekTest.Configurations.Service;
using OrionTekTest.Configurations.Cors;
using OrionTekTest.Configurations.Validators;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using OrionTekTest.Domain.Dtos;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCustomerDbContext(builder.Configuration);
builder.Services.AddRepositories();
builder.Services.AddService();
builder.Services.AddValidators();
builder.Services.AddCorsConfiguration("CustomerApiCors");

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Customer API", Version = "v1" });
});


builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.
ReferenceHandler = ReferenceHandler.IgnoreCycles).ConfigureApiBehaviorOptions(options =>
{
    options.SuppressModelStateInvalidFilter = true;

    options.InvalidModelStateResponseFactory = c =>
    {
        var errors = c.ModelState.Values.Where(v => v.Errors.Count > 0)
                        .SelectMany(v => v.Errors).Select(p => p.ErrorMessage);
        var result = new BaseOperationResult
        {
            Title = "Error",
            Errors = errors,
            TraceId = c.HttpContext.TraceIdentifier
        };

        return new BadRequestObjectResult(result);
    };

});


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("CustomerApiCors");

app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Customer API V1");
});

app.Run();
