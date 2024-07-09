using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using Serilog.Sinks.Seq;

namespace IoC.Global
{
    public class SerilogIoC
    {
        [Obsolete]
        public static void SQLServerLogs(WebApplicationBuilder builder)
        {
            // Opciones de columnas para SQL Server
            var columnOptions = new ColumnOptions
            {
                AdditionalColumns = new List<SqlColumn>
            {
                new SqlColumn
                {
                    ColumnName = "RequestId",
                    PropertyName = "RequestId",
                    DataType = System.Data.SqlDbType.NVarChar,
                    DataLength = 50
                }
            }
            };

            // Opcional: remover la columna XML Properties si no la necesitas
            columnOptions.Store.Remove(StandardColumn.Properties);

            // Configurar el logger de Serilog
            Log.Logger = new LoggerConfiguration()
                .WriteTo.MSSqlServer(
                    connectionString: builder.Configuration.GetConnectionString("DefaultConnection"),
                    tableName: "Logs",
                    columnOptions: columnOptions,
                    autoCreateSqlTable: true)
                .Enrich.FromLogContext()
                .CreateLogger();

            // Usar el logger configurado
            builder.Host.UseSerilog(Log.Logger);
        }

        //public static void ConfigLogSeqAndSqlServer(WebApplicationBuilder builder)
        //{
        //    // Cargar la configuración desde appsettings.json
        //    IConfigurationRoot configuration = new ConfigurationBuilder()
        //        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        //        .Build();

        //    // Configurar el logger de Serilog usando la configuración cargada
        //    Log.Logger = new LoggerConfiguration()
        //        .ReadFrom.Configuration(configuration)
        //        .CreateLogger();

        //    // Usar el logger configurado
        //    builder.Host.UseSerilog(Log.Logger);
        //}
        public static void ConfigureSeqService(WebApplicationBuilder builder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
              .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            builder.Host.UseSerilog(Log.Logger);
        }
    }
}