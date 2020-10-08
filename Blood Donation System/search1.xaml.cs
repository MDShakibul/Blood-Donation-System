using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;

namespace Blood_Donation_System
{
    /// <summary>
    /// Interaction logic for search1.xaml
    /// </summary>
    public partial class search1 : Window
    {
        public search1()
        {
            InitializeComponent();
        }
        string bld_grp;
        private void btn_search(object sender, RoutedEventArgs e)
        {
            string connectionstring = @"Data Source=DESKTOP-171AOO2;Initial Catalog=information;Integrated Security=True";
            SqlConnection sqlcon = new SqlConnection(connectionstring);
            sqlcon.Open();
            string commandstring = "select * from person  ";
            SqlCommand sqlcmd = new SqlCommand(commandstring, sqlcon);
            SqlDataReader read = sqlcmd.ExecuteReader();
            msg.Text = "User Details: ";
            var a = (ComboBoxItem)comboBox.SelectedItem;
            var bld = a.Content.ToString();
            bld_grp = bld;
            
            while (read.Read())
            {
                if (read[6].ToString() == bld_grp)
                {
                    msg.Text += "\nName: " + read[0].ToString() + " " + read[1].ToString();
                    msg.Text += "\nContact: " + read[7].ToString();
                    msg.Text += "\nTown: " + read[10].ToString();

                }

            }
        }

        private void button_Copy1_Click(object sender, RoutedEventArgs e)
        {
            For_getting_blood ap = new For_getting_blood();
            ap.Show();
            this.Close();
        }
    }
}
