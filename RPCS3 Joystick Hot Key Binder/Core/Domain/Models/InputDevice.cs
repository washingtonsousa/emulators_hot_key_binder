using SharpDX.DirectInput;
using SharpDX.XInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmulatorsJoystickHotKeyBinder.Core.Domain.Models
{
    public class InputDevice
    {
        public InputDevice(string name, string id, string type, Joystick joystick)
        {
            Name = name;
            Id = id;
            Type = type;
            Joystick = joystick;
        }

        public InputDevice(string name, string id, string type, Controller xboxController)
        {
            Name = name;
            Id = id;
            Type = type;
            XboxController = xboxController;
        }

        public string Name { get; set; }

        public string Id { get; set; }

        public string Type { get; set; }

       

        public Controller XboxController { get; set; }
        public Joystick Joystick { get; set; }

        public override string ToString()
        {
            return Name;
        }

    }
}
