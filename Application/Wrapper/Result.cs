using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Wrapper
{
    public  class Result<T> where T:class
    {
        String message;
        String status;
        T data;
        
        public  Result(T data, String message = "", String status = "200")
        {
            this.data = data;
            this.message = message;
            this.status = status;
   
      }
    }

}
