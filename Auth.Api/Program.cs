using IoC.Admin;
using IoC.Auth;
using IoC.Global;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
SerilogIoC.ConfigureSeqService(builder);
Auth_AutomapperIoC.ConfigureService(builder);
Auth_DatabaseIoC.ConfigureMySQLService(builder);
Auth_BussinessLogicIoC.RepositoryService(builder);
Auth_BussinessLogicIoC.ReglasNegocioService(builder);

builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.MapControllers();
app.Run();
