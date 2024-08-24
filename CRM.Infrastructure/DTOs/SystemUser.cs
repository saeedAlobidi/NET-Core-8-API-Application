
using CRM.Domain.Users;
using Microsoft.AspNetCore.Identity;

namespace CRM.Infrastructure.DTOs;


public class SystemUser : IdentityUser<int>
{


     public String? linkedin { get; set; }
     public string Name { get; set; }

     public SystemUser toSystemUser(User user)
     {

          return new SystemUser
          {
               Id = user.Id,
               UserName = user.UserName,
               Name = user.Name,
               PasswordHash = user.PasswordHash,
               linkedin = user.linkedin,

          };
     }



}


public static class SystemUserMaping
{

     public static SystemUser MapToSystemUser(this User user)
     {
          return new SystemUser
          {
               Id = user.Id,
               UserName = user.UserName,
               Name = user.Name,
               linkedin = user.linkedin,

          };


     }

     public static User MapToSUser(this SystemUser systemUser)
     {
          return new User
          {
               Id = systemUser.Id,
               UserName = systemUser.UserName,
               Name = systemUser.Name,
               linkedin = systemUser.linkedin,

          };


     }
}