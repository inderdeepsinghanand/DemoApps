﻿using System;
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
using System.Drawing.Printing;

namespace DemoManufacturing
{
    public partial class frmBarcodePrinting : Form
    {

        private PrintProduct product = null;
        public long _orderId = 0;
        public frmBarcodePrinting(PrintProduct _product,frmDashboard dashboard)
        {
            InitializeComponent();
            //if(barCode.
          //  string barCode = txtCode.Text;
            product = _product;
            _orderId = product.OrderID;
            label1.Font = new Font(FontFamily.GenericSansSerif, 7f);
            label1.Text = "EmissionNorms:" + product.EmissionNorms + ",Color:" + product.Color + ",MajorVariant:" + product.MajorVariant + ",Type:" + product.BumperType + ",CustomerCode:" + product.CustomerCode + "";
            Bitmap bitMap = new Bitmap(product.BarCode.Length * 17, 80);

            using (Graphics graphics = Graphics.FromImage(bitMap))
            {
                Font oFont = new Font("IDAutomationHC39M", 12);
                PointF point = new PointF(2f, 2f);
                SolidBrush blackBrush = new SolidBrush(Color.Black);
                SolidBrush whiteBrush = new SolidBrush(Color.White);
               // graphics.DrawString("Hello asadsads s dasdada da dasdsaa", oFont, blackBrush, 0,0);
                graphics.FillRectangle(whiteBrush, 10, 20, bitMap.Width, bitMap.Height);
                graphics.DrawString("*" + product.BarCode + "*", oFont, blackBrush, point);
               // int y = bitMap.Height + Convert.ToInt32(graphics.MeasureString("*" + barCode + "*", oFont).Height) + 2;

               //graphics.DrawString(label1.Text, new Font(FontFamily.GenericSansSerif, 11),Brushes.Black, new PointF(10f, y));
                
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

            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(PrintBarCode);

            pd.DefaultPageSettings.PaperSize = new PaperSize("210 x 297 mm", pictureBox1.Image.Width + 20, pictureBox1.Image.Height + 20);
            printPreviewDialog1.Document = pd;
            if (printPreviewDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
               // pd.Print();
            }
            
            SetPrintStatus();
        }



        private void PrintBarCode(object o, PrintPageEventArgs e)
        {
            //int x = SystemInformation.WorkingArea.X;
            //int y = SystemInformation.WorkingArea.Y;
            //int width = this.Width;
            //int height = this.Height;

            //Rectangle bounds = new Rectangle(x, y, width, height);

            //Bitmap img = new Bitmap(width, height);

            //this.DrawToBitmap(img, bounds);
            Point p = new Point(0, 0);
            e.Graphics.DrawImage(pictureBox1.Image, p);
            e.Graphics.DrawString("EmissionNorms:" + product.EmissionNorms + ",Color:" + product.Color + ",Type:" + product.Type +  "", new Font(FontFamily.GenericSansSerif, 7), Brushes.Black, new PointF(2f, 65f));
            e.Graphics.DrawString("CustomerCode:" + product.CustomerCode + "", new Font(FontFamily.GenericSansSerif, 7), Brushes.Black, new PointF(2f,74f));

            //e.Graphics.DrawString("Hello World!\n", new Font("Arial", 1), Brushes.Black, new PointF(0F, pictureBox1.Image.Height));
           // e.Graphics.DrawString("Hello World 123455", new Font("Arial", 16), Brushes.Black, new PointF(100.0F, 210.0F));

            //other code
            //label1.Text = "Emission Norms:Gasoline, Color:White, MajorVariant:K2,Type:Front,Customer Code:Cust001";
            //Bitmap bitMap = new Bitmap(barCode.Length * 40, 80);

            //using (Graphics graphics = Graphics.FromImage(bitMap))
            //{
            //    Font oFont = new Font("IDAutomationHC39M", 16);
            //    PointF point = new PointF(2f, 2f);
            //    SolidBrush blackBrush = new SolidBrush(Color.Black);
            //    SolidBrush whiteBrush = new SolidBrush(Color.White);
            //    graphics.DrawString("Hello asadsads s dasdada da dasdsaa", oFont, blackBrush, 0, 0);
            //    graphics.FillRectangle(whiteBrush, 10, 20, bitMap.Width, bitMap.Height);
            //    graphics.DrawString("*" + barCode + "*", oFont, blackBrush, point);
            //}
            //using (MemoryStream ms = new MemoryStream())
            //{
            //    bitMap.Save(ms, ImageFormat.Png);
            //    pictureBox1.Image = bitMap;
            //    pictureBox1.Height = bitMap.Height;
            //    pictureBox1.Width = bitMap.Width;
            //}

        }

        public void SetPrintStatus()
        {
            //new CustomerOrderRepository
            if (_orderId > 0)
            {
                new CustomerOrderRepository().ChangePrintStatus(_orderId);
            }
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
