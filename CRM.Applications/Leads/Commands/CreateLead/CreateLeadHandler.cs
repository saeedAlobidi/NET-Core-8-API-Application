using CRM.Applications.Common.Interface;
using ErrorOr;
using MediatR;

namespace  CRM.Leads.Commands.CreateLead;


public class CreateLeadHandler : IRequestHandler<CreateLeadCommand, ErrorOr<Domain.Leads.Lead>>
{


    private readonly ILeadRepository _leadRepository;
    private readonly IUnitOfWork _unitOfWork;
    public CreateLeadHandler(ILeadRepository leadRepository, IUnitOfWork unitOfWork)
    {
        _leadRepository = leadRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Domain.Leads.Lead>> Handle(CreateLeadCommand request, CancellationToken cancellationToken)
    {
        var lead = new Domain.Leads.Lead
        {
             age = request.Age,
            name = request.Name,
            email = request.Email,
            linkedin = request.Linkedin
        };
        var status = await lead.AddLead();
        if (status.IsError)
            return status.Errors;
        await _leadRepository.AddAsync(lead);
        await _unitOfWork.CommitChangesAsync();
        return lead;
    }

 }



    


