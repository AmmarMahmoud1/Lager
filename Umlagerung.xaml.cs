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
using System.Data.OleDb;
using System.Security.Principal;
using Microsoft.Win32;
using Lager.Models;
using System.IO;

namespace Lager
{
    /// <summary>
    /// Interaction logic for Umlagerung.xaml
    /// </summary>
    public partial class Umlagerung : Window
    {
        
        public new System.Windows.SizeToContent SizeToContent { get; set; }
        public List<Product> listProduct = new List<Product>();
        public Umlagerung()
        {
            InitializeComponent();
            // Automatically resize height and width relative to content
            this.SizeToContent = SizeToContent.WidthAndHeight;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //computerName.Text = Environment.MachineName;
        }

        

        private void Load_Data_Click_1(object sender, RoutedEventArgs e)
        {

           



        }


       

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            textEnter.Text += b.Content.ToString();


        }

        private void MaterialNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Qntity_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MaterialNumber.Text = textEnter.Text;
            textEnter.Text = " ";
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Qntity.Text = textEnter.Text;
            textEnter.Text = " ";
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {

        }

        public static List<Product> LoadCSV(string csvfile)
        {
            var query = from l in File.ReadAllLines(csvfile)
                        let data = l.Split(',')
                        select new Product
                        {
                            productTitle = data[0],
                            groupId = data[1],
                            price = data[2],
                            size = data[3],
                            description = data[4]


                        };
           
            return query.ToList();

        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.ShowDialog();
            sapFile.Text = dlg.FileName;
        }

        private void sapData_Click(object sender, RoutedEventArgs e)
        {
            sapDataGrid.ItemsSource = LoadCSV(sapFile.Text);
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Qntity.Text += textEnter.Text;
            textEnter.Text = " ";
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            MaterialNumber.Text += textEnter.Text;
            textEnter.Text = " ";
        }
    }  
}
