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

namespace Lager
{
    /// <summary>
    /// Interaction logic for Etiket.xaml
    /// </summary>
    public partial class Etiket : Window
    {
        public Etiket()
        {
            MainWindow main = new MainWindow();
            
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
           
        }

        public void printDG(DataGrid dataGrid, string title)
        {
            PrintDialog printDialog = new PrintDialog();
        }
    }
}
