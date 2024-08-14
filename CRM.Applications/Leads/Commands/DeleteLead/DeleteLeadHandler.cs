using CRM.Applications.Common.Interface;
using ErrorOr;
using MediatR;

namespace CRM.Leads.Commands.DeleteLead;


public class CreateLeadHandler : IRequestHandler<DeleteLeadCommand, ErrorOr<Success>>
{


    private readonly ILeadRepository _leadRepository;
    private readonly IUnitOfWork _unitOfWork;
    public CreateLeadHandler(ILeadRepository leadRepository, IUnitOfWork unitOfWork)
    {
        _leadRepository = leadRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Success>> Handle(DeleteLeadCommand request, CancellationToken cancellationToken)
    {
       
        
       var lead=await _leadRepository.GetOneAsync(request.id);
       var validator=lead.deleteLead();
          if(validator.IsError)
          return validator.Errors;
          
        await _leadRepository.DeleteAsync(lead);
        await _unitOfWork.CommitChangesAsync();
        return Result.Success;
        
    }
}



    


