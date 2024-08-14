using CRM.Applications.Common.Interface;
using CRM.Domain.Applications;
using CRM.Services.Common.Interface;
using ErrorOr;
using MediatR;
namespace CRM.Applications.Commands.CreateApplications;


public class CreateApplicationsHandler : IRequestHandler<CreateApplicationsCommand, ErrorOr<Domain.Applications.Application>>
{


    private readonly IApplicationsRepository _applicationsRepository;
    private readonly IServicesRepository _servicesRepository;
    private readonly ILeadRepository _leadRepository;
    private readonly IUnitOfWork _unitOfWork;
    public CreateApplicationsHandler(IApplicationsRepository applicationsRepository, IUnitOfWork unitOfWork, IServicesRepository servicesRepository = null, ILeadRepository leadRepository = null)
    {

        _unitOfWork = unitOfWork;
        _servicesRepository = servicesRepository;
        _leadRepository = leadRepository;
        _applicationsRepository = applicationsRepository;
    }

    public async Task<ErrorOr<Domain.Applications.Application>> Handle(CreateApplicationsCommand request, CancellationToken cancellationToken)
    {

        var lead = await _leadRepository.GetOneAsync(request.LeadId);
        var service = await _servicesRepository.GetOneAsync(request.ServiceId);
        var application = new Application();

        var status = await application.AddApplication(lead, service, request.Name);
        if (status.IsError)
            return status.Errors;

        await _applicationsRepository.AddAsync(application);
        await _unitOfWork.CommitChangesAsync();
        return application;
    }

}






