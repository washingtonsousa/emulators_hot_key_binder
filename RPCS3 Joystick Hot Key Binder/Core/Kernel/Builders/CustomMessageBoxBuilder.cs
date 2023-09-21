using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmulatorsJoystickHotKeyBinder.Core.Kernel.Builders
{
    public interface ICustomMessageBoxBuilder
    {
        public Form Form { get; }

        Form Build();

        void SetLabelMessage(string message);
    }
    public class CustomMessageBoxBuilder : ICustomMessageBoxBuilder
    {
        public Form Form { get; private set; }

         private Label _lblMessage;

        public CustomMessageBoxBuilder()
        {
            Form = new Form();
            _lblMessage = new Label();
        }

        public void SetLabelMessage(string message)
        {
            _lblMessage.Text = message; // "There's already other instance running, this window will be closed.";

        }

        public Form Build()
        {

            Form.Size = new System.Drawing.Size(308, 185);
            Form.MaximizeBox = false;
            Form.MinimizeBox = false;
            Form.ShowIcon = false;
            Form.ShowInTaskbar = false;
            Form.ControlBox = false;
            Form.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            Form.FormBorderStyle = FormBorderStyle.None;
            Form.StartPosition = FormStartPosition.CenterScreen;

            //
            //LblMessage
            //
            _lblMessage.Location = new System.Drawing.Point(12, 23);
            _lblMessage.AutoSize = false;
            _lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            _lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            _lblMessage.BorderStyle = BorderStyle.FixedSingle;
            _lblMessage.Text = "There's already other instance running, this window will be closed.";
            _lblMessage.Dock = DockStyle.Fill;

            Form.Controls.Add(_lblMessage);

            return Form;
        }
    }
}
