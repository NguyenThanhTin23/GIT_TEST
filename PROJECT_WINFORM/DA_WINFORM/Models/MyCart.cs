using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA_WINFORM.Models
{
    public class MyCart
    {/*
        [DisplayName("Tên Tour")]
        public string name { get; set; }
        [DisplayName("Số lượng ")]
        public int quantity { set; get; }
        [DisplayName("Đơn giá")]
        public int unit_price { set; get; }

        [DisplayName("Thành tiền")]
        public int total_amount
        {
            get
            {
                return quantity * unit_price;
            }
        }*/
        [DisplayName("Tên Tour")]
        public string name { get; set; }
        [DisplayName("Số người ")]
        public long quantity { set; get; }
        [DisplayName("Đơn giá")]
        public long unit_price { set; get; }

        [DisplayName("Thành tiền")]
        public long total_amount { set; get; }
    }
}
