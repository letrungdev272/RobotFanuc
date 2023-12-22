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
using S7.Net;



namespace phan_loai_mau_arm_fanuc_lr
{
    public partial class Form1 : Form
    {

        private FilterInfoCollection Camera;
        private VideoCaptureDevice Cam;
        private Bitmap bitmap;


        private Plc plc;

        
        public Form1()
        {
            InitializeComponent();
            Camera = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            Cam = new VideoCaptureDevice();

           
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            if (plc != null) plc.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (FilterInfo Device in Camera)
            {
                cbcam.Items.Add(Device.Name);
            }


           

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
                   // Cam.NewFrame += Cam_NewFrame;
                    Cam.Start();
                    MessageBox.Show("Kết nối Camera thành công!", "Thông báo");
                    cbcam.Enabled = false;

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
     
            }
            else
            {
                MessageBox.Show("Không thể kết nối với PLC!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btdisconnectcam_Click(object sender, EventArgs e)
        {
            Cam.Stop();
            cbcam.Enabled = true;
            MessageBox.Show("Ngắt kết nối Camera thành công!", "Thông báo");
        }

        private void btcontrol_Click(object sender, EventArgs e)
        {
            this.Hide();
            main mf = new main();
            mf.ShowDialog();
           
        }

       
    }
}
