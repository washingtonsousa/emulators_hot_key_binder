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

        Task Start();
        Task Stop();
        Task WatchProcess();
    }

    public class EmulatorService : IEmulatorService
    {
        public Process[] Processes { get; private set; }


        public async Task  WatchProcess()
        {

            while (true)
            {
                var allProcess = Process.GetProcesses();
                Processes = Process.GetProcesses().Where(e => e.ProcessName.Contains("rpcs3") || e.ProcessName.Contains("yuzu") || e.ProcessName.Contains("Dolphin")).ToArray();
            }

        }

        public async Task Start() {

            try
            {
                

                Task.Run(() => WatchProcess());


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);


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
