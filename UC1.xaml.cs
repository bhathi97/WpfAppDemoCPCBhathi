using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

            float dTotal = fDay + (hDay/2);
            float sTotal = dTotal * daySal;


            try 
            {
                connection.Open();
                SqlCommand c1 = new SqlCommand("INSERT INTO data (ID, name, timeFrom, timeTo, bankCode, branchCode, fullDays, halfDays, days, salaryPerDay, total, bankName, branchName ) VALUES ('"+ uID + "','"+ uName + "','"+ stDate +"','" +endDate + "','" +bkID+ "','" + brID + "','" +fDay+ "','" + hDay + "','" + dTotal + "','" + daySal + "','" + sTotal + "','" + bkName + "','" + brName + "')",connection);
                c1.ExecuteNonQuery();
                MessageBox.Show("Successfully added to the table", "success", MessageBoxButton.OK, MessageBoxImage.None);       
            }
            catch(Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

        }

    }
}
