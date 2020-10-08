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
    /// Interaction logic for setting_blood_bank.xaml
    /// </summary>
    public partial class setting_blood_bank : Window
    {
        public setting_blood_bank()
        {
            InitializeComponent();
        }

        string bld_bank;

        private void button_Copy2_Click(object sender, RoutedEventArgs e)
        {
            string connectionstring = @"Data Source=DESKTOP-171AOO2;Initial Catalog=information;Integrated Security=True";
            SqlConnection sqlcon = new SqlConnection(connectionstring);
            var a = (ComboBoxItem)comboBox.SelectedItem;
            var bld = a.Content.ToString();
            bld_bank = bld;

            string commandstring = "update blood_bank set contact_1=@p  where name_of_blood_bank='" + bld_bank + "'";
            SqlCommand sqlcmd = new SqlCommand(commandstring, sqlcon);
            sqlcmd.Parameters.Add("@p", SqlDbType.VarChar).Value = txt_cnt.Text;
            //sqlcmd.Parameters.Add("@par", SqlDbType.VarChar).Value = txt_parmanent_address.Text;

            sqlcon.Open();
            int rows = sqlcmd.ExecuteNonQuery();
            sqlcon.Close();

            if (rows == 1)
                MessageBox.Show("Information Has Updated.");
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mr = MessageBox.Show("Do You Really Want To Delete?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            switch (mr)
            {
                case MessageBoxResult.Yes:
                    //MessageBox.Show("Entered");
                    string connectionstring = @"Data Source=DESKTOP-171AOO2;Initial Catalog=information;Integrated Security=True";
                    SqlConnection sqlcon = new SqlConnection(connectionstring);
                    var a = (ComboBoxItem)comboBox.SelectedItem;
                    var bld = a.Content.ToString();
                    bld_bank = bld;

                    string commandstring = "delete from blood_bank where name_of_blood_bank= '" + bld_bank + "'";
                    SqlCommand sqlcmd = new SqlCommand(commandstring, sqlcon);

                    sqlcon.Open();
                    int rows = sqlcmd.ExecuteNonQuery();
                    sqlcon.Close();

                    if (rows > 0)
                        MessageBox.Show("Information Has Deleted.");



                    break;
                case MessageBoxResult.No:
                    break;
            }
        }

        private void button_Copy3_Click(object sender, RoutedEventArgs e)
        {
            For_getting_blood ap = new For_getting_blood();
            ap.Show();
            this.Close();
        }
    }
}
