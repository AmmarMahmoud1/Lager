using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
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
using static Lager.Login;

namespace Lager
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public List<Previlige> previligeList =new List<Previlige>();

        public Login()
        {
            InitializeComponent();
        }
        public class Previlige
        {
            public string? Rechnername { get; set; }
            public bool Etikettendruck { get; set; }
            public bool Umlagerung { get; set; }
            public bool Wareneingang { get; set; }
            public bool SAP_Daten { get; set; }

        }
        public void Button_Click(object sender, RoutedEventArgs e)
        {
            string computerName = System.Environment.MachineName;
            List<Previlige> previleges;
            string conn = "Provider = Microsoft.ACE.OLEDB.12.0;" + @"Data Source = C:\Users\Ammar\Documents\Falken.mdb";
            using(OleDbConnection connection = new OleDbConnection(conn))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand("Select * from Berechtigungen", connection);
                var DataReader = command.ExecuteReader();
                previleges = GetList<Previlige>(DataReader);
                
            }
            if(previleges !=null)
            {
                foreach (var item in previleges)
                {
                    previligeList.Add(item);
                }
            }
            MainWindow main = new MainWindow();
            Umlagerung umlagerung = new Umlagerung();
            foreach (var item in previligeList)
            {
                if (item.Rechnername == computerName)
                {
                    if (item.Umlagerung == true)
                    {
                        main.umlagerung.IsEnabled = true;
                    }
                    else { main.umlagerung.IsEnabled = false; }

                    if (item.Wareneingang == true)
                    {
                        main.Wareneingang.IsEnabled = true;
                    }
                    else { main.Wareneingang.IsEnabled = false; }
                    if (item.Etikettendruck == true)
                    {
                        main.Etikettendruck.IsEnabled = true;
                    }
                    else { main.Etikettendruck.IsEnabled = false; }
                    if(item.SAP_Daten == true)
                    {
                        umlagerung.sapData.IsEnabled = true;
                    }
                    else { umlagerung.sapData.IsEnabled= false; }
                }
            }
            main.Show();
            this.Close();
            
        }

        public List<T> GetList<T>(IDataReader reader)
        {
            List<T> list = new List<T>();
            while (reader.Read())
            {
                var type = typeof(T);
                T obj = (T)Activator.CreateInstance(type);
                foreach(var prop in type.GetProperties())
                {
                    var propType = prop.PropertyType;
                    prop.SetValue(obj, Convert.ChangeType(reader[prop.Name].ToString(), propType));
                }
                list.Add(obj);
            }
            return list;

        }
    }
}
