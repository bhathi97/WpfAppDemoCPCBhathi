using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace WpfAppDemoCPCBhathi.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : System.Windows.Window
    {
        public LoginView()
        {
            InitializeComponent();
            userID.Focus();
        }

        private void Window_mouseDown(object sender, MouseEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed) 
            {
                DragMove();
            }
        }

        private void btnMin_Click(object sender, RoutedEventArgs e)
        {
            WindowState= WindowState.Minimized;
        }

        private void btnMax_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void userID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                userPW.Focus();
            }


        }
        //temperary
        SqlConnection connection = new SqlConnection(@"Data Source=BHATHIYABANDARA;Initial Catalog=CPC;Integrated Security=True");
        private void btnLog_Click(object sender, RoutedEventArgs e)
        {
            string id = userID.Text;
            string pw = userPW.Password;
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM login WHERE userID='" + userID.Text + "' AND userPW='" + userPW.Password + "'", connection);

                DataTable dt = new DataTable(); //this is creating a virtual table  
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    this.Hide();
                    HomeView win2 = new HomeView();
                    win2.Show();
                }

                else
                {
                    MessageBox.Show("invalid login", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                    userID.Clear();
                    userPW.Clear();
                    userID.Focus();

                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            finally
            {
                connection.Close();
            }

        }
    
    }
}
