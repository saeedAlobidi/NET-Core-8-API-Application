using CRM.Applications.Common.Interface;
using CRM.Domain.Users;
using ErrorOr;
using MediatR;

namespace CRM.Users.Commands.CreateUser;


public class CreateUserHandler : IRequestHandler<CreateUserCommand, ErrorOr<User>>
{


    private readonly IUserRepository _UserRepository;
    private readonly IUnitOfWork _unitOfWork;
    public CreateUserHandler(IUserRepository UserRepository, IUnitOfWork unitOfWork)
    {
        _UserRepository = UserRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<User>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        User User = new()
        {

            UserName = request.UserName,
            Name = request.Email,
            PasswordHash = request.PasswordHash,
            linkedin = request.Linkedin
        };
    
    
        var status = await User.AddUser();
        if (status.IsError)
            return status.Errors;

        var x = await _UserRepository.AddAsync(User, cancellationToken);
        await _unitOfWork.CommitChangesAsync();
        if (x.IsError)
            return x.Errors;
        return User;
    }

}






