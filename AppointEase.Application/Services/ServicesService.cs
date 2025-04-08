using AppointEase.Application.Interfaces;
using AppointEase.Domain.Interfaces.UnitOfWork;

namespace AppointEase.Application.Services
{
    public class ServicesService(IUnitOfWork unitOfWork) : BaseService<Domain.Entities.Services>(unitOfWork), IServicesService
    {
    }
}
