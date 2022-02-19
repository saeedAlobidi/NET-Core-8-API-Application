using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationProject.Application.Interfaces.Shared
{
    public interface IAuthenticatedUserService
    {
        string UserId { get; }
        string Username { get; }
    }
}
