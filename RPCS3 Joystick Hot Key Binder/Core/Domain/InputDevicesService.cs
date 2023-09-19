using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SharpDX.DirectInput;
using SharpDX.XInput;


namespace EmulatorsJoystickHotKeyBinder.Core.Domain
{


    public delegate Task ExitOnPressDelegate();

    public class InputDevicesService : BackgroundService
    {


        IServiceProvider ServiceProvider { get; set; }
        private List<Controller> Controllers = new List<Controller>();

        public InputDevicesService(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        private List<Controller> GetControllerList()
        {
            var directInput = new DirectInput();
            var devices = directInput.GetDevices().DistinctBy(dev => dev.ProductGuid.ToString()).ToList();

            Controllers = new List<Controller>() { new Controller(UserIndex.One), new Controller(UserIndex.Two), new Controller(UserIndex.Three), new Controller(UserIndex.Four) };

            return Controllers;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {



            var scope = ServiceProvider.CreateScope();

            IEmulatorService EmulatorService = (IEmulatorService)scope.ServiceProvider.GetService(typeof(IEmulatorService));

            Task.Factory.StartNew(() => EmulatorService.WatchProcess(stoppingToken));

            while (!stoppingToken.IsCancellationRequested)
            {
                Controllers = GetControllerList();
                bool hasAnyConected = Controllers.Any(ctrl => ctrl.IsConnected);

                if (hasAnyConected)
                    foreach (var selectControler in Controllers)
                    {


                        if (selectControler.IsConnected)
                        {

                            try
                            {
                                var previousState = selectControler.GetState();

                                var state = selectControler.GetState();
                                if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Back) && state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.B))
                                    EmulatorService.Stop();

                                previousState = state;
                            }
                            catch (Exception ex)
                            {

                            }



                        }

                    }


                Thread.Sleep(100);




            }
        }
    }
}
