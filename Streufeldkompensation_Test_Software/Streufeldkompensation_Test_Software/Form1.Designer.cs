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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 291);
            this.Controls.Add(this.bt_ClosePort);
            this.Controls.Add(this.bt_OpenPort);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_Ports);
            this.Name = "Form1";
            this.Text = "Streufeldkompensation Test Software";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_Ports;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_OpenPort;
        private System.Windows.Forms.Button bt_ClosePort;
    }
}

