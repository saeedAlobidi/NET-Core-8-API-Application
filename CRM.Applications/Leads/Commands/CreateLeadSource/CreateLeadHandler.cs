using CRM.Applications.Common.Interface;
using CRM.Domain.Leads;
using ErrorOr;
using MediatR;

namespace CRM.Leads.Commands.CreateLeadSource;


public class CreateLeadSourceHandler : IRequestHandler<CreateLeadSourceCommand, ErrorOr<LeadSource>>
{


    private readonly ILeadSourcesRepository _ILeadSourcesRepository;
    private readonly IUnitOfWork _unitOfWork;
    public CreateLeadSourceHandler(ILeadSourcesRepository ILeadSourcesRepository, IUnitOfWork unitOfWork)
    {
        _ILeadSourcesRepository = ILeadSourcesRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<LeadSource>> Handle(CreateLeadSourceCommand request, CancellationToken cancellationToken)
    {
        LeadSource leadSource = await _ILeadSourcesRepository.GetOneAsync(request.id, cancellationToken);

        leadSource = leadSource == null ? new LeadSource() : leadSource;
        leadSource.Translations.Add(new TranslatedLeadSource(request.Name));
        if (leadSource.Id < 1)
            await _ILeadSourcesRepository.AddAsync(leadSource, cancellationToken);
        await _unitOfWork.CommitChangesAsync();
        return leadSource;
    }

}






