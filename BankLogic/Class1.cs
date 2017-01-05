using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoesBank.BankLogic
{
    /// <summary>
    ///  Represents a Bank Customer
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Represents a bank customers Unique ID
        /// </summary>
        public int CustomerID { get; set; }
        /// <summary>
        /// A customers First and Last Name
        /// </summary>
        public string CustomerName { get; set; }

    }


    namespace BankDB
    {
        public static class BankDBHelper
        {
            /// <summary>
            /// Creates Connection to DB
            /// </summary>
            /// <returns></returns>
            public static SqlConnection GetConnection()
            {
                return new SqlConnection(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=Bank;Integrated Security=True");
            }
        }
        /// <summary>
        /// Contains Database Functionality for bank customers
        /// </summary>
        public static class CustomerDB
        {
            public static List<Customer> GetCustomers()
            {
                using (SqlConnection con = BankDBHelper.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT CustomerID, Name FROM Customer";

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    List<Customer> custList = new List<Customer>();
                    while (rdr.Read())
                    {
                        Customer c = new Customer();
                        c.CustomerID = (int)rdr["CustomerID"];
                        c.CustomerName = (string)rdr["Name"];
                        custList.Add(c);
                    }
                    return custList;
                }
            }

        }
    }
}
