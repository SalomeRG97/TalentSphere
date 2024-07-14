using Admin.DTO.Utilities;
using Admin.Interfaces.Utilities;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Utilidades
{
    public class ManejadorCorreosSendGrid : IManejadorCorreosSendGrid
    {
        public ManejadorCorreosSendGrid()
        {
        }

        public async Task Enviar(DatosEnvioCorreoDTO dto)
        {
            var ApiKey = "";

            var apiKey = ApiKey;
            var client = new SendGridClient(apiKey);
            var datosRemitente = new EmailAddress(dto.CorreoRemitente, dto.NombreRemitente);
            var plainTextContent = "";
            var datosDestinatario = new EmailAddress(dto.CorreoDestinatario, dto.NombreDestinatario);
            var msg = MailHelper.CreateSingleEmail(datosRemitente, datosDestinatario, dto.Asunto, plainTextContent, dto.ContenidoHTML);
            var response = await client.SendEmailAsync(msg);

        }
    }
}
