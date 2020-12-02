using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO.Ports;


namespace Streufeldkompensation_Test_Software
{
    public partial class Form1 : Form
    {
        
        SerialPort sport = new SerialPort();

        bool connected = false;

        public Form1()//init Form
        {
            InitializeComponent();
            l_version.Text = "Version: 2";//Flag for version
            CheckForIllegalCrossThreadCalls = false;//pragma deactivate
            textbox.ForeColor = Color.Black;
            foreach (String s in SerialPort.GetPortNames())//listing Port names
            {
                cb_Ports.Items.Add(s);
            }
            
        }


        private void bt_OpenPort_Click(object sender, EventArgs e)//connect to a COM port
        {
            if (connected == false)
            {
                String port = cb_Ports.Text;
                try
                {
                    sport = new SerialPort(port, 9600, Parity.None, 8, StopBits.One);//new Serial port
                    sport.Open();
                    if (sport.IsOpen)//check if is already open
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
                catch (Exception)//check for errors
                {
                    textbox.Text += "No Port is Selected\r\n"; 
                    textbox.SelectionStart = textbox.Text.Length;
                    textbox.ScrollToCaret();
                }

            }
        }

        private void sport_DataReceived(object sender, SerialDataReceivedEventArgs e)//Interuptrutine for receiving data
        {
            string data = "";

            while (sport.BytesToRead > 0)//ready data
            {
                data = sport.ReadExisting();
                data = data.Replace("\0", string.Empty);
                textbox.Text += data;//add to text box
                textbox.SelectionStart = textbox.Text.Length;
                textbox.ScrollToCaret();
            }
            this.WindowState = FormWindowState.Normal;
        }

        private void bt_ClosePort_Click(object sender, EventArgs e)//close connection to COM Port
        {
            if(sport.IsOpen)//check if is alreasy open
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

        private void rb_10V_CheckedChanged(object sender, EventArgs e)//limitate the range
        {
            nUD_V.Maximum = 10;
            nUD_V.Minimum = -10;
        }

        private void rb_1V_CheckedChanged(object sender, EventArgs e)//limitate the range
        {
            nUD_V.Maximum = 1;
            nUD_V.Minimum = -1;
        }

        private void bt_send_Click(object sender, EventArgs e)//Send Button click event
        {
            float voltage = (float)nUD_V.Value;
            int output = 0;
            if (rb_1V.Checked == true)
            {output = 1;}
            else
            {output = 10;}
            
            if (sport.IsOpen)
            {
                sport.Write("SET_CH" + nUD_CH.Value.ToString() + "_" + voltage.ToString() + "_OUT" + output.ToString() + "\r");//sending to serial Port
            }
            else
            {
                textbox.Text += "Not Connected\r\n";
                textbox.SelectionStart = textbox.Text.Length;
                textbox.ScrollToCaret();
            }
        }

        private void button1_Click(object sender, EventArgs e)//button help 
        {
            if (sport.IsOpen)
            {
                sport.Write("Help_\r");//sending Help
            }
            else
            {
                textbox.Text += "Please Connect First\r\n";
                textbox.SelectionStart = textbox.Text.Length;
                textbox.ScrollToCaret();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)//Hyper link
        {
            System.Diagnostics.Process.Start(linkLabel1.Text);
        }
    }
}
