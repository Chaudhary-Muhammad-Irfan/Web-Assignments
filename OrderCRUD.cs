using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using QueenLocalDataHandling;
namespace QueenLocalDataHandling
{
    internal class OrderCRUD
    {
        Order order1=new Order();
        public void insertOrder(Order order)
        {
            try
            {
                string connection = "Data Source=(localdb)\\ProjectModels;Initial Catalog=QueensDB;Integrated Security=True";
                SqlConnection conn = new SqlConnection(connection);
                conn.Open();
                string query = $"insert into Orders (orderID , customerCNIC , customerName , customerPhone , customerAddress,productID , price , sizeOfProduct) values ({order.OrderID} , '{order.CustomerCNIC}' , '{order.CustomerName}', '{order.CustomerPhone}','{order.CustomerAddress}' , '{order.ProductID}' , '{order.Price}' , '{order.SizeOfProduct}')";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void getAllOrders()
        {
            try
            {
                string connection = "Data Source=(localdb)\\ProjectModels;Initial Catalog=QueensDB;Integrated Security=True";
                SqlConnection conn = new SqlConnection(connection);
                string query = "Select * from Orders";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    Console.WriteLine("orderID is : " + reader[0]);
                    Console.WriteLine("customerCNIC is : " + reader[1]);
                    Console.WriteLine("customerName is : " + reader[2]);
                    Console.WriteLine("customerPhone is : " + reader[3]);
                    Console.WriteLine("customerAddress is : " + reader[4]);
                    Console.WriteLine("ProductID is : " + reader[5]);
                    Console.WriteLine("price is : " + reader[6]);
                    Console.WriteLine("sizeOfProduct is : " +reader[7]);
                    Console.WriteLine("-----------------------------------------------");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void UpdateAddress(string phone , string address)
        {
            try
            {
                string connection = "Data Source=(localdb)\\ProjectModels;Initial Catalog=QueensDB;Integrated Security=True";
                SqlConnection conn = new SqlConnection(connection);
                conn.Open();
                string query = $"update Orders set customerAddress='{address}' where customerPhone='{phone}'"; 
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void deleteOrder(int orderID)
        {
            try
            {
                string connection = "Data Source=(localdb)\\ProjectModels;Initial Catalog=QueensDB;Integrated Security=True";
                SqlConnection conn = new SqlConnection(connection);
                conn.Open();
                string query = $"delete Orders where orderID={orderID}";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void updateOrderAddress(string Phone,string Address)
        {
            try
            {
                string connection = "Data Source=(localdb)\\ProjectModels;Initial Catalog=QueensDB;Integrated Security=True";
                SqlConnection conn = new SqlConnection(connection);
                conn.Open();
                string query = $"update Orders set customerAddress=@Address where customerPhone=@Phone"; 
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Address", Address);
                cmd.Parameters.AddWithValue("@Phone", Phone);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}