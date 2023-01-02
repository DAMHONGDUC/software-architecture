using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using _19120481_QLBH.BUS;
using _19120481_QLBH.DTO;

namespace _19120481_QLBH.GUI
{
    public partial class GUI_SignIn : Form
    {
        BUS_User busUser;
        DTO_User dtoUser;
        Thread t;

        public GUI_SignIn()
        {
            InitializeComponent();
        }

        private void GUI_SignIn_Load(object sender, EventArgs e)
        {
            ConectDb();
        }

        private void ConectDb()
        {
            busUser = new BUS_User();
            bool state = busUser.ConnectDB();

            if (!state)
            {
                MessageBox.Show("Can't connect to DB");
                this.Close();
            }
        }

        public void openFormMain(object obj)
        {
            switch (dtoUser.role)
            {
                case 0:
                    {
                        Application.Run(new GUI_Main_Admin());
                        break;
                    }
                case 1:
                    {
                        Application.Run(new GUI_Main_Staff());
                        break;
                    }
            }
        }

        private void btn_dangnhap_Click(object sender, EventArgs e)
        {
            string tendn = txtBox_tendangnhap.Text.Trim().ToString();
            string matkhau = txtBox_matkhau.Text.Trim().ToString();

            // nếu chưa có dữ liệu 
            if (tendn.Length == 0 | matkhau.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dtoUser = busUser.Login(tendn, matkhau);

            if (dtoUser != null)
            {              
                this.Close();
                t = new Thread(openFormMain);
                t.SetApartmentState(ApartmentState.STA);
                t.Start();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập/mật khẩu sai !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


        }
    }
}
