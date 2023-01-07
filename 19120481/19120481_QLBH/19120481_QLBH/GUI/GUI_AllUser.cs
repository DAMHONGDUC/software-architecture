using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _19120481_QLBH.BUS;
using _19120481_QLBH.DTO;

namespace _19120481_QLBH.GUI
{
    public partial class GUI_AllUser : Form
    {
        DataTable tbl_staff;
        BUS_User busUser;
        DTO_User dtoUser;

        public GUI_AllUser()
        {
            InitializeComponent();

            busUser = new BUS_User();
        }

        private void LoadDataDGV(DataTable tbl)
        {
            dGV_all_staff.DataSource = tbl;

            // set Font cho tên cột
            dGV_all_staff.Font = new Font("Time New Roman", 13);
            dGV_all_staff.Columns[0].HeaderText = "ID";
            dGV_all_staff.Columns[1].HeaderText = "Username";
            dGV_all_staff.Columns[2].HeaderText = "Password";
            dGV_all_staff.Columns[3].HeaderText = "Fullname";
            dGV_all_staff.Columns[4].HeaderText = "DOB";

            // set Font cho dữ liệu hiển thị trong cột
            dGV_all_staff.DefaultCellStyle.Font = new Font("Time New Roman", 12);

            // set kích thước cột
            dGV_all_staff.Columns[0].Width = 200;
            dGV_all_staff.Columns[1].Width = 200;
            dGV_all_staff.Columns[2].Width = 200;
            dGV_all_staff.Columns[3].Width = 200;
            dGV_all_staff.Columns[4].Width = 200;

            //Không cho người dùng thêm dữ liệu trực tiếp
            dGV_all_staff.AllowUserToAddRows = false;

            dGV_all_staff.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void GUI_AllStaff_Load(object sender, EventArgs e)
        {
            tbl_staff = busUser.getAllStaff();

            LoadDataDGV(tbl_staff);

            button_update_user.Enabled = false;
        }

        private void dGV_all_staff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tbl_staff.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            button_update_user.Enabled = true;

            // set giá trị cho các mục 
            txt_id.Text = dGV_all_staff.CurrentRow.Cells["ID"].Value.ToString();
            txt_Fullname.Text = dGV_all_staff.CurrentRow.Cells["FULLNAME"].Value.ToString();
            txt_username.Text = dGV_all_staff.CurrentRow.Cells["USERNAME"].Value.ToString();
            txt_password.Text = dGV_all_staff.CurrentRow.Cells["PASSWORD"].Value.ToString();
            txt_role.Text = dGV_all_staff.CurrentRow.Cells["ROLE"].Value.ToString();
            dTP_dob.Text = dGV_all_staff.CurrentRow.Cells["DOB"].Value.ToString();
        }

        private void button_add_user_Click(object sender, EventArgs e)
        {
            button_update_user.Enabled = false;

            GUI_Add_Update_User gui_Add_Update_User = new GUI_Add_Update_User(dtoUser);
            gui_Add_Update_User.Show();
            gui_Add_Update_User.FormClosed += new FormClosedEventHandler(Form_Closed);
        }

        private void button_update_user_Click(object sender, EventArgs e)
        {   
            dtoUser = new DTO_User(
                    int.Parse(txt_id.Text),
                    txt_Fullname.Text,
                    DateTime.Parse(dTP_dob.Text),
                     int.Parse(txt_role.Text),
                    txt_username.Text,
                    txt_password.Text
                    );

            GUI_Add_Update_User gui_Add_Update_User = new GUI_Add_Update_User(dtoUser, true);
            gui_Add_Update_User.Show();
            gui_Add_Update_User.FormClosed += new FormClosedEventHandler(Form_Closed);
        }

        private void resetValue()
        {
            txt_id.Text = "";
            txt_Fullname.Text = "";
            txt_username.Text = "";
            txt_password.Text = "";
            txt_role.Text = "";
            dTP_dob.Text = "";
        }

        void Form_Closed(object sender, FormClosedEventArgs e)
        {
            tbl_staff = busUser.getAllStaff();

            LoadDataDGV(tbl_staff);
            resetValue();
        }
    }
}
