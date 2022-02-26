using Application.Constraints;
using Domain.Entities.Customer;
using Infrastructure.DbContexts;
using Infrastructure.DTOs;
using Infrastructure.Interfaces.Usecase;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Usecase
{

   public class CustomerUsecase : ICustomerUsecase
    {
        private SignInManager<SystemUser> signInManager; 
        private UserManager<SystemUser> userManager;
        private Application.Interfaces.Repositories.ICustomer ICustomer;
         
        public CustomerUsecase(UserManager<SystemUser> userManager,Application.Interfaces.Repositories.ICustomer ICustomer, SignInManager<SystemUser> signInManager)  
        {
            this.userManager = userManager;
            this.ICustomer = ICustomer;
            this.signInManager = signInManager;
         
        }

        public Task<SystemUser> addCustomer(SystemUser data)
        {
            throw new NotImplementedException();
        }

        public Task<List<SystemUser>> getCustomer()
        {
            throw new NotImplementedException();
        }

        public async Task<SystemUser> login(SystemUser data)
        {
            var result = await this.userManager.FindByEmailAsync(data.Email);
            await this.signInManager.SignInAsync(result,true);
            return result;

        }

        public async Task<IdentityResult> registration(SystemUser data)
        {
            
            var result = await this.userManager.CreateAsync(data, data.PasswordHash);
            if (result.Succeeded)
            {
                
                await this.userManager.AddToRolesAsync(data, new List<string>() { Roles.Guest.ToString() });
            }
                return result;
        }
    }
}
