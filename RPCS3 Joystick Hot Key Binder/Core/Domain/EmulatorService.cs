using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EmulatorsJoystickHotKeyBinder.Core.Domain
{
    public interface IEmulatorService
    {
        public Process[] Processes { get; }
        Task Stop();
        Task WatchProcess(CancellationToken stoppingToken);
    }

    public class EmulatorService : IEmulatorService
    {
        public Process[] Processes { get; private set; }

        public IConfiguration Configuration { get; private set; }

        public EmulatorService(IConfiguration? configuration)
        {
            Configuration = configuration;
        }


        public async Task  WatchProcess(CancellationToken cancellationToken)
        {
            IList<string> args = new List<string>();

            args  =  Configuration.GetSection("EmulatorsProcessNames").Get<IList<string>>();

            while (!cancellationToken.IsCancellationRequested)
            {
                var allProcess = Process.GetProcesses();
                Processes = Process.GetProcesses().Where(e => args.Any(proc =>  e.ProcessName.Contains(proc))).ToArray();

                Thread.Sleep(3000);

            }

        }

        public async Task Stop()
        {

            foreach (Process process in Processes)
            {
                process?.Kill();

            }
        }
    }
}
