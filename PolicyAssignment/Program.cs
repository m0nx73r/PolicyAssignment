using Microsoft.EntityFrameworkCore;
using PolicyAssignment.DAL.DbContexts;
using PolicyAssignment.DAL.Entities;
using PolicyAssignment.DAL.Repositories.Implemented;
using PolicyAssignment.DAL.Repositories.Interface;
using PolicyAssignment.MappingProfiles;
using PolicyAssignment.Services.Implemented;
using PolicyAssignment.Services.Interface;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer("name=DefaultConnection");
});

// Adding AutoMapper Profile
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

//Service Registration

builder.Services.AddScoped<IDocumentTemplateRepository, DocumentTemplateRepository>();
builder.Services.AddScoped<IDocumentRepository, DocumentRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddTransient<IHtmlMapperService, HtmlMapperService>();
builder.Services.AddTransient<IHandlebarService, HandlebarService>();
builder.Services.AddTransient<IHtmlToPDFService, HtmlToPDFService>();
builder.Services.AddTransient<IHtmlMapperServiceV2, HtmlMapperServiceV2>();
builder.Services.AddTransient<IDocumentCreationService, DocumentCreationService>();
builder.Services.AddTransient<IDocumentTemplateService, DocumentTemplateService>();
builder.Services.AddTransient<IUserService, UserService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
