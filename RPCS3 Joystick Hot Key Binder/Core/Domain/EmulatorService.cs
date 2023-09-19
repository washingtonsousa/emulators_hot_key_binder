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


        public async Task  WatchProcess(CancellationToken cancellationToken)
        {

            while (!cancellationToken.IsCancellationRequested)
            {
                var allProcess = Process.GetProcesses();
                Processes = Process.GetProcesses().Where(e => e.ProcessName.Contains("rpcs3") || e.ProcessName.Contains("yuzu") || e.ProcessName.Contains("Dolphin")).ToArray();

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
