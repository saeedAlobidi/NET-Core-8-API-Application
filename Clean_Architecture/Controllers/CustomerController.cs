using Application.Constraints;
using Infrastructure.Interfaces.Usecase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clean_Architecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private ICustomerUsecase ICustomerUsecase;
        public CustomerController(ICustomerUsecase ICustomerUsecase)
        {
            this.ICustomerUsecase = ICustomerUsecase;
        }

        [HttpGet("Regstration")]
        public async Task<Boolean> Regstration()
        {
            var data = new Infrastructure.DTOs.SystemUser();
            data.UserName = "saeed@gmail.com";
            data.Email = "saeed@gmail.com";
            data.age = "10";
            data.PasswordHash = "Saeed_MSS@111";
            await this.ICustomerUsecase.registration(data);
            return true;
        }

        [HttpGet("Login")]
        public async Task<Infrastructure.DTOs.SystemUser> Login()
        {
            var data = new Infrastructure.DTOs.SystemUser();
            data.UserName = "saeed@gmail.com";
            data.Email = "saeed@gmail.com";
            data.age = "10";
            data.PasswordHash = "Saeed_MSS@111";
            var result=await this.ICustomerUsecase.login(data);
            return result;
        }

        [HttpGet("Customer")]
        //[Authorize(Roles= Roles.Guest)]
        [Authorize(Policy  = GeneralPermisstions.write)]
        public async Task<Boolean> Customer()
        {
          
            return true;
        }
    }
}
