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
    /// Interaction logic for Search2.xaml
    /// </summary>
    public partial class Search2 : Window
    {
        public Search2()
        {
            InitializeComponent();
        }
        string bld_bank;
        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            For_getting_blood ap = new For_getting_blood();
            ap.Show();
            this.Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string connectionstring = @"Data Source=DESKTOP-171AOO2;Initial Catalog=information;Integrated Security=True";
            SqlConnection sqlcon = new SqlConnection(connectionstring);
            sqlcon.Open();
            string commandstring = "select * from blood_bank  ";
            SqlCommand sqlcmd = new SqlCommand(commandstring, sqlcon);
            SqlDataReader read = sqlcmd.ExecuteReader();
            msg.Text = "User Details: ";
            var a = (ComboBoxItem)comboBox.SelectedItem;
            var bank = a.Content.ToString();
            bld_bank = bank;
            
            while (read.Read())
            {
                if (read[0].ToString() == bld_bank)
                {
                   
                    msg.Text += "\nContact: " + read[2].ToString();
                    msg.Text += "\nContact: " + read[3].ToString();

                }

            }
        }
    }
}
