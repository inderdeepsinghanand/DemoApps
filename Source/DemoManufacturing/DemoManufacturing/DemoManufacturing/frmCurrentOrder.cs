using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DemoManufacturing.DataAccess;
using DemoManufacturing.Entities;

namespace DemoManufacturing
{
    public partial class frmCurrentOrder : Form
    {
        public frmCurrentOrder()
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;

            new ProductRepository().AddProduct(new Product() {ProductID = 1,ProductModel = 2,ProductVariant = 3});
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
