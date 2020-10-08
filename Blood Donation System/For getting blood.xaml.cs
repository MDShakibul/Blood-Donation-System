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

namespace Blood_Donation_System
{
    /// <summary>
    /// Interaction logic for For_getting_blood.xaml
    /// </summary>
    public partial class For_getting_blood : Window
    {
        public For_getting_blood()
        {
            InitializeComponent();
        }

        private void btn_getting1(object sender, RoutedEventArgs e)
        {
            search1 ap = new search1();
            ap.Show();
            this.Close();
        }

        private void btn_getting2(object sender, RoutedEventArgs e)
        {
            Search2 ap = new Search2();
            ap.Show();
            this.Close();
        }

        private void btn_getting3(object sender, RoutedEventArgs e)
        {
            search3 ap = new search3();
            ap.Show();
            this.Close();
        }

        private void btn_setper(object sender, RoutedEventArgs e)
        {
            setting_person ap = new setting_person();
            ap.Show();
            this.Close();
        }

        private void btn_setbank(object sender, RoutedEventArgs e)
        {
            setting_blood_bank ap = new setting_blood_bank();
            ap.Show();
            this.Close();
        }

        private void btn_setUV(object sender, RoutedEventArgs e)
        {
            setting_uv_blood_bank ap = new setting_uv_blood_bank();
            ap.Show();
            this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MainWindow ap = new MainWindow();
            ap.Show();
            this.Close();
        }
    }
}
