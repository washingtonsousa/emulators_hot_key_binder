using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EmulatorsJoystickHotKeyBinder.Core.Domain;
using System.Diagnostics;
using System.Threading;
using Microsoft.Extensions.Configuration;
using EmulatorsJoystickHotKeyBinder.Core.Kernel.Builders;

namespace EmulatorsJoystickHotKeyBinder
{
    internal static class Program
    {


        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

           

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            StartupWindowHandleFacade.HandleStart(() =>
            {


                var form = new Form1();

                var hb = CreateHostBuilder();

                var host = hb.Build();

                Task.Factory.StartNew(() =>
                {

                    host.Run();

                });


                form.FormClosed += (object? sender, FormClosedEventArgs e) =>
                {
                    host.StopAsync();

                };

                Application.Run(form);


            });



        }


        private static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {

                    var settings = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                      .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();
                    services.AddSingleton<IConfiguration>(settings);

                    services.AddSingleton<IEmulatorService, EmulatorService>();
                    services.AddHostedService<InputDevicesService>();
                  
                });
        }
    }
}