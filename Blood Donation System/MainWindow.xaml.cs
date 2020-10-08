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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;

namespace Blood_Donation_System
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_join(object sender, RoutedEventArgs e)
        {
             Selection_part ap = new Selection_part();
            ap.Show();
            this.Close();
        }

        private void btn_login(object sender, RoutedEventArgs e)
        {
            string connectionstring = @"Data Source=DESKTOP-171AOO2;Initial Catalog=information;Integrated Security=True";
            SqlConnection sqlcon = new SqlConnection(connectionstring);
            sqlcon.Open();
            string commandstring = "select * from person where Member_id = '" + txt_id.Text + "'";
            SqlCommand sqlcmd = new SqlCommand(commandstring, sqlcon);
            SqlDataReader read = sqlcmd.ExecuteReader();

            int access = -1;
            while (read.Read())
            {
                if (read[8].ToString() == txt_id.Text && read[9].ToString() == pass_pass.Password)
                {
                    access = 1;
                    For_getting_blood lo = new For_getting_blood();
                    MessageBox.Show("Login Successfull");
                    lo.Show();
                    this.Close();
                }


            }
            if (access == -1)
            {
                msg.Text = "Invalid Userid or password";
                MessageBox.Show("Login Failed");
            }

            sqlcon.Close();
        }

        private void btn_f(object sender, RoutedEventArgs e)
        {
            msg.Text = " ";
            txt_id.Text = "";
            pass_pass.Password = "";

        }
    }
}
