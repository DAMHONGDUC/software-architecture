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
    public partial class GUI_Add_Update_Product : Form
    {
        bool updateMode;
        DTO_Product dtoProduct;
        DTO_Product newProduct;
        BUS_Product busProduct;
        bool isEditImage;

        public GUI_Add_Update_Product(DTO_Product product, bool updateMode = false)
        {
            InitializeComponent();

            this.dtoProduct = product;
            this.updateMode = updateMode;

            this.busProduct = new BUS_Product();

            isEditImage = false;
        }

        private void GUI_Add_Update_Product_Load(object sender, EventArgs e)
        {
            txt_masp.Enabled = false;           

            if (this.updateMode)
            {
                // set giá trị cho các mục 
                txt_masp.Text = dtoProduct.id.ToString();
                txt_tensp.Text = dtoProduct.name;
                txt_sl.Text = dtoProduct.quantity.ToString();
                txt_mota.Text = dtoProduct.description;              
                txt_gia.Text = dtoProduct.price.ToString();

                label_title.Text = "CẬP NHẬT SẢN PHẨM";

                txt_hinh.Text = dtoProduct.image;
                btn_load_hinh.PerformClick();
            }
            else
            {

            }
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_hinh_TextChanged(object sender, EventArgs e)
        {
            isEditImage = true;
        }

        private void btn_load_hinh_Click(object sender, EventArgs e)
        {
            if (isEditImage)
            {
                // load anh 
                try
                {
                    picBox_QT_SP_Anh.Load(txt_hinh.Text.Trim());
                }
                catch (Exception loi)
                {
                    MessageBox.Show("Load ảnh thất bại, mã lỗi: " + loi.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (txt_mota.Text.Trim().Length == 0 ||
                  txt_sl.Text.Trim().Length == 0 || txt_tensp.Text.Trim().Length == 0 ||
                  txt_gia.Text.Trim().Length == 0 || txt_hinh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.updateMode)
            {
                newProduct = new DTO_Product(
                    int.Parse(txt_masp.Text),
                    txt_tensp.Text,
                    txt_mota.Text,
                     txt_hinh.Text,
                    int.Parse(txt_sl.Text),
                    float.Parse(txt_gia.Text)
                    );
            }
            else
            {
                newProduct = new DTO_Product(
                    txt_tensp.Text,
                    txt_mota.Text,
                     txt_hinh.Text,
                     int.Parse(txt_sl.Text),
                    float.Parse(txt_gia.Text)
                    );
            }


            if (this.updateMode)
            {
                busProduct.updateProduct(newProduct);
                MessageBox.Show("Cập nhật thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int id = busProduct.insertProduct(newProduct);
                MessageBox.Show("Thêm thành công. Mã Product: " + id, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.Close();
        }
    }
}
