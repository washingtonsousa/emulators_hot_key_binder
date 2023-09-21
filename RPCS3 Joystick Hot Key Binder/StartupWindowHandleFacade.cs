using EmulatorsJoystickHotKeyBinder.Core.Kernel.Builders;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmulatorsJoystickHotKeyBinder
{
    public static class StartupWindowHandleFacade
    {
        private static System.Threading.Timer Tmr;

        public static void HandleStart(Action onRun) {

            ICustomMessageBoxBuilder msgBuilder = new CustomMessageBoxBuilder();

            msgBuilder.SetLabelMessage("There's already other instance running, this window will be closed.");

            var mbx = msgBuilder.Build();

            var hasMoreThanOne = Process.GetProcesses().Where(e => e.ProcessName.Contains("EmulatorsJoystickHotKeyBinder")).Count() > 1;

            if (hasMoreThanOne)
            {

                Tmr = new System.Threading.Timer(new System.Threading.TimerCallback(Tmr_Tick), mbx, 3000, 0);
                mbx.ShowDialog();

                return;

            }
            else
            {

                onRun();
          
            }



        }

        public static void Tmr_Tick(object obj)
        {
            if (obj is Form)
            {
                if (((Form)obj).InvokeRequired)
                {
                    ((Form)obj).Invoke(new System.Action<Form>(InvokeMbx), new object[] { ((Form)obj) });
                }
                else InvokeMbx((Form)obj);
            }
        }
        public static void InvokeMbx(Form mbx)
        {
            mbx.Close();
        }
    }
}
