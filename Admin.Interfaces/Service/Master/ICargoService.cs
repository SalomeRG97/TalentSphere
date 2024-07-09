using Admin.DTO;

namespace Admin.Interfaces.Service.Master
{
    public interface ICargoService
    {
        Task Add(CargoCreateDTO dto);
        Task Delete(CargoDTO dto);
        Task<List<CargoDTO>> GetAll();
        Task Update(CargoDTO dto);
    }
}