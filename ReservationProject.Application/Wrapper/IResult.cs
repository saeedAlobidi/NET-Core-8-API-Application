using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationProject.Application.Wrapper
{
    public interface IResult
    { 
        List<string> Messages { get; set; }
        bool Succeeded { get; set; }
    } 
    public interface IResult<out T> : IResult
    {
        T Data { get; }
    }
}