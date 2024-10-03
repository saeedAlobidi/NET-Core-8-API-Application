using CRM.Applications.Common.Interface;
using CRM.Domain.Leads;
using ErrorOr;
using MediatR;

namespace CRM.Leads.Commands.CreateLeadSource;


public class CreateLeadStatusHandler : IRequestHandler<CreateLeadStatusCommand, ErrorOr<LeadStatus>>
{


    private readonly ILeadStatusRepository _ILeadStatusRepository;
    private readonly IUnitOfWork _unitOfWork;
    public CreateLeadStatusHandler(ILeadStatusRepository ILeadStatusRepository, IUnitOfWork unitOfWork)
    {
        _ILeadStatusRepository = ILeadStatusRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<LeadStatus>> Handle(CreateLeadStatusCommand request, CancellationToken cancellationToken)
    {
        LeadStatus leadStatus = await _ILeadStatusRepository.GetOneAsync(request.id, cancellationToken);

        leadStatus = leadStatus == null ? new LeadStatus() : leadStatus;
        leadStatus.Translations.Add(new TranslatedLeadStatus(request.Name));
        if (leadStatus.Id < 1)
            await _ILeadStatusRepository.AddAsync(leadStatus, cancellationToken);
        await _unitOfWork.CommitChangesAsync();
        return leadStatus;
    }

}






