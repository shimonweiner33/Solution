using Solution.Data.Models;
using System;
using System.Threading.Tasks;

namespace Solution.Services
{
    public interface IMemberService
    {
        Task<Member> GetMember(Login login);
        Task<Member> GetMemberByUserName(string userName);
    }
}
