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
    public partial class GUI_Order : Form
    {
        DataTable tbl_myOrder;
        BUS_Order busOrder;
        DTO_User dtoUser;

        public GUI_Order(DTO_User user)
        {
            InitializeComponent();

            this.dtoUser = user;

            busOrder = new BUS_Order();
        }

        private void LoadDataDGV(DataTable tbl)
        {

            dGV_myOrder.DataSource = tbl;

            // set Font cho tên cột
            dGV_myOrder.Font = new Font("Time New Roman", 13);
            dGV_myOrder.Columns[0].HeaderText = "Mã đơn hàng";
            dGV_myOrder.Columns[1].HeaderText = "Mã khách hàng";
            dGV_myOrder.Columns[2].HeaderText = "Mã nhân viên";
            dGV_myOrder.Columns[3].HeaderText = "Địa chỉ muốn giao";
            dGV_myOrder.Columns[4].HeaderText = "Ngày muốn giao";
            dGV_myOrder.Columns[5].HeaderText = "Tên người nhận";
            dGV_myOrder.Columns[6].HeaderText = "SDT người nhận";
            dGV_myOrder.Columns[7].HeaderText = "Ngày tạo";
            dGV_myOrder.Columns[8].HeaderText = "Trạng thái đơn hàng";
            dGV_myOrder.Columns[9].HeaderText = "Hình thức thanh toán";
            dGV_myOrder.Columns[8].HeaderText = "Phí giao hàng";
            dGV_myOrder.Columns[9].HeaderText = "Tổng tiền";

            // set Font cho dữ liệu hiển thị trong cột
            dGV_myOrder.DefaultCellStyle.Font = new Font("Time New Roman", 12);

            // set kích thước cột
            dGV_myOrder.Columns[0].Width = 200;
            dGV_myOrder.Columns[1].Width = 200;
            dGV_myOrder.Columns[2].Width = 200;
            dGV_myOrder.Columns[3].Width = 200;
            dGV_myOrder.Columns[4].Width = 200;
            dGV_myOrder.Columns[5].Width = 200;
            dGV_myOrder.Columns[6].Width = 200;
            dGV_myOrder.Columns[7].Width = 200;
            dGV_myOrder.Columns[8].Width = 200;
            dGV_myOrder.Columns[9].Width = 200;

            //Không cho người dùng thêm dữ liệu trực tiếp
            dGV_myOrder.AllowUserToAddRows = false;

            dGV_myOrder.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void GUI_MyOrder_Staff_Load(object sender, EventArgs e)
        {
            if (dtoUser.role == 0)
            {
                tbl_myOrder = busOrder.getAllOrder();
                label_order_title.Text = "TẤT CẢ ĐƠN HÀNG";
            }
            else
            {
                tbl_myOrder = busOrder.getOrderByStaffId(this.dtoUser.id);
            }         

            LoadDataDGV(tbl_myOrder);
        }

        private string getOrderStatus(string value)
        {
            string result = "";

            switch(int.Parse(value))
            {
                case 0:
                    result = "Chưa thanh toán";
                    break;
                case 1:
                    result = "Đã thanh toán";
                    break;
            }

            return result;
        }
        private string getPaymentType(string value)
        {            
            string result = "";

            switch (int.Parse(value))
            {
                case 0:
                    result = "Thanh toán bằng tiền mặt";
                    break;
                case 1:
                    result = "Chuyển khoản ngân hàng";
                    break;
            }

            return result;
        }

        private void dGV_myOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tbl_myOrder.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // set giá trị cho các mục 
            textBox_madh.Text = dGV_myOrder.CurrentRow.Cells["ID"].Value.ToString();
            textBox_makh.Text = dGV_myOrder.CurrentRow.Cells["ID_CUSTOMER"].Value.ToString();
            txt_diachinguoinhan.Text = dGV_myOrder.CurrentRow.Cells["DELIVERY_ADDRESS"].Value.ToString();
            dtp_ngaymuongiao.Text = dGV_myOrder.CurrentRow.Cells["DELIVERY_DATE"].Value.ToString();
            txtBox_tennguoinhan.Text = dGV_myOrder.CurrentRow.Cells["RECIPIENT_NAME"].Value.ToString();
            txt_sdtnguoinhan.Text = dGV_myOrder.CurrentRow.Cells["RECIPIENT_PHONE"].Value.ToString();
            dTP_ngaytao.Text = dGV_myOrder.CurrentRow.Cells["DATE_CREATED"].Value.ToString();
            txt_tinhtrangDH.Text = getOrderStatus(dGV_myOrder.CurrentRow.Cells["ORDER_STATUS"].Value.ToString());
            txt_hinhthucTT.Text = getPaymentType(dGV_myOrder.CurrentRow.Cells["PAYMENT_TYPE"].Value.ToString());
            txt_phigiaohang.Text = dGV_myOrder.CurrentRow.Cells["DELIVERY_COST"].Value.ToString();
            txt_tongtien.Text = dGV_myOrder.CurrentRow.Cells["TOTAL_MONEY"].Value.ToString();
        }
    }
}
