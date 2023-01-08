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
        DataTable tbl_SP;
        DTO_User dtoUser;
        DTO_Product dtoProduct;

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

        private void resetValue()
        {
            textBox_QT_SP_MASP.Text = "";
            txtBox_QT_SP_TenSP.Text = "";
            textBox_QT_SP_MoTa.Text = "";
            txtBox_QT_SP_SL.Text = "";
            txtBox_QT_SP_GiaGoc.Text = "";
            textBox_HinhAnh.Text = "";
        }

        private void disableOption()
        {
            if (dtoUser.role == 0)
            {
                btn_themdh.Visible = false;              
            }
            else
            {
                button_ThemSP.Visible = false;
                button_QT_XoaSP.Visible = false;
                button_QT_CapNhatSP.Visible = false;
                btn_themdh.Enabled = false;
            }
        }

        private void GUI_Product_Load(object sender, EventArgs e)
        {
            tbl_SP = busProduct.getAllProduct();

            LoadDataDGV(tbl_SP);

            disableOption();

            button_QT_CapNhatSP.Enabled = false;
            button_QT_XoaSP.Enabled = false;
        }

        private void dGV_QT_SP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tbl_SP.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            button_QT_CapNhatSP.Enabled = true;
            btn_themdh.Enabled = true;
            button_QT_XoaSP.Enabled = true;

            dtoProduct = new DTO_Product(
                Int32.Parse(dGV_QT_SP.CurrentRow.Cells["ID"].Value.ToString()),
                dGV_QT_SP.CurrentRow.Cells["NAME"].Value.ToString(),
                dGV_QT_SP.CurrentRow.Cells["DESCRIPTION"].Value.ToString(),
                dGV_QT_SP.CurrentRow.Cells["IMAGE"].Value.ToString(),
            Int32.Parse(dGV_QT_SP.CurrentRow.Cells["QUANTITY"].Value.ToString()),
                float.Parse(dGV_QT_SP.CurrentRow.Cells["PRICE"].Value.ToString()));
                

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
            GUI_CreateOrder_Staff gui_CreateOrder_Staff = new GUI_CreateOrder_Staff(dtoProduct, dtoUser);
            gui_CreateOrder_Staff.Show();
            gui_CreateOrder_Staff.FormClosed += new FormClosedEventHandler(Form_Closed);
        }

        void Form_Closed(object sender, FormClosedEventArgs e)
        {
            tbl_SP = busProduct.getAllProduct();
            LoadDataDGV(tbl_SP);
            resetValue();
        }

        private void textBox_tensp_search_TextChanged(object sender, EventArgs e)
        {
            string name = textBox_tensp_search.Text.Trim();

            tbl_SP = busProduct.searchByName(name);

            LoadDataDGV(tbl_SP);
        }

        private void button_ThemSP_Click(object sender, EventArgs e)
        {
            button_QT_CapNhatSP.Enabled = false;
            button_QT_XoaSP.Enabled = false;

            GUI_Add_Update_Product gui_Add_Update_Product = new GUI_Add_Update_Product(dtoProduct);
            gui_Add_Update_Product.Show();
            gui_Add_Update_Product.FormClosed += new FormClosedEventHandler(Form_Add_Update_Product_Closed);
        }

        private void button_QT_CapNhatSP_Click(object sender, EventArgs e)
        {
            GUI_Add_Update_Product gui_Add_Update_Product = new GUI_Add_Update_Product(dtoProduct, true);
            gui_Add_Update_Product.Show();
            gui_Add_Update_Product.FormClosed += new FormClosedEventHandler(Form_Add_Update_Product_Closed);
        }

        private void button_QT_XoaSP_Click(object sender, EventArgs e)
        {
            busProduct.deleteProduct(int.Parse(textBox_QT_SP_MASP.Text));

            MessageBox.Show("Xóa Product thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            tbl_SP = busProduct.getAllProduct();

            LoadDataDGV(tbl_SP);
            resetValue();
        }

        void Form_Add_Update_Product_Closed(object sender, FormClosedEventArgs e)
        {
            tbl_SP = busProduct.getAllProduct();

            LoadDataDGV(tbl_SP);
            resetValue();
        }
    }
}
