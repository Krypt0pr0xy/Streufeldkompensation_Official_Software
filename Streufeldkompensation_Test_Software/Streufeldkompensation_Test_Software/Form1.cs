using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;

namespace Streufeldkompensation_Test_Software
{
    public partial class Form1 : Form
    {
        SerialPort sport = new SerialPort();//New class as Serialport

        bool connected = false;
        int panelWidth;
        bool Hidden;

        public Form1()//init Form
        {
            InitializeComponent();
            l_version.Text = "Version: 5";//Flag for version
            CheckForIllegalCrossThreadCalls = false;//pragma deactivate
            textbox.ForeColor = Color.Black;//set Text Color to Black
            foreach (String s in SerialPort.GetPortNames())//listing Port names
            {
                cb_Ports.Items.Add(s);//adding Ports to combobox
            }
            panelWidth = panel_slider.Width;
            Hidden = true;

            while(panel_slider.Width >= 30)
            {
                panel_slider.Width = panel_slider.Width - 10;
                this.Width -= 10;
                this.Refresh();
            }

            pb_Button1_OFF.Visible = false;
            pb_Button1_ON.Visible = false;
            pb_Button2_OFF.Visible = false;
            pb_Button2_ON.Visible = false;
            pb_Button3_OFF.Visible = false;
            pb_Button3_ON.Visible = false;
            pb_Button4_OFF.Visible = false;
            pb_Button4_ON.Visible = false;


            pb_Button1_Output.Visible = false;
            pb_Button2_Output.Visible = false;
            pb_Button3_Output.Visible = false;
            pb_Button4_Output.Visible = false;

        }

        private void delay_ms(int time_ms)
        {
            Cursor.Current = Cursors.WaitCursor;
            Thread.Sleep(time_ms);   //wait for spesific time
            Cursor.Current = Cursors.Arrow;
            //Cursor.Position = new Point(Cursor.Position.X + 1, Cursor.Position.Y);
            //Cursor.Position = new Point(Cursor.Position.X - 1, Cursor.Position.Y);
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
                    //data = sport.ReadExisting();//Read until end
                    data = sport.ReadLine();//Read until end
                    data += "\n";
                    data = data.Replace("\0", string.Empty);//Take all

                    if (data == "P28=OFF\r\n") { pb1_ON.Visible = false; pb1_OFF.Visible = true; }
                    if (data == "P28=ON\r\n") { pb1_ON.Visible = true; pb1_OFF.Visible = false; }

                    if (data == "P29=OFF\r\n") { pb2_ON.Visible = false; pb2_OFF.Visible = true; }
                    if (data == "P29=ON\r\n") { pb2_ON.Visible = true; pb2_OFF.Visible = false; }

                    if (data == "P30=OFF\r\n") { pb3_ON.Visible = false; pb3_OFF.Visible = true; }
                    if (data == "P30=ON\r\n") { pb3_ON.Visible = true; pb3_OFF.Visible = false; }

                    if (data == "P31=OFF\r\n") { pb4_ON.Visible = false; pb4_OFF.Visible = true; }
                    if (data == "P31=ON\r\n") { pb4_ON.Visible = true; pb4_OFF.Visible = false; }
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
            double offsetvoltage = (double)nUD_offset.Value;
            voltage += (offsetvoltage / 1000);
            //Check if input is valid
            int output = 0;
            if (rb_1V.Checked == true){output = 1;}
            else{output = 10;}

            try
            {
                //Send data
                if (sport.IsOpen)
                {
                    sport.Write("SET_CH" + nUD_CH.Value.ToString() + "_" + voltage.ToString("F99").TrimEnd('0') + "_OUT" + output.ToString() + "\r");//sending to serial Port without scientific spelling 
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
                        sport.Write("SET_CH" + nUD_CH.Value.ToString() + "_" + voltage.ToString("F99").TrimEnd('0') + "_OUT" + output.ToString() + "\r");//sending to serial Port without scientific spelling 
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

        private void nUD_offset_ValueChanged(object sender, EventArgs e)
        {
            check_voltage_offset();
        }

        private void nUD_V_ValueChanged(object sender, EventArgs e)
        {
            check_voltage_offset();
        }

        private void check_voltage_offset()
        {
            if (rb_1V.Checked == true)//check if is 1V setting 
            {
                while ((nUD_V.Value + (nUD_offset.Value / 1000)) > 1)//decreas offset value for total max voltage
                {
                    nUD_offset.Value -= 1;
                }

                while ((nUD_V.Value + (nUD_offset.Value / 1000)) < -1)//decreas offset value for total max voltage
                {
                    nUD_offset.Value += 1;
                }
            }
            else
            {
                while ((nUD_V.Value + (nUD_offset.Value / 1000)) > 10)//decreas offset value for total max voltage
                {
                    nUD_offset.Value -= 1;
                }

                while ((nUD_V.Value + (nUD_offset.Value / 1000)) < -10)//decreas offset value for total max voltage
                {
                    nUD_offset.Value += 1;
                }
            }
        }

        private void button_slide_Click(object sender, EventArgs e)
        {
            timer_slider.Start();//start Timer for slider every 1ms
            timer_input_checker.Start();//start Timer for Input every 10 sec
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Hidden)//check if flag Hidden is set
            {
                panel_slider.Width = panel_slider.Width + 5;//Move panel
                this.Width += 5;//Move main panel
                if (panel_slider.Width >= 400)//check if panel is bigger than main panel with
                {
                    timer_slider.Stop();//stop Timer
                    button_slide.Text = "<";//change Text of button
                    Hidden = false;//set to Hidden false
                    this.Refresh();//Refresh if  it is'nt
                }
            }
            else
            {
                panel_slider.Width = panel_slider.Width - 5;//Move panel
                this.Width -= 5;//Move main panel
                if (panel_slider.Width <= 0)//check if panel is smaller than zero main panel with
                {
                    this.Width = 500;
                    timer_slider.Stop();//stop Timer
                    button_slide.Text = ">";//change Text of button
                    Hidden = true;//set to Hidden true
                    this.Refresh();//Refresh if  it is'nt
                }
            }
        }


        //__________________________________________________________________
        private void pb_Button1_ON_Click(object sender, EventArgs e)
        {
            pb_Button1_OFF.Visible = true;
            pb_Button1_ON.Visible = false;
            try//Try to send PORTSET_28_LOW_\r
            {
                if (sport.IsOpen)//check if serial port is open
                { sport.Write("PORTSET_28_LOW_\r"); }
                else
                { adding_text_to_textbox("Not Connected"); }
            }
            catch (Exception ex)//check for errors
            { MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void pb_Button1_OFF_Click(object sender, EventArgs e)
        {
            pb_Button1_OFF.Visible = false;
            pb_Button1_ON.Visible = true;
            try//Try to send PORTSET_28_HIGH_\r
            {   if (sport.IsOpen)//check if serial port is open
                { sport.Write("PORTSET_28_HIGH_\r");}
                else
                {adding_text_to_textbox("Not Connected");}
            }catch (Exception ex)//check for errors
            { MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        //__________________________________________________________________
        private void pb_Button2_ON_Click(object sender, EventArgs e)
        {
            pb_Button2_OFF.Visible = true;
            pb_Button2_ON.Visible = false;
            try
            {
                if (sport.IsOpen)//check if serial port is open
                { sport.Write("PORTSET_29_LOW_\r"); }
                else
                { adding_text_to_textbox("Not Connected"); }
            }
            catch (Exception ex)//check for errors
            { MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void pb_Button2_OFF_Click(object sender, EventArgs e)
        {
            pb_Button2_OFF.Visible = false;
            pb_Button2_ON.Visible = true;
            try
            {
                if (sport.IsOpen)//check if serial port is open
                { sport.Write("PORTSET_29_HIGH_\r"); }
                else
                { adding_text_to_textbox("Not Connected"); }
            }
            catch (Exception ex)//check for errors
            { MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        //__________________________________________________________________
        private void pb_Button3_ON_Click(object sender, EventArgs e)
        {
            pb_Button3_OFF.Visible = true;
            pb_Button3_ON.Visible = false;
            try
            {
                if (sport.IsOpen)//check if serial port is open
                { sport.Write("PORTSET_30_LOW_\r"); }
                else
                { adding_text_to_textbox("Not Connected"); }
            }
            catch (Exception ex)//check for errors
            { MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void pb_Button3_OFF_Click(object sender, EventArgs e)
        {
            pb_Button3_OFF.Visible = false;
            pb_Button3_ON.Visible = true;
            try
            {
                if (sport.IsOpen)//check if serial port is open
                { sport.Write("PORTSET_30_HIGH_\r"); }
                else
                { adding_text_to_textbox("Not Connected"); }
            }
            catch (Exception ex)//check for errors
            { MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        //__________________________________________________________________
        private void pb_Button4_ON_Click(object sender, EventArgs e)
        {
            pb_Button4_OFF.Visible = true;
            pb_Button4_ON.Visible = false;
            try
            {
                if (sport.IsOpen)//check if serial port is open
                { sport.Write("PORTSET_31_LOW_\r"); }
                else
                { adding_text_to_textbox("Not Connected"); }
            }
            catch (Exception ex)//check for errors
            { MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void pb_Button4_OFF_Click(object sender, EventArgs e)
        {
            pb_Button4_OFF.Visible = false;
            pb_Button4_ON.Visible = true;
            try
            {
                if (sport.IsOpen)//check if serial port is open
                { sport.Write("PORTSET_31_HIGH_\r"); }
                else
                { adding_text_to_textbox("Not Connected"); }
            }
            catch (Exception ex)//check for errors
            { MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        //__________________________________________________________________





        private void pb_Button1_Input_Click(object sender, EventArgs e)
        {
            pb_Button1_Input.Visible = false;
            pb_Button1_Output.Visible = true;

            pb_Button1_ON.Visible = true;
            pb_Button1_OFF.Visible = true;

            pb1_OFF.Visible = false;
            pb1_ON.Visible = false;
        }

        private void pb_Button1_Output_Click(object sender, EventArgs e)
        {
            pb_Button1_Input.Visible = true;
            pb_Button1_Output.Visible = false;

            pb_Button1_ON.Visible = false;
            pb_Button1_OFF.Visible = false;

            pb1_OFF.Visible = true;
            pb1_ON.Visible = true;
        }

        private void pb_Button2_Input_Click(object sender, EventArgs e)
        {
            pb_Button2_Input.Visible = false;
            pb_Button2_Output.Visible = true;

            pb_Button2_ON.Visible = true;
            pb_Button2_OFF.Visible = true;

            pb2_OFF.Visible = false;
            pb2_ON.Visible = false;
        }

        private void pb_Button2_Output_Click(object sender, EventArgs e)
        {
            pb_Button2_Input.Visible = true;
            pb_Button2_Output.Visible = false;

            pb_Button2_ON.Visible = false;
            pb_Button2_OFF.Visible = false;

            pb2_OFF.Visible = true;
            pb2_ON.Visible = true;
        }

        private void pb_Button3_Input_Click(object sender, EventArgs e)
        {
            pb_Button3_Input.Visible = false;
            pb_Button3_Output.Visible = true;

            pb_Button3_ON.Visible = true;
            pb_Button3_OFF.Visible = true;

            pb3_OFF.Visible = false;
            pb3_ON.Visible = false;
        }

        private void pb_Button3_Output_Click(object sender, EventArgs e)
        {
            pb_Button3_Input.Visible = true;
            pb_Button3_Output.Visible = false;

            pb_Button3_ON.Visible = false;
            pb_Button3_OFF.Visible = false;

            pb3_OFF.Visible = true;
            pb3_ON.Visible = true;
        }

        private void pb_Button4_Input_Click(object sender, EventArgs e)
        {
            pb_Button4_Input.Visible = false;
            pb_Button4_Output.Visible = true;

            pb_Button4_ON.Visible = true;
            pb_Button4_OFF.Visible = true;

            pb4_OFF.Visible = false; 
            pb4_ON.Visible = false;
        }

        private void pb_Button4_Output_Click(object sender, EventArgs e)
        {
            pb_Button4_Input.Visible = true;
            pb_Button4_Output.Visible = false;

            pb_Button4_ON.Visible = false;
            pb_Button4_OFF.Visible = false;

            pb4_OFF.Visible = true; 
            pb4_ON.Visible = true;
        }

        private void pb_download_Click(object sender, EventArgs e)
        {
            progressBar_Download.Value = 0;
            try
            {
                if (sport.IsOpen)//Check if Port is Open
                {
                    if (pb_Button1_Input.Visible)
                    {
                        sport.Write("PORTCONFIGURE_WRITE_28_INPUT\r");
                        delay_ms(500);
                        progressBar_Download.Value = 25;
                    }
                    else
                    {
                        sport.Write("PORTCONFIGURE_WRITE_28_OUTPUT\r");
                        delay_ms(500);
                        progressBar_Download.Value = 25;
                    }
                    //_______________________________________________
                    if (pb_Button2_Input.Visible)
                    {
                        sport.Write("PORTCONFIGURE_WRITE_29_INPUT\r");
                        delay_ms(500);
                        progressBar_Download.Value = 50;
                    }
                    else
                    {
                        sport.Write("PORTCONFIGURE_WRITE_29_OUTPUT\r");
                        delay_ms(500);
                        progressBar_Download.Value = 50;
                    }
                    //_______________________________________________
                    if (pb_Button3_Input.Visible)
                    {
                        sport.Write("PORTCONFIGURE_WRITE_30_INPUT\r");
                        delay_ms(500);
                        progressBar_Download.Value = 75;
                    }
                    else
                    {
                        sport.Write("PORTCONFIGURE_WRITE_30_OUTPUT\r");
                        delay_ms(500);
                        progressBar_Download.Value = 75;
                    }
                    //_______________________________________________
                    if (pb_Button4_Input.Visible)
                    {
                        sport.Write("PORTCONFIGURE_WRITE_31_INPUT\r");
                        delay_ms(500);
                        progressBar_Download.Value = 100;
                    }
                    else
                    {
                        sport.Write("PORTCONFIGURE_WRITE_31_OUTPUT\r");
                        delay_ms(500);
                        progressBar_Download.Value = 100;
                    }

                    sport.Write("PORTCONFIGURE_SET_\r"); 
                    //_______________________________________________
                }
                else
                {
                    adding_text_to_textbox("Please Connect First");//Text output for the textbox
                }
            }
            catch (Exception ex)//check for errors
            { MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void timer_input_checker_Tick(object sender, EventArgs e)
        {
            try
            {
                if (sport.IsOpen)//check if serial port is open
                {
                    if (pb_Button1_Input.Visible == true)
                    {
                        sport.Write("PORTREAD_28_\r");
                        delay_ms(500);
                    }
                    if (pb_Button2_Input.Visible == true)
                    {
                        sport.Write("PORTREAD_29_\r");
                        delay_ms(500);
                    }
                    if (pb_Button3_Input.Visible == true)
                    {
                        sport.Write("PORTREAD_30_\r");
                        delay_ms(500);
                    }
                    if (pb_Button4_Input.Visible == true)
                    {
                        sport.Write("PORTREAD_31_\r");
                        delay_ms(500);
                    }
                }
            }
            catch (Exception ex)//check for errors
            { MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

    }
}
