using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityTuitionPayment.Context;
using UniversityTuitionPayment.Source.Svc;

var builder = WebApplication.CreateBuilder(args);
var Services = builder.Services;

// Add services to the container.

Services.AddControllers();
Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
Services.AddEndpointsApiExplorer();
Services.AddSwaggerGen();

//var connectionString = builder.Configuration.GetConnectionString("AdminConnection");
//string connectionString = "Server=tcp:universitytuitionpaymentdbserver.database.windows.net,1433;Initial Catalog=UniversityTuitionPayment_db;Persist Security Info=False;User ID=kaanb;Password=universityPaymetnTuititonDb.123H2V3!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
string connectionString = "Data Source=tcp:universitytuitionpaymentdbserver.database.windows.net,1433;Initial Catalog=UniversityTuitionPayment_db;User Id=kaanb@universitytuitionpaymentdbserver;Password=universityPaymetnTuititonDb.123H2V3!";
Services.AddDbContext<UniversityTuitionPaymentContext>(options => { options.UseSqlServer(connectionString); });

Services.AddScoped<IBankAccountService, BankAccountService>();
Services.AddScoped<IStudentService, StudentService>();
Services.AddScoped<ITermService, TermService>();
Services.AddScoped<ITuitionService, TuitionService>();
Services.AddScoped<IUniversityService, UniversityService>();

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

app.Run();


