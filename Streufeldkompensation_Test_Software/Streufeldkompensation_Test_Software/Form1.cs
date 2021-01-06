using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO.Ports;


namespace Streufeldkompensation_Test_Software
{
    public partial class Form1 : Form
    {
        SerialPort sport = new SerialPort();//New class as Serialport

        bool connected = false;

        public Form1()//init Form
        {
            InitializeComponent();
            l_version.Text = "Version: 3";//Flag for version
            CheckForIllegalCrossThreadCalls = false;//pragma deactivate
            textbox.ForeColor = Color.Black;//set Text Color to Black
            foreach (String s in SerialPort.GetPortNames())//listing Port names
            {
                cb_Ports.Items.Add(s);//adding Ports to combobox
            }

        }

        private void adding_text_to_textbox(String input)//Funtion for adding text to the end of the text box
        {
            textbox.Text += input;//adding the input
            textbox.Text += "\r\n";//adding Carriage Return and Line Feed ( Used as a new line character in Windows)
            textbox.SelectionStart = textbox.Text.Length;//dynamic size
            textbox.ScrollToCaret();//scroll to the end
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
                        bt_ClosePort.Visible = true;//Button Close Port set visible
                        bt_OpenPort.Visible = false;//Button Open Port set invisible
                        sport.DataReceived += new SerialDataReceivedEventHandler(sport_DataReceived);//adding a Data receive handler
                        adding_text_to_textbox("Connected");//Text output for the textbox
                    }
                }
                catch (Exception ex)//check for errors
                {MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);}

            }
        }

        private void sport_DataReceived(object sender, SerialDataReceivedEventArgs e)//Interuptrutine for receiving data
        {
            string data = "";
            try
            {
                while (sport.BytesToRead > 0)//ready data
                {
                    data = sport.ReadExisting();//Read until end
                    data = data.Replace("\0", string.Empty);//Take all
                    textbox.Text += data;//add to text box
                    textbox.SelectionStart = textbox.Text.Length;//dynamic size
                    textbox.ScrollToCaret();//scroll to the end
                }
            }
            catch (Exception ex)//check for errors
            { MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            this.WindowState = FormWindowState.Normal;
         }

        private void bt_ClosePort_Click(object sender, EventArgs e)//close connection to COM Port
        {
            try
            {
                if (sport.IsOpen)//check if is alreasy open
                {
                    sport.Close();//Close it
                    connected = false;//delete Flag 
                    bt_ClosePort.Visible = false;//Button Close Port set invisible
                    bt_OpenPort.Visible = true;//Button Open Port set visible
                    adding_text_to_textbox("Disconnected");//Text output for the textbox
                }
            }
            catch (Exception ex)//check for errors
            { MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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
            double voltage = (double)nUD_V.Value;
            //Check if input is valid
            int output = 0;
            if (rb_1V.Checked == true){output = 1;}
            else{output = 10;}

            try
            {
                //Send data
                if (sport.IsOpen)
                {
                    sport.Write("SET_CH" + nUD_CH.Value.ToString() + "_" + voltage.ToString() + "_OUT" + output.ToString() + "\r");//sending to serial Port
                }
                else
                {
                    adding_text_to_textbox("Not Connected");//Text output for the textbox
                }
            }
            catch (Exception ex)//check for errors
            { MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void b_help_Click(object sender, EventArgs e)//button help 
        {
            try
            {
                if (sport.IsOpen)//Check if Port is Open
                {
                    sport.Write("Help_\r");//sending Help
                }
                else
                {
                    adding_text_to_textbox("Please Connect First");//Text output for the textbox
                }
            }
            catch (Exception ex)//check for errors
            { MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)//Hyper link
        {
            try
            {
                System.Diagnostics.Process.Start(linkLabel1.Text);//Open Brower with the hyperlink
            }
            catch (Exception ex)//check for errors
            { MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void bt_refresh_Click(object sender, EventArgs e)//Refresh Button
        {
            cb_Ports.Items.Clear();//Deleting old Items from Combobox
            foreach (String s in SerialPort.GetPortNames())//listing Port names
            {
                cb_Ports.Items.Add(s);//adding Ports to combobox
            }
        }

        private void nUD_V_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)//Check if Button Enter on a Keyboard is press do same as Send
            {
                double voltage = (double)nUD_V.Value;
                //Check if input is valid
                int output = 0;
                if (rb_1V.Checked == true) { output = 1; }
                else { output = 10; }

                try
                {
                    //Send data
                    if (sport.IsOpen)
                    {
                        sport.Write("SET_CH" + nUD_CH.Value.ToString() + "_" + voltage.ToString() + "_OUT" + output.ToString() + "\r");//sending to serial Port
                    }
                    else
                    {
                        adding_text_to_textbox("Not Connected");//Text output for the textbox
                    }
                }
                catch (Exception ex)//check for errors
                { MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }
    }
}
