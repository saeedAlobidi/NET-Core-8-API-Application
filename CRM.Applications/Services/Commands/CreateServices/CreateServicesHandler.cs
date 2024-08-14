using CRM.Applications.Common.Interface;
using CRM.Services.Common.Interface;
using ErrorOr;
using MediatR;

namespace CRM.Services.Commands.CreateServices;


public class CreateServicesHandler : IRequestHandler<CreateServicesCommand, ErrorOr<Domain.Services.Service>>
{


    private readonly IServicesRepository _servicesRepository;
    private readonly IUnitOfWork _unitOfWork;
    public CreateServicesHandler(IServicesRepository servicesRepository, IUnitOfWork unitOfWork)
    {
        _servicesRepository = servicesRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Domain.Services.Service>> Handle(CreateServicesCommand request, CancellationToken cancellationToken)
    {
        var service = new Domain.Services.Service
        {
            name = request.Name,
            price = request.Price,
        };
        var status = await service.AddService();
        if (status.IsError)
            return status.Errors;
        await _servicesRepository.AddAsync(service);
        await _unitOfWork.CommitChangesAsync();
        return service;
    }

}






