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
    public partial class GUI_Main_Admin : Form
    {
        DTO_User dtoUser;
        Thread t;
        public GUI_Main_Admin(DTO_User user)
        {
            InitializeComponent();

            this.dtoUser = user;
        }

        private void GUI_Main_Admin_Load(object sender, EventArgs e)
        {
            labelName.Text = dtoUser.fullname;
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
        private void btn_dangxuat_KH_Click(object sender, EventArgs e)
        {
            this.Close();
            t = new Thread(open_FormDangNhap);
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }

        public void open_FormDangNhap(object obj)
        {
            Application.Run(new GUI_SignIn());
        }

        private void btn_thoat_KH_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_sanpham_QT_Click(object sender, EventArgs e)
        {
            openChildForm(new GUI_Product(dtoUser));
            ActivateButton(sender);
        }

        private void btn_NV_Click(object sender, EventArgs e)
        {
            openChildForm(new GUI_AllUser());
            ActivateButton(sender);
        }

        private void btn_DH_Click(object sender, EventArgs e)
        {
            openChildForm(new GUI_Order(dtoUser));
            ActivateButton(sender);
        }
    }
}
