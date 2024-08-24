using CRM.Applications.Common.Interface;
using CRM.Domain.Users;
using CRM.Users.Commands.CreateRole;
using ErrorOr;
using MediatR;

namespace CRM.Applications.Users.Commands.AssignUserToRole;


public class AssignUserToRoleHandler : IRequestHandler<AssignUserToRoleCommand, ErrorOr<Success>>
{


    private readonly IUserRepository _UserRepository;
    private readonly IUnitOfWork _unitOfWork;
    public AssignUserToRoleHandler(IUserRepository UserRepository, IUnitOfWork unitOfWork)
    {
        _UserRepository = UserRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Success>> Handle(AssignUserToRoleCommand request, CancellationToken cancellationToken)
    {

        var user =await _UserRepository.GetOneAsync(request.username, cancellationToken);
        await _UserRepository.addRoleToUser(user, request.roleName, cancellationToken);
        await _unitOfWork.CommitChangesAsync();
        return Result.Success;
    }

}






