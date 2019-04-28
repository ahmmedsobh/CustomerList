using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerList
{
    public partial class Form1 : Form
    {
        // create date table to save customers data
        DataTable Customers = new DataTable();
        public Form1()
        {
            InitializeComponent();
            // add columns to customer data table 
            Customers.Columns.Add("Id");
            Customers.Columns.Add("Name");
            Customers.Columns.Add("Address");
            Customers.Columns.Add("Phone");

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Button btnAddEdit = sender as Button;
           // add customer row to customers
           DataRow row =  Customers.NewRow();
           // check on feilds 
           if(txtId.Text == string.Empty)
            {
                MessageBox.Show("enter id");
                return;
            }
            if (txtName.Text == string.Empty)
            {
                MessageBox.Show("enter name");
                return;

            }
            if (txtAddress.Text == string.Empty)
            {
                MessageBox.Show("enter address");
                return;

            }
            if (txtPhone.Text == string.Empty)
            {
                MessageBox.Show("enter phone");
                return;

            }
            // add customer to customers data table
            clsCustomers customer = new clsCustomers()
            {
                Id = Convert.ToInt32(txtId.Text),
                Name = txtName.Text,
                Address = txtAddress.Text,
                Phone = txtPhone.Text


            };

            row[0] = customer.Id;
            row[1] = customer.Name;
            row[2] = customer.Address;
            row[3] = customer.Phone;
            Customers.Rows.Add(row);
            dgvCustomerList.DataSource = Customers;
            if(btnAddEdit.Text == "Add")
            {
                //show add message
                MessageBox.Show("customer added successfully");
            }
            else
            {
                //show add message
                MessageBox.Show("customer edited successfully");
            }
            






        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void DgvCustomerList_Click(object sender, EventArgs e)
        {
            // add selected customer to customer details
            txtId.Text = dgvCustomerList.CurrentRow.Cells[0].Value.ToString();
            txtName.Text = dgvCustomerList.CurrentRow.Cells[1].Value.ToString();
            txtAddress.Text = dgvCustomerList.CurrentRow.Cells[2].Value.ToString();
            txtPhone.Text = dgvCustomerList.CurrentRow.Cells[3].Value.ToString();

        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            // delete row then add new row 
            Customers.Rows.RemoveAt(dgvCustomerList.CurrentRow.Index);
            Button1_Click(sender,e);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            // delete row from customers
            Customers.Rows.RemoveAt(dgvCustomerList.CurrentRow.Index);
            // show delete message 
            MessageBox.Show("customer deleted");
        }
    }
}
