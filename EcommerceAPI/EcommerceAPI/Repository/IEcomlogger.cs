using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAPI.Repository
{
    public interface IEcomlogger
    {
        void LogInfo(string message);
        void LogWarn(string message);
        void LogError(string message);
        void LogDebug(string message);
    }
}
