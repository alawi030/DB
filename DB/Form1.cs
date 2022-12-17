using MySql.Data.MySqlClient;


namespace DB
{
    public partial class Form1 : Form
    {
        public MySqlConnection connection;

        public Form1()
        {
            InitializeComponent();
            string connectionString = "server=localhost;user=root;password='';database=company";
            connection = new MySqlConnection(connectionString);
            connection.Open();

            Workers.Items.Clear();

            MySqlCommand command = new MySqlCommand("SELECT firstName, lastName FROM Workers", connection);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string firstName = reader["firstName"].ToString();
                string lastName = reader["lastName"].ToString();

                Workers.Items.Add(firstName + " " + lastName);
            }
            reader.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void Workers_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = Workers.SelectedItem.ToString();

            string[] names = name.Split(' ');
            string firstName = names[0];
            string lastName = names[1];

            MySqlCommand workersCommand = new MySqlCommand("SELECT * FROM Workers WHERE firstName = @firstName AND lastName = @lastName", connection);
            workersCommand.Parameters.AddWithValue("@firstName", firstName);
            workersCommand.Parameters.AddWithValue("@lastName", lastName);
            MySqlDataReader workersReader = workersCommand.ExecuteReader();

            if (workersReader.Read())
            {
                idLabel.Text = workersReader["ID"].ToString();
                firstNameBox.Text = workersReader["firstName"].ToString();
                lastNameBox.Text = workersReader["lastName"].ToString();
                streetBox.Text = workersReader["street"].ToString();
                houseNumberBox.Text = workersReader["houseNumber"].ToString();
                zipCodeBox.Text = workersReader["zipCode"].ToString();
                positionIdLabel.Text = workersReader["positionId"].ToString();

                int positionId = Convert.ToInt32(workersReader["positionId"]);

                workersReader.Close();

                MySqlCommand positionsCommand = new MySqlCommand("SELECT positionName From positions WHERE positionId = @positionId", connection);
                positionsCommand.Parameters.AddWithValue("@positionId", positionId);

                MySqlDataReader positionReader = positionsCommand.ExecuteReader();

                if (positionReader.Read())
                {
                    positionBox.Text = positionReader["positionName"].ToString();
                }
                positionReader.Close();

            }
        }

        private void addWorkerButton_Click(object sender, EventArgs e)
        {
            using (AddWorkerForm form = new AddWorkerForm(connection))
            {
                DialogResult result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string firstName = form.firstNameBox.Text;
                    string lastName = form.lastNameBox.Text;
                    string street = form.streetBox.Text;
                    int houseNumber = Convert.ToInt32(form.houseNumberBox.Text);
                    string zipCode = form.zipCodeBox.Text;
                    int positionId = Convert.ToInt32(form.zipCodeBox.Text);

                    string insertSql = "INSERT INTO workers (firstName, lastName, street, houseNumber, zipCode, postionId)" + "VALUES (@firstName, @lastName, @street, @houseNumber, @zipCode, @positionId)";
                    MySqlCommand insertSqlCommand = new MySqlCommand(insertSql, connection);

                    insertSqlCommand.Parameters.AddWithValue("@firstName", firstName);
                    insertSqlCommand.Parameters.AddWithValue("@lastName", lastName);
                    insertSqlCommand.Parameters.AddWithValue("@street", street);
                    insertSqlCommand.Parameters.AddWithValue("@houseNumber", houseNumber);
                    insertSqlCommand.Parameters.AddWithValue("@zipCode", zipCode);
                    insertSqlCommand.Parameters.AddWithValue("@positionId", positionId);

                    int rowsaffected = insertSqlCommand.ExecuteNonQuery();

                    if (rowsaffected > 0)
                    {
                        MessageBox.Show("Worker added Successfully!");
                        RefreshWorkersList();
                    }
                    else
                    {
                        MessageBox.Show("Error adding Worker.");
                    }

                }
            }
        }
        private void RefreshWorkersList()
        {
            Workers.Items.Clear();

            MySqlCommand cmd = new MySqlCommand("SELECT firstName, lastName FROM workers", connection);

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string firstName = reader["firstName"].ToString();
                string lastName = reader["lastName"].ToString();

                Workers.Items.Add(firstName + " " + lastName);
            }
            reader.Close();
        }
    }
}
        
