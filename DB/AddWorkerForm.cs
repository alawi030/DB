using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace DB
{
    public partial class AddWorkerForm : Form
    {
        private MySqlConnection connection;

        public AddWorkerForm(MySqlConnection connection)
        {
            InitializeComponent();
                    this.connection = connection;

        }


        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string firstName = firstNameBox.Text;
            string lastName = lastNameBox.Text;
            string street = streetBox.Text;
            int houseNumber = Convert.ToInt32(houseNumberBox.Text);
            string zipCode = zipCodeBox.Text;
            int positionId = Convert.ToInt32(zipCodeBox.Text);

            string insertSql = "INSERT INTO workers (firstName, lastName, street, houseNumber, zipCode, positionId) " +
                               "VALUES (@firstName, @lastName, @street, @houseNumber, @zipCode, @positionId)"; MySqlCommand insertSqlCommand = new MySqlCommand(insertSql, connection);

            insertSqlCommand.Parameters.AddWithValue("@firstName", firstName);
            insertSqlCommand.Parameters.AddWithValue("@lastName", lastName);
            insertSqlCommand.Parameters.AddWithValue("@street", street);
            insertSqlCommand.Parameters.AddWithValue("@houseNumber", houseNumber);
            insertSqlCommand.Parameters.AddWithValue("@zipCode", zipCode);
            insertSqlCommand.Parameters.AddWithValue("@positionId", positionId);

            int rowsaffected = insertSqlCommand.ExecuteNonQuery();

            if (rowsaffected > 0)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Error adding Worker.");
            }
        }
    }
}
