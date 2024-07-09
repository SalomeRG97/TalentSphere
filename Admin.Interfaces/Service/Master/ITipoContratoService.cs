using Admin.DTO;

namespace Admin.Interfaces.Service.Master
{
    public interface ITipoContratoService
    {
        Task Add(TipoContratoCreateDTO dto);
        Task Delete(TipoContratoDTO dto);
        Task<List<TipoContratoDTO>> GetAll();
        Task Update(TipoContratoDTO dto);
    }
}