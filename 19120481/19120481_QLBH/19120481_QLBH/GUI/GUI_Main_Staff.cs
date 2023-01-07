using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using _19120481_QLBH.DTO;

namespace _19120481_QLBH.GUI
{
    public partial class GUI_Main_Staff : Form
    {
        DTO_User dtoUser;
        Thread t;

        public GUI_Main_Staff(DTO_User user)
        {
            InitializeComponent();

            this.dtoUser = user;
        }

        private void GUI_Main_Staff_Load(object sender, EventArgs e)
        {
            labelName.Text = dtoUser.fullname;

            btn_themdh_NV.PerformClick();
        }

        // mở 1 form con
        private Form activeform = null;
        private void openChildForm(Form childForm)
        {
            if (activeform != null)
                activeform.Close();
            activeform = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm_KH.Controls.Add(childForm);
            panelChildForm_KH.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        // xử lí chuyển màu khi click vào button
        private Button currentButton;
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = ColorTranslator.FromHtml("#4169E1");
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                }
            }
        }
        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(39, 39, 58);
                    previousBtn.ForeColor = Color.Gainsboro;
                }
            }
        }

        // xử lí đăng xuất + đăng nhập lại
        private void btn_dangxuat_KH_Click_1(object sender, EventArgs e)
        {
            this.Close();
            t = new Thread(open_FormDangNhap);
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }

        private void btn_thoat_KH_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        public void open_FormDangNhap(object obj)
        {
            Application.Run(new GUI_SignIn());
        }

        private void btn_themdh_NV_Click(object sender, EventArgs e)
        {
            openChildForm(new GUI_Product(dtoUser));
            ActivateButton(sender);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openChildForm(new GUI_Order(dtoUser));
            ActivateButton(sender);
        }
    }
}
