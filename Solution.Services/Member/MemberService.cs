using System;
using System.Threading.Tasks;
using Solution.Data.Models;
using Solution.Data.Repository.Interface;

namespace Solution.Services
{
    public class MemberService : IMemberService
    {
        private IMemberRepository memberRepository;
        private IAcountRepository acountRepository;
        private IAcountService acountService;


        public MemberService(IMemberRepository memberRepository, IAcountRepository acountRepository, IAcountService acountService)
        {
            this.memberRepository = memberRepository;
            this.acountRepository = acountRepository;
            this.acountService = acountService;

        }

        public async Task<Member> GetMember(Login login)
        {
            var IsValidUser = await acountService.IsValidUser(login);
            if (IsValidUser)
            {
                var member = await memberRepository.GetMember(login.UserName);
                return member;
            }
            return null;
        }

        public async Task<Member> GetMemberByUserName(string userName)
        {
            if (!string.IsNullOrEmpty(userName)){
                var member = await memberRepository.GetMember(userName);
                return member;
            }
            return null;
        }
    }
}
