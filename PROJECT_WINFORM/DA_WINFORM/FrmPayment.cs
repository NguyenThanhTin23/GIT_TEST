using DA_WINFORM.Models;
using DA_WINFORM.payOSLIb;
using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DA_WINFORM
{
    public partial class FrmPayment : Form
    {
        //https://pay.payos.vn/web/a6aab75aedec413cafe7f179b649aa0b
        public BindingList<MyCart> listCart;
        public string NoiDungThanhToan; // tối đa 25 ký tự
        public int orderID;

        PayOS payOS;
        public FrmPayment(BindingList<MyCart> _listCart, int sohoadon, string noidung)
        {
            InitializeComponent();
            this.listCart = _listCart;  
            this.NoiDungThanhToan = noidung;
            this.orderID = sohoadon;

            payOS = new PayOS(Constants.clientId, Constants.apiKey, Constants.checksumKey);
            this.Text = $"{noidung} - Đơn hàng số: {sohoadon}";
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var listData = listCart.ToList();

            await CreateVietQRPayment(listData);

            //  var data = await payOS.getPaymentLinkInfomation(orderID);

            var isPAID = await WaitForPaidStatus(orderID);
            if (isPAID)
            {
                MessageBox.Show("Đơn hàng đã được thanh toán thành công.");
            }


        }

        private async Task<bool> WaitForPaidStatus(int orderId, int timeWait = 3000)
        {
            while (true)
            {
                var data = await payOS.getPaymentLinkInfomation(orderId);
                if (data.status == "PAID")
                {
                    return true;
                }
                await Task.Delay(timeWait);
            }
        }

        private async Task<bool>  CreateVietQRPayment(List<MyCart> listData)
        {/*
            List<ItemData> items = new List<ItemData>();
            foreach (var itemProduct in listData)
            {
                ItemData item = new ItemData(itemProduct.name, itemProduct.quantity, itemProduct.total_amount);
                items.Add(item);
            }

            var TongThanhTien = listData.Sum(x => x.total_amount);
            PaymentData paymentData = new PaymentData(orderID, TongThanhTien, NoiDungThanhToan, items, "https://localhost:3002", "https://localhost:3002");

            try
            {
                CreatePaymentResult createPayment = await  payOS.createPaymentLink(paymentData);


                var qrcode = createPayment.qrCode;
                RenderQrCode(qrcode, picVietQRCode);
                lblDescription.Text = createPayment.description;
                //var linkCheckOut = createPayment.CheckoutUrl;
                //Process.Start(new ProcessStartInfo
                //{
                //    FileName = @"C:\Program Files\Google\Chrome\Application\chrome.exe",
                //    Arguments = linkCheckOut
                //});

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }*/
            try
            {
                // Tạo danh sách items từ listData
                List<ItemData> items = listData
                    .Select(itemProduct => new ItemData(itemProduct.name, (int)itemProduct.quantity, (int)itemProduct.total_amount))
                    .ToList();

                // Tính tổng thành tiền
                long TongThanhTien = listData.Sum(x => x.total_amount);

                // Tạo dữ liệu thanh toán
                PaymentData paymentData = new PaymentData(orderID, (int)TongThanhTien, NoiDungThanhToan, items,
                                                          "https://localhost:3002", "https://localhost:3002");

                // Tạo link thanh toán
                CreatePaymentResult createPayment = await payOS.createPaymentLink(paymentData);

                // Hiển thị mã QR
                RenderQrCode(createPayment.qrCode, picVietQRCode);
                lblDescription.Text = createPayment.description;

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi Thanh Toán", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void RenderQrCode(string maQRCode, PictureBox pictureBoxQRCode)
        {

            QRCodeGenerator.ECCLevel eccLevel = QRCodeGenerator.ECCLevel.Q;
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(maQRCode, eccLevel))
            using (QRCode qrCode = new QRCode(qrCodeData))
            {
                pictureBoxQRCode.Image = qrCode.GetGraphic(20, Color.Black, Color.White, true);

            }
        }

        private async void btnHuyThanhToan_Click(object sender, EventArgs e)
        {
            var message = MessageBox.Show($"Bạn muốn hủy thanh toán đơn hàng: {orderID}", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(message == DialogResult.Yes) {
                var result = await payOS.cancelPaymentLink(orderID);
                 
                if(result.status == "CANCELLED")
                {
                    MessageBox.Show("Đã hủy đơn hàng thành công");
                }
            }
        }
    }
}
