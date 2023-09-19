using Microsoft.Extensions.DependencyInjection;
using EmulatorsJoystickHotKeyBinder.Core.Domain;
using EmulatorsJoystickHotKeyBinder.Core.Domain.Models;
using System;
using System.ServiceProcess;

namespace EmulatorsJoystickHotKeyBinder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            ServiceCollection services = new ServiceCollection();

            services.AddSingleton<IEmulatorService>(new EmulatorService());

            _serviceProvider = services.BuildServiceProvider();

            _emulatorService = _serviceProvider.GetService<IEmulatorService>();

        }

        IEmulatorService _emulatorService;
        IServiceProvider _serviceProvider;


        private void CloseEmulator(object sender, EventArgs e)
        {
            _emulatorService = _serviceProvider.GetService<IEmulatorService>();

            _emulatorService.Stop();
        }

        private void Form1_Load(object sender, EventArgs e)
        {



        }
    }
}