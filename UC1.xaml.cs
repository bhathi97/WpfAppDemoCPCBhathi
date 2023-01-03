using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Xml.Linq;

namespace WpfAppDemoCPCBhathi
{
    /// <summary>
    /// Interaction logic for UC1.xaml
    /// </summary>
    public partial class UC1 : UserControl
    {
        public UC1()
        {
            InitializeComponent();
            userID.Focus();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=BHATHIYABANDARA;Initial Catalog=CPC;Integrated Security=True");


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void userID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                userName.Focus();
            }
        }

        
        private void salary_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void userName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                fullDays.Focus();
            }
        }

        private void halfDays_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                salary.Focus();
            }
        }

        private void fullDays_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                halfDays.Focus();
            }
            
        }

        private void bankName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                bankID.Focus();
            }
            
        }

        private void salary_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                bankName.Focus();
            }
            
        }

        private void bankID_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                branchName.Focus();
            }
            
        }

        private void BranchID_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                start.Focus();
            }
            
        }

        private void end_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                addToTable.Focus();
            }
           
        }

        private void start_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                end.Focus();
            }
            
        }

        private void fullDays_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void branchName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key== Key.Enter)
            {
                BranchID.Focus();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(userID.Text))
            {
                MessageBox.Show("field is empty", "empty field", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                userID.Focus();
            }
            else if (string.IsNullOrEmpty(userName.Text))
            {
                MessageBox.Show("field is empty", "empty field", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                userName.Focus();
            }
            else if (string.IsNullOrEmpty(start.Text))
            {
                MessageBox.Show("field is empty", "empty field", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                start.Focus();
            }
            else if (string.IsNullOrEmpty(end.Text))
            {
                MessageBox.Show("field is empty", "empty field", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                end.Focus();
            }
            else if (string.IsNullOrEmpty(bankName.Text))
            {
                MessageBox.Show("field is empty", "empty field", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                bankName.Focus();
            }
            else if (string.IsNullOrEmpty(bankID.Text))
            {
                MessageBox.Show("field is empty", "empty field", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                bankID.Focus();
            }
            else if (string.IsNullOrEmpty(branchName.Text))
            {
                MessageBox.Show("field is empty", "empty field", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                branchName.Focus();
            }
            else if (string.IsNullOrEmpty(BranchID.Text))
            {
                MessageBox.Show("field is empty", "empty field", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                BranchID.Focus();
            }
            else if (string.IsNullOrEmpty(salary.Text))
            {
                MessageBox.Show("field is empty", "empty field", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                salary.Focus();
            }
            else if (string.IsNullOrEmpty(fullDays.Text))
            {
                MessageBox.Show("field is empty", "empty field", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                fullDays.Focus();
            }
            else if (string.IsNullOrEmpty(halfDays.Text))
            {
                MessageBox.Show("field is empty", "empty field", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                halfDays.Focus();
            }
            else
            {
                string uID = userID.Text;
                string uName = userName.Text;
                DateTime stDate = DateTime.Parse(start.Text);
                DateTime endDate = DateTime.Parse(end.Text);
                string bkName = bankName.Text;
                string bkID = bankID.Text;
                string brName = branchName.Text;
                string brID = BranchID.Text;
                int daySal = int.Parse(salary.Text);
                int fDay = int.Parse(fullDays.Text);
                int hDay = int.Parse(halfDays.Text);
                float dTotal = fDay + (hDay / 2);
                float sTotal = dTotal * daySal;

                try
                {

                    connection.Open();
                    SqlCommand c1 = new SqlCommand("INSERT INTO data (ID, name, timeFrom, timeTo, bankCode, branchCode, fullDays, halfDays, days, salaryPerDay, total, bankName, branchName ) VALUES ('" + uID + "','" + uName + "','" + stDate + "','" + endDate + "','" + bkID + "','" + brID + "','" + fDay + "','" + hDay + "','" + dTotal + "','" + daySal + "','" + sTotal + "','" + bkName + "','" + brName + "')", connection);
                    c1.ExecuteNonQuery();
                    GetdtToShow();
                    MessageBox.Show("Successfully added to the table", "success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("connection error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    connection.Close();
                }

            } 

        }

        public void GetdtToShow() 
        {
            SqlCommand c2 = new SqlCommand("SELECT * FROM data", connection);
            SqlDataAdapter sd = new SqlDataAdapter(c2);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataShow.ItemsSource = dt.DefaultView;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                connection.Open();
                GetdtToShow();
            }
            catch(Exception ex) 
            {
                MessageBox.Show("connection error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            { 
                connection.Close(); 
            }
            
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                connection.Open();
                SqlCommand c3 = new SqlCommand("DELETE FROM data WHERE ID = '" + sBox.Text + "'", connection);
                c3.ExecuteNonQuery();
                GetdtToShow();
                MessageBox.Show("Successfully deleted from table", "success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("connection error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                connection.Close();
            }

        }

        private void sBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                delBtn.Focus();
            }
        }

        

    }
}
