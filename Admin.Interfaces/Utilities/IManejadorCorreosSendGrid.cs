using Admin.DTO.Utilities;

namespace Admin.Interfaces.Utilities
{
    public interface IManejadorCorreosSendGrid
    {
        Task Enviar(DatosEnvioCorreoDTO dto);
    }
}