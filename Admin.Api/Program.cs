using IoC.Global;
using IoC.Admin;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();


SerilogIoC.ConfigureSeqService(builder);
Admin_AutomapperIoC.ConfigureService(builder);
Admin_DatabaseIoC.ConfigureMySQLService(builder);
Admin_BussinessLogicIoC.RepositoryService(builder);

Admin_BussinessLogicIoC.ReglasNegocioService(builder);
Admin_BussinessLogicIoC.UtilidadesService(builder);

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