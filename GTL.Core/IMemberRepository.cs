using System.Collections.Generic;

namespace GTLCore
{
    public interface IMemberRepository
    {
        List<Member> GetAll();
        int Insert(Member member);
        bool Update(Member member);
        bool Delete(int ssn);
    }
}

