using Autofac;
using DataAccess;
using GTLCore;
using System.Collections.Generic;

namespace Services
{
    public class MemberService
    {
        static IContainer _container;
        static MemberService()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<MemberRepository>().As<IMemberRepository>();
            _container = builder.Build();
        }
        public static bool Delete(int ssn)
        {
            return _container.Resolve<IMemberRepository>().Delete(ssn);
        }
        public static List<Member> GetAll()
        {
            return _container.Resolve<IMemberRepository>().GetAll();
        }
        public static Member Save(Member member, EntityState state)
        {
            if (state == EntityState.Added)
                member.ssn = _container.Resolve<IMemberRepository>().Insert(member);
            else
                _container.Resolve<IMemberRepository>().Update(member);
            return member;
        }
    }
}
