using IoC.Admin;
using IoC.Auth;
using IoC.Global;

var builder = WebApplication.CreateBuilder(args);

Auth_AutomapperIoC.ConfigureService(builder);
Auth_DatabaseIoC.ConfigureMySQLService(builder);
Auth_BussinessLogicIoC.RepositoryService(builder);
Auth_BussinessLogicIoC.ReglasNegocioService(builder);
ApiConfiguration.ConfigureServices(builder);

var app = builder.Build();

ApiConfiguration.ConfigureApp(app);
