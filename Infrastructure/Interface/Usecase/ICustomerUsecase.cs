using Domain.Entities.Customer;
using Infrastructure.DTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces.Usecase
{
    public  interface   ICustomerUsecase  
    
    {
        
        public   Task<IdentityResult> registration(SystemUser data);
        public   Task<SystemUser> login(SystemUser data);

        public   Task<SystemUser> addCustomer(SystemUser data);
        public   Task<List<SystemUser>> getCustomer();

      
    }
}
