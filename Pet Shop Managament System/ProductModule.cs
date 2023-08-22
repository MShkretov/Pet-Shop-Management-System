using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Pet_Shop_Managament_System
{
    public partial class ProductModule : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        dbConnect dbcon = new dbConnect();
        string title = "Pet Shop Management System";

        ProductForm productForm;

        public ProductModule(ProductForm product)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.connection());
            productForm = product;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                CheckField();

                if (MessageBox.Show("Are you sure you want to update this Product?", "Product, Registration", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("UPDATE Products SET pname = @pname, ptype = @ptype, pcategory = @pcategory, pqty = @pqty, pprice = @pprice", cn);
                    cm.Parameters.AddWithValue("@id", pcode.Text);
                    cm.Parameters.AddWithValue("@pname", txtName.Text);
                    cm.Parameters.AddWithValue("@ptype", txtType.Text);
                    cm.Parameters.AddWithValue("@pcategory", cbcategory.Text);
                    cm.Parameters.AddWithValue("@pqty", decimal.Parse(txtQty.Text));
                    cm.Parameters.AddWithValue("@pprice", decimal.Parse(txtPrice.Text));

                    cn.Open();
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Product has been successufully updated!", title);
                    Clear();
                    productForm.LoadUser();
                    this.Dispose();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, title);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CheckField();

                    if (MessageBox.Show("Are you sure you want to register this Product?", "Product, Registration", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cm = new SqlCommand("INSERT INTO [Products](pname,ptype,pcategory,pqty,pprice)VALUES(@pname,@ptype,@pcategory,@pqty,@pprice)", cn);
                        cm.Parameters.AddWithValue("@pname", txtName.Text);
                        cm.Parameters.AddWithValue("@ptype", txtType.Text);
                        cm.Parameters.AddWithValue("@pcategory", cbcategory.Text);
                        cm.Parameters.AddWithValue("@pqty", double.Parse(txtQty.Text));
                        cm.Parameters.AddWithValue("@pprice", double.Parse(txtPrice.Text));

                        cn.Open();
                        cm.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show("Product has been successufully registered!", title);
                        Clear();
                        productForm.LoadUser();
                    }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, title);
            }
        }

        private void CheckField()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || txtName.Text == "" || double.TryParse(txtName.Text, out double nameNum))
            {
                MessageBox.Show("Invalid Name", "Warning");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtType.Text) || txtType.Text == "" || double.TryParse(txtType.Text, out double ptypeNum))
            {
                 MessageBox.Show("Invalid ptype", "Warning");
                return;
            }

            if (string.IsNullOrWhiteSpace(cbcategory.Text) || cbcategory.Text == "" || double.TryParse(cbcategory.Text, out double categoryNum))
            {
                 MessageBox.Show("Invalid category", "Warning");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtQty.Text) || txtQty.Text == "" || !Regex.IsMatch(txtQty.Text, @"^\d+(\.\d+)?$"))
            {
               MessageBox.Show("Invalid Qty", "Warning");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show("Invalid Price", "Warning");
                return;
            }
        }

        public void Clear()
        {
            txtName.Clear();
            txtType.Clear();
            txtPrice.Clear();
            txtQty.Clear();
            cbcategory.SelectedIndex = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
    