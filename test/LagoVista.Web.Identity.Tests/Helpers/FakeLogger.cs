using LagoVista.Common.PlatformSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceManagementRepo.Tests.Helpers
{
    public class FakeLogger : ILogger
    {
        public void Log(LogLevel level, string area, string message, params KeyValuePair<string, string>[] args)
        {

        }

        public void LogException(string area, Exception ex, params KeyValuePair<string, string>[] args)
        {

        }

        public void SetKeys(params string[] args)
        {

        }

        public void SetUserId(string userId)
        {

        }

        public void TrackEvent(string message, Dictionary<string, string> parameters)
        {

        }
    }

}
