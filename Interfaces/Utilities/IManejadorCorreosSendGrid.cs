using DTO.Utilities;

namespace Interfaces.Utilities
{
    public interface IManejadorCorreosSendGrid
    {
        Task Enviar(DatosEnvioCorreoDTO dto);
    }
}