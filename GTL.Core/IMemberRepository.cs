using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

