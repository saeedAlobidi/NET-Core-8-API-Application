using CRM.Applications.Common.Interface;
using CRM.Domain.Leads;
using ErrorOr;
using MediatR;

namespace CRM.Leads.Queries.GetLeads;


public class GetLeadQueryHandler : IRequestHandler<GetLeadQuery, ErrorOr<Lead>>
{


    private readonly ILeadRepository _leadRepository;
    private readonly IUnitOfWork _unitOfWork;
    public GetLeadQueryHandler(ILeadRepository leadRepository, IUnitOfWork unitOfWork)
    {
        _leadRepository = leadRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Lead>> Handle(GetLeadQuery request, CancellationToken cancellationToken)
    {
       return await _leadRepository.GetOneAsync(request.LeadId);
        

    }

}






