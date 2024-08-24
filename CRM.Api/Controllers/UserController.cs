using CRM.Api.Common.Api;
using CRM.Api.Controllers.Common.Filters;
using CRM.Api.Controllers.Common.Mapping;
using CRM.Api.Controllers.Contracts;
using CRM.Applications.Users.Commands.AssignUserToRole;
using CRM.Users.Commands.CreateRole;
using CRM.Users.Queries.Login;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CRM.Api.Controllers
{
      [ApiController]
      [Route("[controller]")]
      public class UsersController : ApiController
      {
            public UsersController(ISender mediatR) : base(mediatR)
            {
            }


            [HttpPost(ApiEndpoints.Users.Create)]
           [Authorize(Policy = "user.write")]
            [ServiceFilter(typeof(CustomLog))]
            public async Task<IActionResult> CreateUser(CreateUserRequest request, CancellationToken token)
            {
                  var command = request.MapToUsersCommand();
                  var createUserResult = await _mediatR.Send(command);

                  return createUserResult.Match(User => Created($"{ApiEndpoints.Users.Get}?{User.Id}", User.MapToResponse()), Problem);

            }

            [HttpPost(ApiEndpoints.Users.CreateRole)]
            [Authorize(Policy = "user.write")]
            [ServiceFilter(typeof(CustomLog))]
            public async Task<IActionResult> CreateRole(CreateRoleCommand request, CancellationToken token)
            {
                  var command = request;
                  var createUserResult = await _mediatR.Send(command);

                  return createUserResult.Match(role => Created(), Problem);

            }

            [HttpPost(ApiEndpoints.Users.AssignRole)]
            [Authorize(Policy = "user.write")]
           [ServiceFilter(typeof(CustomLog))]
            public async Task<IActionResult> AssignRole(AssignUserToRoleCommand request, CancellationToken token)
            {
                  var command = request;
                  var _token = await _mediatR.Send(command);

                  return _token.Match(userToken => Created(), Problem);

            }



            [HttpPost(ApiEndpoints.Users.Login)]
            [AllowAnonymous]
            [ServiceFilter(typeof(CustomLog))]
            public async Task<IActionResult> Login(LoginQuery request, CancellationToken token)
            {
                  var command = request;
                  var _token = await _mediatR.Send(command);
                  return _token.Match(userToken => Created($"{ApiEndpoints.Users.Login}", userToken), Problem);

            }


      }

}
