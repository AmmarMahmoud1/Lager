using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Printing;
using System.Runtime.CompilerServices;
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
using Lager.Models;
using Microsoft.Win32;

namespace Lager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial  class MainWindow : Window
    {
        public MainWindow()
        {
          
            InitializeComponent();
            string computerName = System.Environment.MachineName;
            this.SizeToContent = System.Windows.SizeToContent.WidthAndHeight;
            this.Loaded += MainWindow_Loaded;
          
            myDate.Text = System.DateTime.Now.ToString();
            Login log = new Login();
            


        }
        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.MinWidth = this.Width;
            this.MinHeight = this.Height;
        }


        

        
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Umlagerung umlagerung = new Umlagerung();
            string computerName = System.Environment.MachineName;
            
            OleDbConnection dbconnection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0;" + @"Data Source = C:\Users\Ammar\Documents\Falken.mdb"
                                       );
            dbconnection.Open();
            OleDbCommand command = new("Select Rechner_name, von_Lager, an_Lager from Rechner_zu_Lagerort where Rechner_name=@computerName ", dbconnection);
            command.Parameters.Add("@computerName", OleDbType.LongVarChar, 30).Value = computerName;


           umlagerung.dg.ItemsSource = command.ExecuteReader();
            
            umlagerung.Show();
            
        }

      

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Close();
        }

        private void dateBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Etikettendruck_Click(object sender, RoutedEventArgs e)
        {
            Etiket etiket = new Etiket();
            
            
            etiket.Show();

        }
    }
}
