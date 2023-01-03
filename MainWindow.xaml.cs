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
using System.Data.SqlClient;
using System.Data;

namespace WpfAppDemoCPCBhathi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            userid.Focus();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=BHATHIYABANDARA;Initial Catalog=CPC;Integrated Security=True");
    
        private void userID_TextChanged(object sender, TextChangedEventArgs e)
        {
            userid.Focus();
        }

        private void userpw_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        

        private void loginbtn_Click(object sender, RoutedEventArgs e)
        {
            string id = userid.Text;
            string pw = userpw.Password;
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM login WHERE userID='" + userid.Text + "' AND userPW='" + userpw.Password + "'", connection);

                DataTable dt = new DataTable(); //this is creating a virtual table  
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    this.Hide();
                    new Home().Show();
                }

                else 
                {
                    MessageBox.Show("invalid login", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                    userid.Clear();
                    userpw.Clear();
                    userid.Focus();

                }


            }
            catch 
            {
                
                MessageBox.Show("connection error","Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            finally 
            {
                connection.Close();
            }
            
        }

        private void cancelbtn_Click(object sender, RoutedEventArgs e)
        {
            userid.Clear();
            userpw.Clear();

            userid.Focus();
        }

        private void userid_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key== Key.Enter) 
            {
                userpw.Focus();
            }
        }

       

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnMin_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnMax_Click(object sender, RoutedEventArgs e)
        {

        }

        private void userpw_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                loginbtn.Focus();
            }
        }






        /*
        private void btnclick(object sender, RoutedEventArgs e)
        {
            if(hi.IsChecked == true)
            {
                MessageBox.Show("hello world");
            }
            if(bye.IsChecked == true)
            {
                MessageBox.Show("bye world");
            }
        }
        */
    }
}
