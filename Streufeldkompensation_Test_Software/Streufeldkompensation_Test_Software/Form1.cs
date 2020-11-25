using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management; // need to add System.Management to your project references.
using System.IO.Ports;


namespace Streufeldkompensation_Test_Software
{
    public partial class Form1 : Form
    {
        SerialPort sport = new SerialPort();

        bool connected = false;

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            textbox.ForeColor = Color.Black;
            foreach (String s in SerialPort.GetPortNames())
            {
                cb_Ports.Items.Add(s);
            }
            
        }


        private void bt_OpenPort_Click(object sender, EventArgs e)
        {
            if (connected == false)
            {
                String port = cb_Ports.Text;
                try
                {
                    sport = new SerialPort(port, 9600, Parity.None, 8, StopBits.One);
                    sport.Open();
                    if (sport.IsOpen)
                    {
                        connected = true;
                        bt_ClosePort.Visible = true;
                        bt_OpenPort.Visible = false;
                        sport.DataReceived += new SerialDataReceivedEventHandler(sport_DataReceived);
                        textbox.Text += "Connected\r\n";
                        textbox.SelectionStart = textbox.Text.Length;
                        textbox.ScrollToCaret();
                    }
                }
                catch (Exception)
                {
                    textbox.Text += "No Port is Selected\r\n"; 
                    textbox.SelectionStart = textbox.Text.Length;
                    textbox.ScrollToCaret();
                }

            }
        }

        private void sport_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string data = "";

            while (sport.BytesToRead > 0)
            {
                data = sport.ReadExisting();
                data = data.Replace("\0", string.Empty);
                textbox.Text += data;
                textbox.SelectionStart = textbox.Text.Length;
                textbox.ScrollToCaret();
            }
            this.WindowState = FormWindowState.Normal;
        }

        private void bt_ClosePort_Click(object sender, EventArgs e)
        {
            if(sport.IsOpen)
            {
                sport.Close();
                connected = false;
                bt_ClosePort.Visible = false;
                bt_OpenPort.Visible = true;
                textbox.Text += "Disconnected\r\n";
                textbox.SelectionStart = textbox.Text.Length;
                textbox.ScrollToCaret();
            }
        }

        private void rb_10V_CheckedChanged(object sender, EventArgs e)
        {
            nUD_V.Maximum = 10;
            nUD_V.Minimum = -10;
        }

        private void rb_1V_CheckedChanged(object sender, EventArgs e)
        {
            nUD_V.Maximum = 1;
            nUD_V.Minimum = -1;
        }

        private void bt_send_Click(object sender, EventArgs e)
        {
            float voltage = (float)nUD_V.Value;
            int output = 0;
            if (rb_1V.Checked == true)
            {output = 1;}
            else
            {output = 10;}
            
            if (sport.IsOpen)
            {
                sport.Write("SET=CH" + nUD_CH.Value.ToString() + "=" + voltage.ToString() + "=OUT" + output.ToString() + "\r");
            }
            else
            {
                textbox.Text += "Not Connected\r\n";
                textbox.SelectionStart = textbox.Text.Length;
                textbox.ScrollToCaret();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (sport.IsOpen)
            {
                sport.Write("Help=\r");
            }
            else
            {
                textbox.Text += "Please Connect First\r\n";
                textbox.SelectionStart = textbox.Text.Length;
                textbox.ScrollToCaret();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkLabel1.Text);
        }
    }
}
