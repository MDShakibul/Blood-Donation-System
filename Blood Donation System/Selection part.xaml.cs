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
    /// Interaction logic for Selection_part.xaml
    /// </summary>
    public partial class Selection_part : Window
    {
        public Selection_part()
        {
            InitializeComponent();
        }

        private void btn_person(object sender, RoutedEventArgs e)
        {
            Person ap = new Person();
            ap.Show();
            this.Close();
        }

        private void btn_bloodbank(object sender, RoutedEventArgs e)
        {
            Blood_Bank ap = new Blood_Bank();
            ap.Show();
            this.Close();
        }

        private void btn_UV(object sender, RoutedEventArgs e)
        {
            University_Blood_Group ap = new University_Blood_Group();
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
