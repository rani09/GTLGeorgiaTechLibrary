using NLog;
using System;

namespace InfrastructureLayer.Common
{
    public class ApplicationBase
    {
        protected Logger Log { get; private set; }

        protected ApplicationBase(Type declaringType)
        {
            Log = LogManager.GetLogger(declaringType.FullName);

        }
    }
}
