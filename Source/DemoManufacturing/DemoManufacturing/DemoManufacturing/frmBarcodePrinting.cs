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
using BarCodePrinting.Entities;
using BarCodePrinting.DataAccess;
using System.Drawing.Printing;
using BarCodePrinting.Helpers;

namespace BarCodePrinting
{
    public partial class frmBarcodePrinting : Form
    {

        private PrintProduct product = null;
        public long _orderId = 0;
        frmDashboard parentForm = null;
        public frmBarcodePrinting(PrintProduct _product,frmDashboard parent)
        {
            try
            {
                InitializeComponent();
                //if(barCode.
                //  string barCode = txtCode.Text;
                product = _product;
                _orderId = product.OrderID;
                parentForm = parent;
                DrawBarcode();
                InitiatePrint();
                this.Hide();
            }
            catch (Exception ex)
            {
                LogException(ex);
            }
        }

        //public frmBarcodePrinting(PrintProduct _product, frmMasterUpload parent)
        //{
        //    InitializeComponent();
        //    //if(barCode.
        //    //  string barCode = txtCode.Text;
        //    product = _product;
        //    _orderId = product.OrderID;
        //    parentForm = parent;

        //    DrawBarcode();

        //}

        private void DrawBarcode()
        {
            label1.Font = new Font(FontFamily.GenericSansSerif, 7f);
            label1.Text = "EmissionNorms:" + product.EmissionNorms + ",Color:" + product.Color + ",MajorVariant:" + product.MajorVariant + ",Type:" + product.BumperType + ",CustomerCode:" + product.CustomerCode + "";
            //paper size changed to 10cms
            int widthInPixels = 377;
            //int widthInPixels = 529; // 14 cms
            int heightInPixels = 89; //leave some space for details
            Bitmap bitMap = new Bitmap(widthInPixels, heightInPixels);

            using (Graphics graphics = Graphics.FromImage(bitMap))
            {
                Font oFont = new Font("IDAutomationHC39M", 10.5f);
                PointF point = new PointF(2f, 2f);
                SolidBrush blackBrush = new SolidBrush(Color.Black);
                SolidBrush whiteBrush = new SolidBrush(Color.White);
                // graphics.DrawString("Hello asadsads s dasdada da dasdsaa", oFont, blackBrush, 0,0);
                graphics.FillRectangle(whiteBrush, 0, 0, bitMap.Width, bitMap.Height);
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
            InitiatePrint();
            
        
        }

        private void InitiatePrint()
        {
            //14 centimeter 
            // 2.5 cms
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(PrintBarCode);

            pd.BeginPrint += pd_BeginPrint;
            pd.DefaultPageSettings.PaperSize = new PaperSize("25 x 100 mm", pictureBox1.Image.Width , pictureBox1.Image.Height);
           // printPreviewDialog1.Document = pd;
            pd.Print();
            //if (printPreviewDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    // pd.Print();
            //}
        }

        void pd_BeginPrint(object sender, PrintEventArgs e)
        {
            var pd = (PrintDocument)sender;

            if (pd != null && !pd.PrintController.IsPreview)
            {

                SetPrintStatus();
            }
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
            Point p = new Point(5, 10);
            e.Graphics.DrawImage(pictureBox1.Image, p);
            var barcodeDetails = "Emission Norms:" + product.EmissionNorms + ", Color:" + product.Color + ", Type:" + product.Type +  ", Customer Code:" + product.CustomerCode ;

            if (barcodeDetails.Length < 50)
                e.Graphics.DrawString(barcodeDetails, new Font(FontFamily.GenericSansSerif, 7), Brushes.Black, new PointF(10f, 64f));
            else
            {
                e.Graphics.DrawString("Emission Norms:" + product.EmissionNorms + ", Color:" + product.Color + "", new Font(FontFamily.GenericSansSerif, 7), Brushes.Black, new PointF(10f, 64f));
                  e.Graphics.DrawString("Type:" + product.Type +  ", Customer Code:" + product.CustomerCode, new Font(FontFamily.GenericSansSerif, 7), Brushes.Black, new PointF(10f,74f));

            }

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

                if (parentForm != null) { parentForm.LoadGridData(); }
                new ScreensRepository().UpdateScreenReload(4, true);
            }
            //var barcode = "select * from tbl"
                
            //frmBarcodePrinting barcodePrint = new frmBarcodePrinting(Barcode);
            //barcodePrint.ShowDialog();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void LogException(Exception ex, bool showMessage = true)
        {

            ExceptionLogger.LogException(ex, "Print Order");

            if (showMessage)
                MessageBox.Show("Error occured during execution, please contact administrator for details");
        }
    }
}
