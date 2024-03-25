using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace QueenLocalDataHandling
{
    internal class Order
    {
        private int orderID;
        private string customerCNIC;
        private string customerName;
        private string customerPhone;
        private string customerAddress;
        private string productID;
        private int price;
        private string sizeOfProduct;
        public int OrderID
        {
            get { return orderID; }
            set { orderID = value; }
        }
        public string CustomerCNIC
        {
            get { return customerCNIC; }
            set { customerCNIC = value; }
        }
        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }
        public string CustomerPhone
        {
            get { return customerPhone; }
            set { customerPhone = value; }
        }
        public string CustomerAddress
        {
            get { return customerAddress; }
            set { customerAddress = value; }
        }
        public string ProductID
        {
            get { return productID; }
            set { productID = value; }
        }
        public int Price
        {
            get { return price; }
            set { price = value; }
        }
        public string SizeOfProduct
        {
            get { return sizeOfProduct; }
            set { sizeOfProduct = value; }
        }
    }
}
