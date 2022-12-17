# DB
This my first C# Windows Form application that allows you to view and manage workers in a MySQL database. The application has a main form (Form1) that displays a list of workers in a list box and displays their details in text boxes when a worker is selected. The main form also has a button that opens a new form (AddWorkerForm) that allows you to add a new worker to the database.

The main form establishes a connection to the MySQL database when it is initialized and retrieves the list of workers from the workers table. When a worker is selected in the list box, the form retrieves the worker's details from the workers table and displays them in the text boxes.

The AddWorkerForm form allows you to enter the details of a new worker and save them to the database when the "Save" button is clicked. The form inserts the new worker into the workers table and closes when the operation is successful.

The code uses the MySqlConnection class to establish a connection to the MySQL database and the MySqlCommand class to execute SQL statements. It uses the MySqlDataReader class to retrieve data from the database and the DialogResult class to handle the result of the ShowDialog() method when the AddWorkerForm form is closed.

# Workers table Structure
+-------------+--------------+------+-----+---------+----------------+
| Field       | Type         | Null | Key | Default | Extra          |
+-------------+--------------+------+-----+---------+----------------+
| id          | int(11)      | NO   | PRI | NULL    | auto_increment |
| firstName   | varchar(255) | NO   |     | NULL    |                |
| lastName    | varchar(255) | NO   |     | NULL    |                |
| street      | varchar(255) | NO   |     | NULL    |                |
| houseNumber | int(11)      | NO   |     | NULL    |                |
| zipCode     | int(11)      | NO   |     | NULL    |                |
| positionId  | int(11)      | NO   | MUL | NULL    |                |
+-------------+--------------+------+-----+---------+----------------+

________________________________________________________________________________________________________________________________

# Workers Table Sample
+----+-----------+----------+------------------------+-------------+---------+------------+
| id | firstName | lastName | street                 | houseNumber | zipCode | positionId |
+----+-----------+----------+------------------------+-------------+---------+------------+
|  1 | Hans      | Bauer    | Konrad-Adenauer-Straße |          32 |    6712 |          1 |
|  2 | Wolfgang  | Haas     | Lauterstraße           |           8 |    1159 |          1 |
|  3 | Greta     | Heinz    | Schlossweg             |          43 |   24103 |          2 |
|  4 | Klaus     | Lange    | Stadtplatz             |          17 |   39104 |          3 |
|  5 | Rolf      | Müller   | Kirchstraße            |          92 |   19053 |          2 |
+----+-----------+----------+------------------------+-------------+---------+------------+

________________________________________________________________________________________________________________________________

# Positions Table Sample
+--------------+--------------+------+-----+---------+-------+
| Field        | Type         | Null | Key | Default | Extra |
+--------------+--------------+------+-----+---------+-------+
| positionId   | int(11)      | NO   | PRI | NULL    |       |
| positionName | varchar(255) | NO   |     | NULL    |       |
+--------------+--------------+------+-----+---------+-------+

________________________________________________________________________________________________________________________________

# Positions Table Sample
+------------+-----------------------+
| positionId | positionName          |
+------------+-----------------------+
|          1 | Software Developer    |
|          2 | Network Administrator |
|          3 | Systems Analyst       |
+------------+-----------------------+
