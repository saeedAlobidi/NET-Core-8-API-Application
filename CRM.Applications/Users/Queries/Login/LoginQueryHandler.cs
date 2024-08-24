using CRM.Applications.Common.Interface;
using CRM.Domain.Users;
using ErrorOr;
using MediatR;

namespace CRM.Users.Queries.Login;


public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<string>>
{


    private readonly IUserRepository _UserRepository;
    private readonly IUnitOfWork _unitOfWork;
    public LoginQueryHandler(IUserRepository UserRepository, IUnitOfWork unitOfWork)
    {
        _UserRepository = UserRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<string>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
         return await _UserRepository.Login(request.userName, request.password, cancellationToken);


    }

}






