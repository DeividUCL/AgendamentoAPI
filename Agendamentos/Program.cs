using Agendamentos;
using Agendamentos.Contexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("AgendaConnection");
builder.Services.AddDbContext<AgendamentoContext>(options => options.UseSqlServer(connectionString));
// Add services to the container.

builder.Services.AddCors();
builder.Services.AddControllers();
var chave = Encoding.ASCII.GetBytes(Settings.ChaveSecreta);
builder.Services.AddAuthentication(x =>
{
	x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
	x.RequireHttpsMetadata = false; // requerer https
	x.SaveToken = true; // salva token
	x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
	{ //validacoes do token
		ValidateIssuerSigningKey = true, // validacao de chave
		IssuerSigningKey = new SymmetricSecurityKey(chave), //chave precisa ser simetrica
		ValidateIssuer = false,
		ValidateAudience = false,
	};
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(x => x
	.AllowAnyOrigin()
	.AllowAnyMethod()
	.AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();


