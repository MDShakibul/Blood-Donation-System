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
    /// Interaction logic for Person.xaml
    /// </summary>
    public partial class Person : Window
    {
        public Person()
        {
            InitializeComponent();
        }
        public string first, last, par, pre, gen, mar, blood, town, idd, pas, cnt;

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Selection_part ap = new Selection_part();
            ap.Show();
            this.Close();
        }

        string dobirth;



        private void btn_close(object sender, RoutedEventArgs e)
        {
            this.Width = 855;
            this.Height = 740;
        }

        

        private void btn_add(object sender, RoutedEventArgs e)
        {
            string s = "";
            first = txt_first.Text;
            last = txt_last.Text;
            pre = txt_present.Text;
            par = txt_par.Text;
            cnt = txt_num.Text;
            s = "Name: " + txt_first.Text + " " + txt_last.Text;
            s += "\nPresent: " + txt_present.Text;
            s += "\nParmanent: " + txt_par.Text;
            s += "\nContact: " + txt_num.Text;
            if (rdo_male.IsChecked == true)
            {
                gen = "Male";
                s += "\nGender: Male";
            }
            else
            {
                gen = "Female";
                s += "\nGender: Female";
            }

            if (chk_married.IsChecked == true)
            {
                mar = "Married";
                s += "\nMarried: Yes";
            }
            else
            {
                mar = "Unmarried";
                s += "\nMarried: No";
            }
            var a = (ComboBoxItem)comboBox.SelectedItem;
            var bld = a.Content.ToString();
            blood = bld;
            s += "\nBlood Group: " + bld;

            var b = (ListBoxItem)listBox.SelectedItem;
            var twn = b.Content.ToString();
            town = twn;
            s += "\nTown: " + twn;

            s += "\nID: " + id.Text;
            idd = id.Text;
            s += "\nPassword: " + pass.Password;
            pas = pass.Password;

            s += "\nDOB: " + dob.SelectedDate.Value.ToShortDateString();
            dobirth = dob.SelectedDate.Value.ToString();

            txt_details.Text = s;
            this.Width = 1175;
            this.Height = 740;
        }
        private void btn_confrim(object sender, RoutedEventArgs e)
        {
            string connectionstring = @"Data Source=DESKTOP-171AOO2;Initial Catalog=information;Integrated Security=True";
            SqlConnection sqlcon = new SqlConnection(connectionstring);

            SqlCommand cmd = new SqlCommand("insert into person(first_name,last_name,pre_address, par_address, gender,married, Blood_group, contact, Member_id, Password,Town,dob) values(@a,@b,@c,@d,@e,@f,@g,@h,@i,@j,@k,@l)", sqlcon);

            cmd.Parameters.Add("@a", SqlDbType.VarChar).Value = first;
            cmd.Parameters.Add("@b", SqlDbType.VarChar).Value = last;
            cmd.Parameters.Add("@c", SqlDbType.VarChar).Value = pre;
            cmd.Parameters.Add("@d", SqlDbType.VarChar).Value = par;
            cmd.Parameters.Add("@e", SqlDbType.VarChar).Value = gen;
            cmd.Parameters.Add("@f", SqlDbType.VarChar).Value = mar;
            cmd.Parameters.Add("@g", SqlDbType.VarChar).Value = blood;
            cmd.Parameters.Add("@h", SqlDbType.VarChar).Value = cnt;
            cmd.Parameters.Add("@i", SqlDbType.VarChar).Value = idd;
            cmd.Parameters.Add("@j", SqlDbType.VarChar).Value = pas;
            cmd.Parameters.Add("@k", SqlDbType.VarChar).Value = town;
            cmd.Parameters.Add("@l", SqlDbType.Date).Value = dob.SelectedDate.Value.ToShortDateString();

            sqlcon.Open();
            int rows = cmd.ExecuteNonQuery();
            if (rows > 0)
                MessageBox.Show("Save");
            sqlcon.Close();

        }
    }
    }

