using JoesBank.BankLogic;
using JoesBank.BankLogic.BankDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankingApp
{
    public partial class frmBankWelcome : Form
    {
        public frmBankWelcome()
        {
            InitializeComponent();
        }

        private void frmBankWelcome_Load(object sender, EventArgs e)
        {
            GetAndDisplayAllCustomers();
        }
        /// <summary>
        /// Gets all bank customers from database
        /// Displays all customers in listbox
        /// </summary>
        private void GetAndDisplayAllCustomers()
        {
            try
            {
                List<Customer> customers = CustomerDB.GetCustomers();

                lstCustomer.DataSource = customers;
                lstCustomer.DisplayMember = "CustomerName";
                lstCustomer.ValueMember = "CustomerID";
            }
            catch(SqlException ex)
            {
                // log error
                MessageBox.Show("There was a server issue, please try again later");
            }
        }

        private void lstCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstCustomer.SelectedIndex < 0)
                return;
            Customer c = (Customer)lstCustomer.SelectedItem;

            MessageBox.Show(c.CustomerID.ToString());

        }
    }
}
