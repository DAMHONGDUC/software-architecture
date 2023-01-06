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
    public partial class GUI_CreateOrder_Staff : Form
    {
        DTO_Product dtoProduct;
        DTO_User dtoUser;
        DataTable tbl_KH;
        BUS_Customer busCustomer;
        BUS_Order busOrder;
        int idCustomer;

        public GUI_CreateOrder_Staff(DTO_Product product, DTO_User user)
        {
            InitializeComponent();

            this.dtoProduct = product;
            this.dtoUser = user;
        }

        private void GUI_CreateOrder_Staff_Load(object sender, EventArgs e)
        {
            txtbox_tensp.Text = dtoProduct.name;
            txtbox_dongia.Text = dtoProduct.price.ToString();
            txtbox_slton.Text = dtoProduct.quantity.ToString();

            txtBox_tongcong.Enabled = false;
            txtbox_tensp.Enabled = false;
            txtbox_dongia.Enabled = false;
            txtbox_slton.Enabled = false;

            busCustomer = new BUS_Customer();
            busOrder = new BUS_Order();

            dTP_ngaygiao.CustomFormat = "yyyy-MM-dd";
            dTP_ngaymua.CustomFormat = "yyyy-MM-dd";
        }

        private void btn_giamsl_DH_KH_Click(object sender, EventArgs e)
        {
            int slmua = Int32.Parse(txtBox_slmua.Text.Trim().ToString());
            slmua -= 1;
            if (slmua < 1) slmua = 1;
            txtBox_slmua.Text = slmua.ToString();
            Auto_Tong_Tien();
        }

        private void btn_tangsl_DH_KH_Click(object sender, EventArgs e)
        {
            int slmua = Int32.Parse(txtBox_slmua.Text.Trim().ToString());
            slmua += 1;
            if (slmua >= dtoProduct.quantity) slmua = dtoProduct.quantity;
            txtBox_slmua.Text = slmua.ToString();
            Auto_Tong_Tien();
        }

        private void Auto_Tong_Tien()
        {
            float tongcong = (dtoProduct.price * Int32.Parse(txtBox_slmua.Text.Trim().ToString()));             

            if (txtBox_phigiaohang.Text.Length > 0)
                tongcong = tongcong + float.Parse(txtBox_phigiaohang.Text);

            if (tongcong > 0)
                txtBox_tongcong.Text = tongcong.ToString("0.0000");
            else
                txtBox_tongcong.Text = "";
        }

        private void txtBox_phigiaohang_TextChanged(object sender, EventArgs e)
        {
            Auto_Tong_Tien();
        }

        private void reset_value()
        {
            txtBox_ktsdt.Text = "";
            txtBox_tenkh.Text = "";
            txtBox_sdt.Text = "";
        }

        private void cBox_KH_cotk_CheckedChanged(object sender, EventArgs e)
        {
            reset_value();
            if (cBox_KH_cotk.Checked)
            {
                txtBox_ktsdt.Enabled = true;
                txtBox_tenkh.Enabled = false;
                txtBox_sdt.Enabled = false;
            }
            else
            {
                txtBox_ktsdt.Enabled = false;
                txtBox_tenkh.Enabled = true;
                txtBox_sdt.Enabled = true;
            }
        }

        private void btn_timtk_Click(object sender, EventArgs e)
        {
            if (cBox_KH_cotk.Checked && txtBox_ktsdt.Text.Trim().Length > 0)
            {
                tbl_KH = busCustomer.getCustomer(txtBox_ktsdt.Text.Trim().ToString());

                if (tbl_KH.Rows.Count == 0)
                {
                    MessageBox.Show("Số điện thoại không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                this.idCustomer = tbl_KH.Rows[0].Field<Int32>(0);
                txtBox_tenkh.Text = tbl_KH.Rows[0].Field<String>(1).ToString();
                txtBox_sdt.Text = tbl_KH.Rows[0].Field<String>(2).ToString();
            }
        }

        private void btn_themdh_Click(object sender, EventArgs e)
        {
            if (txtBox_tenkh.Text.Length == 0 || txtBox_sdt.Text.Length == 0
                || txtBox_tennguoinhan.Text.Length == 0 || txtBox_sdtnguoinhan.Text.Length == 0
                || txtBox_diachinguoinhan.Text.Length == 0 || dTP_ngaymua.Text.Length == 0
                || dTP_ngaygiao.Text.Length == 0 || cbBox_HTTT.Text.Length == 0 
                || txtBox_phigiaohang.Text.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtBox_slmua.Text.Trim().Equals("0"))
            {
                MessageBox.Show("Số lượng mua hàng phải > 0 !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            
            if (!cBox_KH_cotk.Checked && txtBox_tenkh.Text.Trim().Length > 0 && txtBox_sdt.Text.Trim().Length > 0)
            {
               this.idCustomer = busCustomer.insertCustomer(new DTO_Customer(txtBox_tenkh.Text.Trim(), txtBox_sdt.Text.Trim()));
            }

            int orderStatus = 1;
            DTO_Order dtoOrder = new DTO_Order(
                this.idCustomer,
                this.dtoUser.id,
                txtBox_diachinguoinhan.Text,
                dTP_ngaygiao.Text,
                txtBox_tennguoinhan.Text,
                txtBox_sdtnguoinhan.Text,
                dTP_ngaymua.Text,
                orderStatus,
                cbBox_HTTT.SelectedIndex,
                float.Parse(txtBox_phigiaohang.Text),
                float.Parse(txtBox_tongcong.Text)
                );           
            int idOrder = busOrder.insertOrder(dtoOrder);

            if (idOrder != null)
            {
                DTO_OrderDetail dtoOrderDetail = new DTO_OrderDetail(
                    idOrder,
                    this.dtoProduct.id,
                    Int32.Parse(txtBox_slmua.Text),
                    dtoProduct.price * Int32.Parse(txtBox_slmua.Text)
                );
                busOrder.insertOrderDetail(dtoOrderDetail);
                busOrder.reduceProductQuantity(this.dtoProduct.id, this.dtoProduct.quantity - Int32.Parse(txtBox_slmua.Text));

                MessageBox.Show("Thêm đơn hàng thành công. Mã đơn hàng: " + idOrder, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
                
        }
    }
}
