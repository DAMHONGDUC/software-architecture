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
using System.Data;

namespace _19120481_QLBH.GUI
{
    public partial class GUI_Product : Form
    {
        BUS_Product busProduct;
        DataTable tbl_QT_SP;
        DTO_User dtoUser;

        public GUI_Product(DTO_User user)
        {
            InitializeComponent();

            busProduct = new BUS_Product();
            dtoUser = user;
        }

        private void LoadDataDGV(DataTable tbl)
        {
            
            dGV_QT_SP.DataSource = tbl;

            // set Font cho tên cột
            dGV_QT_SP.Font = new Font("Time New Roman", 13);
            dGV_QT_SP.Columns[0].HeaderText = "Mã sản phẩm";
            dGV_QT_SP.Columns[1].HeaderText = "Tên sản phẩm";
            dGV_QT_SP.Columns[2].HeaderText = "Mô tả";
            dGV_QT_SP.Columns[3].HeaderText = "Hình ảnh";
            dGV_QT_SP.Columns[4].HeaderText = "Số lượng";
            dGV_QT_SP.Columns[5].HeaderText = "Giá";

            // set Font cho dữ liệu hiển thị trong cột
            dGV_QT_SP.DefaultCellStyle.Font = new Font("Time New Roman", 12);

            // set kích thước cột
            dGV_QT_SP.Columns[0].Width = 200;
            dGV_QT_SP.Columns[1].Width = 200;
            dGV_QT_SP.Columns[2].Width = 200;
            dGV_QT_SP.Columns[3].Width = 200;
            dGV_QT_SP.Columns[4].Width = 200;
            dGV_QT_SP.Columns[5].Width = 200;

            //Không cho người dùng thêm dữ liệu trực tiếp
            dGV_QT_SP.AllowUserToAddRows = false;

            dGV_QT_SP.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void disableBottomOption()
        {
            if (dtoUser.role != 0)
            {
                button_ThemSP.Visible = false;
                button_LuuSP.Visible = false;
                button_QT_XoaSP.Visible = false;
                button_QT_CapNhatSP.Visible = false;
            }
            else
            {
                btn_themdh.Visible = false;
            }
        }

        private void GUI_Product_Load(object sender, EventArgs e)
        {
            tbl_QT_SP = busProduct.getAllProduct();

            LoadDataDGV(tbl_QT_SP);

            disableBottomOption();
        }

        private void dGV_QT_SP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tbl_QT_SP.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // set giá trị cho các mục 
            textBox_QT_SP_MASP.Text = dGV_QT_SP.CurrentRow.Cells["ID"].Value.ToString();
            txtBox_QT_SP_TenSP.Text = dGV_QT_SP.CurrentRow.Cells["NAME"].Value.ToString();
            textBox_QT_SP_MoTa.Text = dGV_QT_SP.CurrentRow.Cells["DESCRIPTION"].Value.ToString();
            txtBox_QT_SP_SL.Text = dGV_QT_SP.CurrentRow.Cells["QUANTITY"].Value.ToString();
            txtBox_QT_SP_GiaGoc.Text = dGV_QT_SP.CurrentRow.Cells["PRICE"].Value.ToString();
            textBox_HinhAnh.Text = dGV_QT_SP.CurrentRow.Cells["IMAGE"].Value.ToString();
            // load anh 
            try
            {
                picBox_QT_SP_Anh.Load(dGV_QT_SP.CurrentRow.Cells["IMAGE"].Value.ToString());
            }
            catch (Exception loi)
            {
                MessageBox.Show("Load ảnh thất bại, mã lỗi: " + loi.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void btn_themdh_Click(object sender, EventArgs e)
        {

        }

        private void textBox_tensp_search_TextChanged(object sender, EventArgs e)
        {
            string name = textBox_tensp_search.Text.Trim();

            tbl_QT_SP = busProduct.searchByName(name);

            LoadDataDGV(tbl_QT_SP);
        }
    }
}
