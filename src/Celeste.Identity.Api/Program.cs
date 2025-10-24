using Celeste.Identity.Api.Validators;
using Celeste.Identity.Application;
using Celeste.Identity.Application.Installers;
using Celeste.Identity.Data.Installers;
using Celeste.Identity.Data.Mapping;
using FluentValidation;
using Celeste.Identity.Application.Mapping;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidationFilter>();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .InstallDatabase(builder.Configuration)
    .AddAutoMapper(cfg =>
    {
        cfg.ConfigureDomainMappings();
        cfg.ConfigureDataMappings();
    })
    .RegisterRequestHandlers()
    .AddValidatorsFromAssemblyContaining<Program>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.Run();
