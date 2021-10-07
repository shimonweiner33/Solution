using Solution.Data.Models;
using System;
using System.Threading.Tasks;

namespace Solution.Services
{
    public interface IAcountService
    {
        Task<bool> IsValidUser(Login login);
        Task<bool> Register(Register registerDetails);
    }
}
