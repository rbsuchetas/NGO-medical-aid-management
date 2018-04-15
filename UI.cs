using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class UI : Form
    {
        string Query;
        public Form1 pr;
        public UI(string query)
        {
            InitializeComponent();
            Query = query;
        }

        private void UI_Load(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand(Query, pr.connection);
            if(pr.OpenConnection() == true)
            {
                MySqlDataReader dr = cmd.ExecuteReader();
                if(dr.HasRows)
                {
                    while(dr.Read())
                    {
                        ListViewItem itm = new ListViewItem(dr["medicine"] + "");
                        itm.SubItems.Add(dr["doctor"] + "");
                        itm.SubItems.Add(dr["contact_no"] + "");
                        listView1.Items.Add(itm);
                    }
                }
                pr.CloseConnection();
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            string query = "SELECT * from meds WHERE medicine = " + "'" + listView1.Items[listView1.FocusedItem.Index].Text + "'";
            //string mid = "", med = "", comp = "", pri = "", dos = "", ngo = "";
            if (pr.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, pr.connection);
                MySqlDataReader dr = cmd.ExecuteReader();
                
                if(dr.HasRows)
                {
                    while(dr.Read())
                    {
                       medicinedata md = new medicinedata(dr["mid"] + "", dr["medicine"] + "", dr["company"] + "", dr["dosage"] + "", dr["price"] + "", dr["ngo_price"] + "");
                       md.Show();
                    }
                }
                pr.CloseConnection();

            }
          
           
        }
    }
}
