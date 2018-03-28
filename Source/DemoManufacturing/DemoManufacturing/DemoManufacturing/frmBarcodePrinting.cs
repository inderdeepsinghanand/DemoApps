using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using DemoManufacturing.Entities;
using DemoManufacturing.DataAccess;

namespace DemoManufacturing
{
    public partial class frmBarcodePrinting : Form
    {
        public frmBarcodePrinting(string barCode)
        {
            InitializeComponent();
            //if(barCode.
          //  string barCode = txtCode.Text;

            label1.Text = "Emission Norms:Gasoline, Color:White, MajorVariant:K2,Type:Front,Customer Code:Cust001";
            Bitmap bitMap = new Bitmap(barCode.Length * 40, 80);

            using (Graphics graphics = Graphics.FromImage(bitMap))
            {
                Font oFont = new Font("IDAutomationHC39M", 16);
                PointF point = new PointF(2f, 2f);
                SolidBrush blackBrush = new SolidBrush(Color.Black);
                SolidBrush whiteBrush = new SolidBrush(Color.White);
                graphics.DrawString("Hello asadsads s dasdada da dasdsaa", oFont, blackBrush, 0,0);
                graphics.FillRectangle(whiteBrush, 10, 20, bitMap.Width, bitMap.Height);
                graphics.DrawString("*" + barCode + "*", oFont, blackBrush, point);
            }
            using (MemoryStream ms = new MemoryStream())
            {
                bitMap.Save(ms, ImageFormat.Png);
                pictureBox1.Image = bitMap;
                pictureBox1.Height = bitMap.Height;
                pictureBox1.Width = bitMap.Width;
            }

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        public void SetPrintStatus(long OrderID, string Barcode)
        {
            //new CustomerOrderRepository

            new CustomerOrderRepository().ChangePrintStatus(OrderID);

            //var barcode = "select * from tbl"

            //frmBarcodePrinting barcodePrint = new frmBarcodePrinting(Barcode);
            //barcodePrint.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
