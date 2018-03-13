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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            new ProductRepository().AddProduct(new Product() {ProductID = 1,ProductModel = 2,ProductVariant = 3});
        }
    }
}
