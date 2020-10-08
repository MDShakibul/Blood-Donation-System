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
    /// Interaction logic for University_Blood_Group.xaml
    /// </summary>
    public partial class University_Blood_Group : Window
    {
        public University_Blood_Group()
        {
            InitializeComponent();
        }

        public string name, UV, person1, person2, cont1, cont2;

        private void button_Copy2_Click(object sender, RoutedEventArgs e)
        {
            this.Width = 720;
            this.Height = 500;
        }

        private void button_Copy1_Click(object sender, RoutedEventArgs e)
        {
            string connectionstring = @"Data Source=DESKTOP-171AOO2;Initial Catalog=information;Integrated Security=True";
            SqlConnection sqlcon = new SqlConnection(connectionstring);

            SqlCommand cmd = new SqlCommand("insert into university(name_of_uvblood_group, uv_name, person_1, person_2, contact_1, contact_2) values(@a,@b,@c,@d,@e,@f)", sqlcon);

            cmd.Parameters.Add("@a", SqlDbType.VarChar).Value = name;
            cmd.Parameters.Add("@b", SqlDbType.VarChar).Value = UV;
            cmd.Parameters.Add("@c", SqlDbType.VarChar).Value = person1;
            cmd.Parameters.Add("@d", SqlDbType.VarChar).Value = person2;
            cmd.Parameters.Add("@e", SqlDbType.VarChar).Value = cont1;
            cmd.Parameters.Add("@f", SqlDbType.VarChar).Value = cont2;



            sqlcon.Open();
            int rows = cmd.ExecuteNonQuery();
            if (rows > 0)
                MessageBox.Show("Save");
            sqlcon.Close();
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            Selection_part ap = new Selection_part();
            ap.Show();
            this.Close();
        }

        private void btn_add(object sender, RoutedEventArgs e)
        {
            string s = "";
            name = txt_name.Text;
            s = "Name of Blood Donation Group : " + txt_name.Text;
            var a = (ComboBoxItem)comboBox.SelectedItem;
            var versity = a.Content.ToString();
             UV= versity;
            s += "\nBlood Group: " + UV;
            
            
            person1 = txt_p1.Text;
            s += "\nPerson 1: " + txt_p1.Text;
            cont1 = txt_fixdc.Text;
            s += "\nContact 2: " + txt_fixdc.Text;
            person2 = txt_p2.Text;
            s += "\nPerson 2: " + txt_p2.Text;
            cont2 = txt_cnt2.Text;
            s += "\nContact 2: " + txt_cnt2.Text;

            txt_details.Text = s;
            this.Width = 1100;
            this.Height = 550;
        }
    }
}
