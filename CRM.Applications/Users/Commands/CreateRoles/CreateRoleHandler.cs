using CRM.Applications.Common.Interface;
using CRM.Domain.Users;
using CRM.Users.Commands.CreateRole;
using ErrorOr;
using MediatR;

namespace CRM.Users.Commands.CreateUser;


public class CreateRoleHandler : IRequestHandler<CreateRoleCommand, ErrorOr<Success>>
{


    private readonly IUserRepository _UserRepository;
    private readonly IUnitOfWork _unitOfWork;
    public CreateRoleHandler(IUserRepository UserRepository, IUnitOfWork unitOfWork)
    {
        _UserRepository = UserRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Success>> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {

        var _role = await _UserRepository.getRole(request.RoleName, cancellationToken);
        if (_role.IsError)
            _role = await _UserRepository.addRole(request.RoleName, cancellationToken);

        await _UserRepository.addPermissionToRole(_role.Value, request.Permission, cancellationToken);
        await _unitOfWork.CommitChangesAsync();
        return Result.Success;
    }

}






