using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _19120481_QLBH.DTO;
using _19120481_QLBH.BUS;


namespace _19120481_QLBH.GUI
{
    public partial class GUI_Add_Update_User : Form
    {
        DTO_User dtoUser;
        DTO_User newUser;
        bool updateMode;
        BUS_User busUser;

        public GUI_Add_Update_User(DTO_User user, bool updateMode = false)
        {
            InitializeComponent();

            this.dtoUser = user;
            this.updateMode = updateMode;

            busUser = new BUS_User();
        }

        private string getRole(int value)
        {
            string result = "";

            switch (value)
            {
                case 0:
                    result = "Admin";
                    break;
                case 1:
                    result = "Staff";
                    break;
            }

            return result;
        }


        private void GUI_Add_Update_User_Load(object sender, EventArgs e)
        {
            txt_id.Enabled = false;

            if (this.updateMode)
            {
                // set giá trị cho các mục 
                txt_id.Text = dtoUser.id.ToString();
                txt_Fullname.Text = dtoUser.fullname;
                txt_username.Text = dtoUser.username;
                txt_password.Text = dtoUser.password;
                cb_role.Text = getRole(dtoUser.role);
                dTP_dob.Text = dtoUser.dob.ToString();

                label_title.Text = "CẬP NHẬT NHÂN VIÊN";
            }
            else
            {
                
            }
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (txt_Fullname.Text.Trim().Length == 0 ||
                   txt_username.Text.Trim().Length == 0 || txt_password.Text.Trim().Length == 0 ||
                   cb_role.Text.Trim().Length == 0 || dTP_dob.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.updateMode)
            {
                newUser = new DTO_User(
                    int.Parse(txt_id.Text),
                    txt_Fullname.Text,
                    DateTime.Parse(dTP_dob.Text),
                     cb_role.SelectedIndex,
                    txt_username.Text,
                    txt_password.Text
                    );
            }else
            {
                newUser = new DTO_User(
                    txt_Fullname.Text,
                    DateTime.Parse(dTP_dob.Text),
                     cb_role.SelectedIndex,
                    txt_username.Text,
                    txt_password.Text
                    );
            }

            

            if (this.updateMode)
            {
                busUser.updateUser(newUser);
                MessageBox.Show("Cập nhật thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int id = busUser.insertUser(newUser);
                MessageBox.Show("Thêm thành công. Mã User: " + id, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.Close();          
        }
    }
}
