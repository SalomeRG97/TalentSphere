using IoC.Global;
using IoC.Admin;

var builder = WebApplication.CreateBuilder(args);

Admin_AutomapperIoC.ConfigureService(builder);
Admin_DatabaseIoC.ConfigureMySQLService(builder);
Admin_BussinessLogicIoC.RepositoryService(builder);
Admin_BussinessLogicIoC.ReglasNegocioService(builder);
ApiConfiguration.ConfigureServices(builder);

var app = builder.Build();

ApiConfiguration.ConfigureApp(app);