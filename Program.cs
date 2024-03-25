using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections.Specialized;
namespace QueenLocalDataHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-------------------------Welcome To The Queen's store-------------------------");
            Console.WriteLine("1. Insert Order:    ");
            Console.WriteLine("2. Display All Orders:    ");
            Console.WriteLine("3. Update Customer Address:    ");
            Console.WriteLine("4. Delete Order:    ");
            Console.WriteLine("5. Update Order Address");
            int activityNumber;
            Console.Write("Which Activity u Want to perform:    ");
            Console.WriteLine("Enter your Choice form 1 to 5: Enter -1 to exit");
            activityNumber = int.Parse(Console.ReadLine());
            while (activityNumber!=-1)
            {
                OrderCRUD orderCRUD = new OrderCRUD();
                Validation validation=new Validation();
                if (activityNumber == 1)
                {
                    Order order = new Order();
                    Console.WriteLine("---------------Enter the details of A new Order---------------");
                    Console.Write("Enter The Order ID:          ");
                    order.OrderID = int.Parse(Console.ReadLine());
                    Console.Write("Enter the Customer's CNIC in format 00000-0000000-0:           ");
                    order.CustomerCNIC = Console.ReadLine();
                    order.CustomerCNIC = validation.validateCNIC(order.CustomerCNIC);
                    Console.Write("Enter the Customer's Name            ");
                    order.CustomerName = Console.ReadLine();
                    Console.Write("Enter the customer's Phone in format 0000-0000000          ");
                    order.CustomerPhone = Console.ReadLine();
                    order.CustomerPhone=validation.validateMobile(order.CustomerPhone);
                    Console.Write("Enter the Customer's Address             ");
                    order.CustomerAddress = Console.ReadLine();
                    Console.Write("Enter the Product ID         ");
                    order.ProductID = Console.ReadLine();
                    Console.Write("Enter the price of Product           ");
                    order.Price = int.Parse(Console.ReadLine());
                    Console.Write("Enter the Size of Product:           ");
                    order.SizeOfProduct = Console.ReadLine();
                    orderCRUD.insertOrder(order);
                    Console.WriteLine("The order has been inserted successfully:");
                }
                else if (activityNumber == 2)
                {
                    Console.WriteLine("---------------The details of All Orders are here---------------");
                    orderCRUD.getAllOrders();
                }
                else if (activityNumber == 3)
                {
                    Console.WriteLine("Enter the Phone Number of the Customer Whose Address u want to update:");
                    string phone;
                    phone = Console.ReadLine();
                    string address;
                    Console.WriteLine("Enter the New Address:");
                    address = Console.ReadLine();
                    orderCRUD.UpdateAddress(phone, address);
                    Console.WriteLine("The address of the customer has been updated successfully:");
                }
                else if (activityNumber == 4)
                {
                    Console.WriteLine("Enter the Order ID of That oder which u want to delete");
                    int orderID;
                    orderID = int.Parse(Console.ReadLine());
                    orderCRUD.deleteOrder(orderID);
                    Console.WriteLine("The order has been deleted successfully:");
                }
                else if (activityNumber == 5)
                {
                    Console.WriteLine("Enter the Phone Number of the Customer Whose Order Address u want to update:");
                    string phone;
                    phone = Console.ReadLine();
                    string address;
                    Console.WriteLine("Enter the New Address:");
                    address = Console.ReadLine();
                    orderCRUD.updateOrderAddress(phone, address);
                    Console.WriteLine("The Order Address of the customer has been updated successfully:");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("There is no Such activity:");
                }
                Console.Write("Which Activity u Want to perform:    ");
                Console.WriteLine("Enter your Choice form 1 to 5: Enter -1 to exit");
                activityNumber = int.Parse(Console.ReadLine());
            }
            
        }
    }
}