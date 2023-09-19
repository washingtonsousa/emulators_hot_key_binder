using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EmulatorsJoystickHotKeyBinder.Core.Domain;
using System.Diagnostics;
using System.Threading;


namespace EmulatorsJoystickHotKeyBinder
{
    internal static class Program
    {


        private static System.Threading.Timer Tmr;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            



            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();



         

            Form mbx = new Form();
            Label LblMessage = new Label();

            mbx.Size = new System.Drawing.Size(308, 185);
            mbx.MaximizeBox = false;
            mbx.MinimizeBox = false;
            mbx.ShowIcon = false;
            mbx.ShowInTaskbar = false;
            mbx.ControlBox = false;
            mbx.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            mbx.FormBorderStyle = FormBorderStyle.None;
            mbx.StartPosition = FormStartPosition.CenterScreen;

            //
            //LblMessage
            //
            LblMessage.Location = new System.Drawing.Point(12, 23);
            LblMessage.AutoSize = false;
            LblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            LblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            LblMessage.BorderStyle = BorderStyle.FixedSingle;
            LblMessage.Text = "There's already other instance running, this window will be closed.";
            LblMessage.Dock = DockStyle.Fill;

            mbx.Controls.Add(LblMessage);

            var hasMoreThanOne = Process.GetProcesses().Where(e => e.ProcessName.Contains("EmulatorsJoystickHotKeyBinder")).Count() > 1;

            if (hasMoreThanOne)
            {

                Tmr = new System.Threading.Timer(new System.Threading.TimerCallback(Tmr_Tick), mbx, 3000, 0);
                mbx.ShowDialog();




                return;

            }
            else
            {
                var hb = CreateHostBuilder();

                var host = hb.Build();

                host.Run();

                Application.Run(new Form1());

               

            }

        }

        private static void Tmr_Tick(object obj)
        {
            Tmr.Dispose();
            if (obj is Form)
            {
                if (((Form)obj).InvokeRequired)
                {
                    ((Form)obj).Invoke(new System.Action<Form>(InvokeMbx), new object[] { ((Form)obj) });
                }
                else InvokeMbx((Form)obj);
            }
        }
        private static void InvokeMbx(Form mbx)
        {
            mbx.Close();
        }


        private static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    services.AddSingleton<IEmulatorService>(new EmulatorService());

                    services.AddHostedService<InputDevicesService>();
                });
        }
    }
}