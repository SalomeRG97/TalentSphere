using Admin.Interfaces.Utilities.ApiAuth;
using Admin.Interfaces.Base;
using Hangfire;
using Mysqlx.Prepare;
using Admin.DTO.Api;
using DTO.ServiceCall;
using System.Text.Json;
using Admin.Entities.Models;
using Org.BouncyCastle.Asn1.Ocsp;
using AutoMapper;
using Exceptions;


namespace Admin.Services.Job
{
    public class DarAltaEmpleadoJob(IUnitOfWork _unitOfWork, IApiAuthService _apiAuthService, IMapper _mapper)
    {
        public async Task Execute()
        {
            var events = await _unitOfWork.BacklogsEventRepository.GetAllAsync(x => x.CompletedAt == null && x.EventType == (int)EventsEnum.DarAltaEmpleado);
            foreach (var item in events)
            {
                var @event = JsonSerializer.Deserialize<RequestActivarEmpleado>(item.Json);
                try
                {
                    var task = _apiAuthService.ActivarEmpleado(@event);
                    task.Wait(5000);

                    if(!task.IsCompleted || !task.Result)
                    {
                        throw new BadRequestException("Error al dar de alta al empleado.");
                        continue;
                    }

                    item.CompletedAt = DateTime.Now;
                    await _unitOfWork.BacklogsEventRepository.UpdateAsync(item);
                    await _unitOfWork.Commit();
                }
                catch (BadRequestException ex)
                {
                    throw;
                }
                catch (Exception)
                {
                    throw new InternalServerErrorException("Ha ocurrido un error inesperado, intente de nuevo mas tarde, si el error persiste contacte con soporte.");
                    continue;
                }
            }

        }
    }
}
