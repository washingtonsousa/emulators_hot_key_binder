namespace EmulatorsJoystickHotKeyBinder
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 25);
            button1.Name = "button1";
            button1.Size = new Size(143, 62);
            button1.TabIndex = 5;
            button1.Text = "Close Command";
            button1.UseVisualStyleBackColor = true;
            button1.Click += CloseEmulator;
            // 
            // button2
            // 
            button2.Enabled = false;
            button2.Location = new Point(175, 25);
            button2.Name = "button2";
            button2.Size = new Size(153, 62);
            button2.TabIndex = 6;
            button2.Text = "Exit Fullscreen Mode";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Enabled = false;
            button3.Location = new Point(344, 25);
            button3.Name = "button3";
            button3.Size = new Size(150, 62);
            button3.TabIndex = 7;
            button3.Text = "Exit Game";
            button3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(506, 102);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Hot Key Binder UI";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion
        private Label lblPID;
        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}