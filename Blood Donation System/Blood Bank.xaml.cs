﻿using System;
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
    /// Interaction logic for Blood_Bank.xaml
    /// </summary>
    public partial class Blood_Bank : Window
    {
        public Blood_Bank()
        {
            InitializeComponent();
        }
        public string name, addr, cont1, cont2;

        private void button_Copy2_Click(object sender, RoutedEventArgs e)
        {
           Selection_part ap = new Selection_part();
            ap.Show();
            this.Close();
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            string connectionstring = @"Data Source=DESKTOP-171AOO2;Initial Catalog=information;Integrated Security=True";
            SqlConnection sqlcon = new SqlConnection(connectionstring);

            SqlCommand cmd = new SqlCommand("insert into blood_bank(name_of_blood_bank, address, contact_1, contact_2) values(@a,@b,@c,@d)", sqlcon);

            cmd.Parameters.Add("@a", SqlDbType.VarChar).Value = name;
            cmd.Parameters.Add("@b", SqlDbType.VarChar).Value = addr;
            cmd.Parameters.Add("@c", SqlDbType.VarChar).Value = cont1;
            cmd.Parameters.Add("@d", SqlDbType.VarChar).Value = cont2;
            
            

            sqlcon.Open();
            int rows = cmd.ExecuteNonQuery();
            if (rows > 0)
                MessageBox.Show("Save");
            sqlcon.Close();
        }

        private void button_Copy1_Click(object sender, RoutedEventArgs e)
        {
            this.Width = 780;
            this.Height = 460;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string s = "";
            name = txt_name.Text;
            s = "Name: " + txt_name.Text;
            addr = txt_adr.Text;
            s += "\nAddress: " + txt_adr.Text;
            cont1 = txt_cnt1.Text;
            s += "\nContact 1: " + txt_cnt1.Text;
            cont2 = txt_cnt2.Text;
            s += "\nContact 2: " + txt_cnt2.Text;

            txt_details.Text = s;
            this.Width = 1092;
            this.Height = 410;
        }
    }
}
