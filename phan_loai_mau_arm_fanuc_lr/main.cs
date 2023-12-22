using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;
using System.IO;
using System.IO.Ports;
using S7.Net;

namespace phan_loai_mau_arm_fanuc_lr
{
    public partial class main : Form
    {


        private FilterInfoCollection Camera;
        private VideoCaptureDevice Cam;
        private Bitmap bitmap;

        private SerialPort serialport = new SerialPort();

        private Plc plc;
        private double j1 =0.0 ;
        private double j2 = 0.0 ;
        private double j3 =0.0 ;
        private double j4 =0.0 ;
        private int j5 = 0 ;


        bool sttbangtai = false;

        bool sttcam = false;
        bool sttplc = false;
        public main()
        {
            InitializeComponent();
            Camera = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            Cam = new VideoCaptureDevice();
        }

        private void moevj5active_Click(object sender, EventArgs e)
        {

        }

        private void moevj5posi_Click(object sender, EventArgs e)
        {

        }

        private void control_jog_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void controljog_Load(object sender, EventArgs e)
        {
            foreach (FilterInfo Device in Camera)
            {
                cbcam.Items.Add(Device.Name);
            }

            string[] port = SerialPort.GetPortNames();
            cbcom.Items.AddRange(port);


            enableTab(tabControl1.TabPages[tabControl1.SelectedIndex = 1], true);

        }

        private void enableTab(TabPage tabPage, bool enable)
        {
            EnableControls(tabPage.Controls, enable);
        }

        private static void EnableControls(Control.ControlCollection ctls, bool enable)
        {
            foreach (Control ctl in ctls)
            {
                ctl.Enabled = enable;
                EnableControls(ctl.Controls, enable);
            }
        }
        private void Cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
         
            bitmap = (Bitmap)eventArgs.Frame.Clone();
            piccam.Image = bitmap;
                
        }



       

       
        private void hScrollBar5_Scroll(object sender, ScrollEventArgs e)
        {
            txtthanhkeoj1.Text = thanhkeoj1.Value.ToString();
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void thanhkeoj2_Scroll_1(object sender, ScrollEventArgs e)
        {
            txtthanhkeoj2.Text = thanhkeoj2.Value.ToString();
        }

        private void thanhkeoj3_Scroll_1(object sender, ScrollEventArgs e)
        {
            txtthanhkeoj3.Text = thanhkeoj3.Value.ToString();
        }

        private void thanhkeoj4_Scroll(object sender, ScrollEventArgs e)
        {
            txtthanhkeoj4.Text = thanhkeoj4.Value.ToString();
        }

        private void thanhkeoj5_Scroll(object sender, ScrollEventArgs e)
        {
            txtthanhkeoj5.Text = thanhkeoj5.Value.ToString();
        }

        private void btconnectcam_Click(object sender, EventArgs e)
        {
            if (cbcam.SelectedIndex < 0)
            {
                MessageBox.Show("Chưa chọn Camera!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (!Cam.IsRunning)
                {
                    Cam = new VideoCaptureDevice(Camera[cbcam.SelectedIndex].MonikerString);
                    Cam.NewFrame += Cam_NewFrame;
                    Cam.Start();
                    MessageBox.Show("Kết nối Camera thành công!", "Thông báo");
                    sttcam = true;
                    cbcam.Enabled = false;
                    if (sttplc == true)
                    {
                        enableTab(tabControl1.TabPages[tabControl1.SelectedIndex = 1], true);
                    }
                }
            }
        }

        private void btconnectplc_Click(object sender, EventArgs e)
        {
            
            plc = new Plc(CpuType.S71200, txtip.Text, 0, 0);
            plc.Open();
            if (plc.IsConnected)
            {
                MessageBox.Show("Kết nối PLC thành công!", "Thông báo");
                sttplc = true;
                if(sttcam==true)
                {
                    enableTab(tabControl1.TabPages[tabControl1.SelectedIndex = 1], true);
                }    
            }
            else
            {
                MessageBox.Show("Không thể kết nối với PLC!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btdisconnectplc_Click(object sender, EventArgs e)
        {
            if (plc.IsConnected)
            {
                sttplc = false;
                plc.Close();
            }
        }

        private void btdisconnectcam_Click(object sender, EventArgs e)
        {
            Cam.Stop();
            sttcam = false;
            cbcam.Enabled = true;
            MessageBox.Show("Ngắt kết nối Camera thành công!", "Thông báo");
        }

        private void movej1active_Click(object sender, EventArgs e)
        {
           if (txtthanhkeoj1.Text !="")
            {
                j1 = j1 + Convert.ToInt32(txtthanhkeoj1.Text);
                txtgocj1.Text = j1.ToString();
                plc.Write("MD100", j1);
            }    
            else
            {
                MessageBox.Show("Vui lòng chọn góc cần di chuyển!", "thông báo");
            }    
            
        }

        private void movej1posi_Click(object sender, EventArgs e)
        {
            if (txtthanhkeoj1.Text != "")
            {
                j1 = j1 - Convert.ToInt32(txtthanhkeoj1.Text);
                txtgocj1.Text = j1.ToString();
                plc.Write("MD100", j1);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn góc cần di chuyển!", "thông báo");
            }
        }

        private void movej2active_Click(object sender, EventArgs e)
        {
            if (txtthanhkeoj2.Text != "")
            {
                j2 = j2 + Convert.ToInt32(txtthanhkeoj2.Text);
                txtgocj2.Text = j2.ToString();
                plc.Write("MD104", j2);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn góc cần di chuyển!", "thông báo");
            }
        }

        private void movej3active_Click(object sender, EventArgs e)
        {
            if (txtthanhkeoj3.Text != "")
            {
                j3 = j3 + Convert.ToInt32(txtthanhkeoj3.Text);
                txtgocj3.Text = j3.ToString();
                plc.Write("MD108", j3);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn góc cần di chuyển!", "thông báo");
            }


        }

    private void movej4active_Click(object sender, EventArgs e)
        {
            if (txtthanhkeoj4.Text != "")
            {
                j4 = j4 + Convert.ToInt32(txtthanhkeoj4.Text);
                txtgocj4.Text = j4.ToString();
                plc.Write("MD112", j4);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn góc cần di chuyển!", "thông báo");
            }
        }

        private void movej5active_Click(object sender, EventArgs e)
        {
            if (txtthanhkeoj5.Text != "")
            {
                j5 = j5 + Convert.ToInt32(txtthanhkeoj5.Text);
                txtgocj5.Text = j5.ToString();
                serialport.Write(j5.ToString());
            }
            else
            {
                MessageBox.Show("Vui lòng chọn góc cần di chuyển!", "thông báo");
            }
        }

        private void movej2posi_Click(object sender, EventArgs e)
        {
            if (txtthanhkeoj2.Text != "")
            {
                j2 = j2 - Convert.ToInt32(txtthanhkeoj2.Text);
                txtgocj2.Text = j2.ToString();
                plc.Write("MD104", j2);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn góc cần di chuyển!", "thông báo");
            }
        }

        private void movej3posi_Click(object sender, EventArgs e)
        {
            if (txtthanhkeoj3.Text != "")
            {
                j3 = j3 - Convert.ToInt32(txtthanhkeoj3.Text);
                txtgocj3.Text = j3.ToString();
                plc.Write("MD108", j3);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn góc cần di chuyển!", "thông báo");
            }
        }

        private void movej4posi_Click(object sender, EventArgs e)
        {
            if (txtthanhkeoj4.Text != "")
            {
                j4 = j4 - Convert.ToInt32(txtthanhkeoj4.Text);
                txtgocj4.Text = j4.ToString();
                plc.Write("MD112", j4);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn góc cần di chuyển!", "thông báo");
            }
        }

        private void movej5posi_Click(object sender, EventArgs e)
        {
            if (txtthanhkeoj5.Text != "")
            {
                j5 = j5 - Convert.ToInt32(txtthanhkeoj5.Text);
                txtgocj5.Text = j5.ToString();
                serialport.Write(j5.ToString());
            }
            else
            {
                MessageBox.Show("Vui lòng chọn góc cần di chuyển!", "thông báo");
            }
        }

        private void btbangtai_Click(object sender, EventArgs e)
        {
            if(sttbangtai !=true)
            {
                sttbangtai = true;
                btbangtai.BackColor = Color.GreenYellow;
                plc.Write("M10.2",1);
                plc.Write("M10.2", 0);
            }
            else
            {
                sttbangtai = false;
                btbangtai.BackColor = Color.Red;
                plc.Write("M12.0", 1);
                plc.Write("M12.0", 0);
            } 
                
        }

        private void btkep_Click(object sender, EventArgs e)
        {
            plc.Write("M10.4", 1);
            plc.Write("M10.4", 0);
        }

        private void bttha_Click(object sender, EventArgs e)
        {
            plc.Write("M12.1", 1);
            plc.Write("M12.1", 0);
        }

        private void btstart_Click(object sender, EventArgs e)
        {
            plc.Write("M20.0", 1);
            plc.Write("M20.0", 0);
        }

        private void btstop_Click(object sender, EventArgs e)
        {
            plc.Write("M20.1", 1);
            plc.Write("M20.1", 0);
        }

        private void btemc_Click(object sender, EventArgs e)
        {
            plc.Write("M20.3", 1);
            plc.Write("M20.3", 0);
        }

        private void btrst_Click(object sender, EventArgs e)
        {
            plc.Write("M20.4", 1);
            plc.Write("M20.4", 0);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void connectport_Click(object sender, EventArgs e)
        {
            if (cbcom.Text == "")
            {
                MessageBox.Show("Vui lòng chọn kết nối", "Thông báo");
            }
            else
            {

                if (!serialport.IsOpen)
                {
                    serialport.PortName = cbcom.Text;
                    serialport.Open();
                    MessageBox.Show("Kết nối hệ thống thành công!", "Thông báo");
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            plc.Write("MD100", 0);
            plc.Write("MD104", 0);
            plc.Write("MD108", 0);
            plc.Write("MD112", 0);
            serialport.Write("0");
        }

        private void zeroj1_Click(object sender, EventArgs e)
        {
            plc.Write("M201.7", 1);
            plc.Write("M201.7", 0);
            j1 = 0;
            txtgocj1.Text = j1.ToString();
        }

        private void zeroj2_Click(object sender, EventArgs e)
        {
            plc.Write("M201.6", 1);
            plc.Write("M201.6", 0);
            j2 = 0;
            txtgocj2.Text = j2.ToString();
        }

        private void zeroj3_Click(object sender, EventArgs e)
        {
            plc.Write("M201.5", 1);
            plc.Write("M201.5", 0);
            j3 = 0;
            txtgocj3.Text = j3.ToString();
        }

        private void zeroj4_Click(object sender, EventArgs e)
        {
            plc.Write("M201.4", 1);
            plc.Write("M201.4", 0);
            j4 = 0;
            txtgocj4.Text = j4.ToString();
        }

        private void zeroj5_Click(object sender, EventArgs e)
        {
            j5 = 0;
            txtgocj5.Text = j5.ToString();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}
