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
using MySql.Data.MySqlClient;
using System.Data;
namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            String sql = "Select * from books";
            GetQuery(sql);
        }
        public void GetQuery(String sql)
        {
            String connectionString = "server=localhost;user=root;password=alina890;database=NewLibrary";
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dataGrid.DataContext = dt;
            conn.Close();
        }

        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            String searchText = search.Text;
            String sql = "Select * from books where nameBook like '%"+searchText+"%'";
            GetQuery(sql);
        }


        private void edit_DropDownClosed(object sender, EventArgs e)
        {
            String option = edit.Name;
            test.Content = option;
            switch (option)
            {
                case "del":
                    btn_del.Visibility = Visibility.Visible;
                    break;
                case "add":
                    btn_del.Visibility = Visibility.Hidden;
                    break;
                case "upd":
                    btn_del.Visibility = Visibility.Hidden;
                    break;
            }
        }
    }
}
