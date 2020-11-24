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


namespace Streufeldkompensation_Test_Software
{
    public partial class Form1 : Form
    {
        public System.IO.Ports.SerialPort sport;
        bool connected = false;

        public Form1()
        {
            InitializeComponent();
            foreach (String s in System.IO.Ports.SerialPort.GetPortNames())
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
                    sport = new System.IO.Ports.SerialPort(
                    port, 9600, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);
                    sport.Open();
                    if (sport.IsOpen)
                    {
                        connected = true;
                        bt_ClosePort.Visible = true;
                        bt_OpenPort.Visible = false;
                    }
                }
                catch (Exception ex) { MessageBox.Show("No Port is Selected"); }
                
                
            }
        }

        private void bt_ClosePort_Click(object sender, EventArgs e)
        {
            if(sport.IsOpen)
            {
                sport.Close();
                connected = false;
                bt_ClosePort.Visible = false;
                bt_OpenPort.Visible = true;
            }
        }
    }
}
