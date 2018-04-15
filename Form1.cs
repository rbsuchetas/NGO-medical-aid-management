using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        Random a = new Random();
        int id;
        public Form1()
        {
            InitializeComponent();
            id = a.Next(1116, 9999);
            this.Text = "Patient - " + id;
            server = "localhost";
            database = "dbms";
            uid = "root";
            password = "root";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           /* if (OpenConnection() == true)
                MessageBox.Show("Connection successfull");
            else
                MessageBox.Show("Connection not successfull");*/

            string query = "SELECT ngo_name from ngo";
            string query2 = "SELECT DISTINCT disease FROM diagnosis"; 
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlCommand cmd2 = new MySqlCommand(query2, connection);
            if (OpenConnection() == true)
            {
                MySqlDataReader dr = cmd.ExecuteReader();
                if(dr.HasRows)
                {
                    while(dr.Read())
                    {
                        comboBox2.Items.Add(dr["ngo_name"] + "");
                    }
                }
                CloseConnection();
            }

            if (OpenConnection() == true)
            {
                MySqlDataReader dr = cmd2.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        comboBox3.Items.Add(dr["disease"] + "");
                    }
                }
                CloseConnection();
            }



        }

        int boolToint(bool val)
        {
            if (val == true)
                return 1;
            else
                return 0;
        }

        public void InserttoRecord()
        {
            string query = "INSERT INTO records VALUES (" + id + "," + "'" +textBox1.Text + "'" + "," + numericUpDown1.Value + "," + "'" + comboBox1.Text + "'" + "," + "'" + comboBox3.Text + "'" + "," + boolToint(checkBox1.Checked) + ")";
            //MessageBox.Show(query);

            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();
                MessageBox.Show("Patient Record Saved Sucessfully!");


                //close connection
                this.CloseConnection();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

            InserttoRecord();

            if (comboBox3.Text.Length > 0)
            {
                string query = "SELECT * FROM diagnosis WHERE disease = " + "'" + comboBox3.Text + "'";
                UI ui = new UI(query);
                ui.pr = this;
                ui.Show();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            comboBox2.Visible = checkBox1.Checked;
        }
    }
}
