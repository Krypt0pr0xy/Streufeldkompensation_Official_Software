namespace Streufeldkompensation_Test_Software
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.cb_Ports = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_OpenPort = new System.Windows.Forms.Button();
            this.bt_ClosePort = new System.Windows.Forms.Button();
            this.textbox = new System.Windows.Forms.TextBox();
            this.nUD_CH = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.rb_1V = new System.Windows.Forms.RadioButton();
            this.rb_10V = new System.Windows.Forms.RadioButton();
            this.bt_send = new System.Windows.Forms.Button();
            this.nUD_V = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_CH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_V)).BeginInit();
            this.SuspendLayout();
            // 
            // cb_Ports
            // 
            this.cb_Ports.FormattingEnabled = true;
            this.cb_Ports.Location = new System.Drawing.Point(31, 40);
            this.cb_Ports.Name = "cb_Ports";
            this.cb_Ports.Size = new System.Drawing.Size(119, 21);
            this.cb_Ports.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select Port:";
            // 
            // bt_OpenPort
            // 
            this.bt_OpenPort.Location = new System.Drawing.Point(156, 38);
            this.bt_OpenPort.Name = "bt_OpenPort";
            this.bt_OpenPort.Size = new System.Drawing.Size(75, 23);
            this.bt_OpenPort.TabIndex = 2;
            this.bt_OpenPort.Text = "Open Port";
            this.bt_OpenPort.UseVisualStyleBackColor = true;
            this.bt_OpenPort.Click += new System.EventHandler(this.bt_OpenPort_Click);
            // 
            // bt_ClosePort
            // 
            this.bt_ClosePort.Location = new System.Drawing.Point(156, 38);
            this.bt_ClosePort.Name = "bt_ClosePort";
            this.bt_ClosePort.Size = new System.Drawing.Size(75, 23);
            this.bt_ClosePort.TabIndex = 3;
            this.bt_ClosePort.Text = "Close Port";
            this.bt_ClosePort.UseVisualStyleBackColor = true;
            this.bt_ClosePort.Visible = false;
            this.bt_ClosePort.Click += new System.EventHandler(this.bt_ClosePort_Click);
            // 
            // textbox
            // 
            this.textbox.BackColor = System.Drawing.SystemColors.Window;
            this.textbox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textbox.Location = new System.Drawing.Point(31, 135);
            this.textbox.Multiline = true;
            this.textbox.Name = "textbox";
            this.textbox.ReadOnly = true;
            this.textbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textbox.Size = new System.Drawing.Size(331, 141);
            this.textbox.TabIndex = 21;
            // 
            // nUD_CH
            // 
            this.nUD_CH.Location = new System.Drawing.Point(59, 84);
            this.nUD_CH.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nUD_CH.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUD_CH.Name = "nUD_CH";
            this.nUD_CH.Size = new System.Drawing.Size(37, 20);
            this.nUD_CH.TabIndex = 22;
            this.nUD_CH.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "CH:";
            // 
            // rb_1V
            // 
            this.rb_1V.AutoSize = true;
            this.rb_1V.Checked = true;
            this.rb_1V.Location = new System.Drawing.Point(117, 73);
            this.rb_1V.Name = "rb_1V";
            this.rb_1V.Size = new System.Drawing.Size(55, 17);
            this.rb_1V.TabIndex = 24;
            this.rb_1V.TabStop = true;
            this.rb_1V.Text = "+/- 1V";
            this.rb_1V.UseVisualStyleBackColor = true;
            this.rb_1V.CheckedChanged += new System.EventHandler(this.rb_1V_CheckedChanged);
            // 
            // rb_10V
            // 
            this.rb_10V.AutoSize = true;
            this.rb_10V.Location = new System.Drawing.Point(117, 96);
            this.rb_10V.Name = "rb_10V";
            this.rb_10V.Size = new System.Drawing.Size(61, 17);
            this.rb_10V.TabIndex = 25;
            this.rb_10V.Text = "+/- 10V";
            this.rb_10V.UseVisualStyleBackColor = true;
            this.rb_10V.CheckedChanged += new System.EventHandler(this.rb_10V_CheckedChanged);
            // 
            // bt_send
            // 
            this.bt_send.Location = new System.Drawing.Point(287, 73);
            this.bt_send.Name = "bt_send";
            this.bt_send.Size = new System.Drawing.Size(75, 42);
            this.bt_send.TabIndex = 26;
            this.bt_send.Text = "Send";
            this.bt_send.UseVisualStyleBackColor = true;
            this.bt_send.Click += new System.EventHandler(this.bt_send_Click);
            // 
            // nUD_V
            // 
            this.nUD_V.DecimalPlaces = 5;
            this.nUD_V.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nUD_V.Location = new System.Drawing.Point(195, 84);
            this.nUD_V.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUD_V.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nUD_V.Name = "nUD_V";
            this.nUD_V.Size = new System.Drawing.Size(66, 20);
            this.nUD_V.TabIndex = 27;
            this.nUD_V.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(267, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "V";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(383, 293);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nUD_V);
            this.Controls.Add(this.bt_send);
            this.Controls.Add(this.rb_10V);
            this.Controls.Add(this.rb_1V);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nUD_CH);
            this.Controls.Add(this.textbox);
            this.Controls.Add(this.bt_ClosePort);
            this.Controls.Add(this.bt_OpenPort);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_Ports);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Streufeldkompensation Test Software";
            ((System.ComponentModel.ISupportInitialize)(this.nUD_CH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_V)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_Ports;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_OpenPort;
        private System.Windows.Forms.Button bt_ClosePort;
        private System.Windows.Forms.TextBox textbox;
        private System.Windows.Forms.NumericUpDown nUD_CH;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rb_1V;
        private System.Windows.Forms.RadioButton rb_10V;
        private System.Windows.Forms.Button bt_send;
        private System.Windows.Forms.NumericUpDown nUD_V;
        private System.Windows.Forms.Label label3;
    }
}

