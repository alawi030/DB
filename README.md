# DB
This my first C# Windows Form application that allows you to view and manage workers in a MySQL database. The application has a main form (Form1) that displays a list of workers in a list box and displays their details in text boxes when a worker is selected. The main form also has a button that opens a new form (AddWorkerForm) that allows you to add a new worker to the database.

The main form establishes a connection to the MySQL database when it is initialized and retrieves the list of workers from the workers table. When a worker is selected in the list box, the form retrieves the worker's details from the workers table and displays them in the text boxes.

The AddWorkerForm form allows you to enter the details of a new worker and save them to the database when the "Save" button is clicked. The form inserts the new worker into the workers table and closes when the operation is successful.

The code uses the MySqlConnection class to establish a connection to the MySQL database and the MySqlCommand class to execute SQL statements. It uses the MySqlDataReader class to retrieve data from the database and the DialogResult class to handle the result of the ShowDialog() method when the AddWorkerForm form is closed.
