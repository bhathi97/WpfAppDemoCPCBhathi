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
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;
using System.Security.Cryptography.X509Certificates;

namespace WpfAppDemoCPCBhathi
{
   
    public partial class UC1 : UserControl
    {
        public string[] months { get; set; }
        public int[] years { get; set; }
        public UC1()    
        {
            
            InitializeComponent();
            userID.Focus();
            months = new string[] { "january", "february", "march", "april", "may", "june", "july", "august", "september", "octomber", "november", "december" };
            years = new int[] {2022,2023,2024,2025,2026 };
            DataContext = this;
            //FillComboBox();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=BHATHIYABANDARA;Initial Catalog=CPC;Integrated Security=True");


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void userID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                fullDays.Focus();
            }
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

        private void bankNameList_KeyDown(object sender, KeyEventArgs e)
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
                monthTxt.Focus();
            }
            
        }

        private void monthTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                yearTxt.Focus();
            }

        }

        private void yearTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                bankName.Focus();
            }
        }

        private void bankName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                bankID.Focus();
            }
        }


        private void bankID_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                branchName.Focus();
            }
            
        }

        private void branchName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                BranchID.Focus();
            }
        }

        private void BranchID_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                addToTable.Focus();
            }
            
        }

        //add to table
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
            else if (string.IsNullOrEmpty(monthTxt.Text))
            {
                MessageBox.Show("field is empty", "empty field", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                monthTxt.Focus();
            }
            else if (string.IsNullOrEmpty(yearTxt.Text))
            {
                MessageBox.Show("field is empty", "empty field", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                yearTxt.Focus();
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
                string month = monthTxt.Text;
                int year = int.Parse(yearTxt.Text);
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
                    SqlCommand c1 = new SqlCommand("INSERT INTO data (ID, name, month, year, bankCode, branchCode, fullDays, halfDays, days, salaryPerDay, total, bankName, branchName ) VALUES ('" + uID + "','" + uName + "','" + month + "','" + year + "','" + bkID + "','" + brID + "','" + fDay + "','" + hDay + "','" + dTotal + "','" + daySal + "','" + sTotal + "','" + bkName + "','" + brName + "')", connection);
                    c1.ExecuteNonQuery();
                    GetdtToShow();
                    MessageBox.Show("Successfully added to the table", "success", MessageBoxButton.OK, MessageBoxImage.Information);
                    cleanAllTxt();
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
        
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(sBox.Text))
            {
                MessageBox.Show("Delete User ID = ?", "error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                if (MessageBox.Show("Delete the record ?", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
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
            }
            
        }

        private void sBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                delBtn.Focus();
            }
        }

        public void cleanAllTxt() 
        {
            TextBox[] txtBoxes = { userID, userName, bankID, branchName, BranchID, salary, fullDays, halfDays, bankName};
            foreach(var i in txtBoxes)
            {
                i.Clear();
            }
            monthTxt.Text = string.Empty;
            yearTxt.Text = string.Empty;
           
        }

        
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
        Regex regex = new Regex("[^0-9]+");
        e.Handled = regex.IsMatch(e.Text);
        }

        //update button
        private void updateBtn_Click(object sender, RoutedEventArgs e)
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
            else if (string.IsNullOrEmpty(monthTxt.Text))
            {
                MessageBox.Show("field is empty", "empty field", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                monthTxt.Focus();
            }
            else if (string.IsNullOrEmpty(yearTxt.Text))
            {
                MessageBox.Show("field is empty", "empty field", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                yearTxt.Focus();
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
                DateTime month = DateTime.Parse(monthTxt.Text);
                DateTime year = DateTime.Parse(yearTxt.Text);
                string bkName = bankName.Text;
                string bkID = bankID.Text;
                string brName = branchName.Text;
                string brID = BranchID.Text;
                float daySal = float.Parse(salary.Text);
                int fDay = int.Parse(fullDays.Text);
                int hDay = int.Parse(halfDays.Text);
                float dTotal = fDay + (hDay / 2);
                float sTotal = dTotal * daySal;

                try
                {
                    string a = doSome(sender);
                    connection.Open();
                    SqlCommand c1 = new SqlCommand("UPDATE data (ID, name, month, year, bankCode, branchCode, fullDays, halfDays, days, salaryPerDay, total, branchName, bankName ) VALUES ('" + uID + "','" + uName + "','" + month + "','" + year + "','" + bkID + "','" + brID + "','" + fDay + "','" + hDay + "','" + dTotal + "','" + daySal + "','" + sTotal + "','" + brName + "','" + bkName + "') WHERE ID = '" + a +"'", connection);
                    c1.ExecuteNonQuery();
                    GetdtToShow();
                    MessageBox.Show("Successfully updated the table", "success", MessageBoxButton.OK, MessageBoxImage.Information);
                    cleanAllTxt();
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

        private void dataShow_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid gdc = (DataGrid)sender;
            DataRowView rowSelect = gdc.SelectedItem as DataRowView;
            if(rowSelect != null)
            {
                userID.Text = rowSelect["ID"].ToString();
                userName.Text = rowSelect["name"].ToString();
                bankID.Text = rowSelect["bankCode"].ToString();
                bankName.Text = rowSelect["bankName"].ToString();
                branchName.Text = rowSelect["branchName"].ToString();
                BranchID.Text = rowSelect["branchCode"].ToString();
                salary.Text = rowSelect["salaryPerDay"].ToString();
                fullDays.Text = rowSelect["fullDays"].ToString();
                halfDays.Text = rowSelect["halfDays"].ToString();
                monthTxt.Text = rowSelect["month"].ToString();
                yearTxt.Text = rowSelect["year"].ToString();  
                
            }
        }

        public string doSome (object sender)
        {
            DataGrid gdc = (DataGrid)sender;
            DataRowView rowSelect = gdc.SelectedItem as DataRowView;
            if (rowSelect != null)
            {
                string a = rowSelect["ID"].ToString();
                return a;
                
            }
            return null;
        }



        private void addNewBtn_Click(object sender, RoutedEventArgs e)
        {
            cleanAllTxt();
            userID.Focus();
        }


        /*protected void FillComboBox()
        {
            
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Banks", connection);
                SqlDataReader er = cmd.ExecuteReader();
                while (er.Read()) 
                {
                    string bankName = er.GetString(1);
                    bankNameList.Items.Add(bankName);

                }

            }
            catch (Exception e)
            {
                MessageBox.Show("error", "error", MessageBoxButton.OK);
            }
            finally
            { 
                connection.Close(); 
            }
        }*/

        /*private void bankNameList_DropDownOpened(object sender, EventArgs e)
        {
            FillComboBox();
            MessageBox.Show("aa","aa",MessageBoxButton.YesNo);
        }*/

 /*       private void bankNameList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try 
            {
                connection.Open();
                SqlCommand cmdAuto1 = new SqlCommand("SELECT * FROM Banks WHERE BankName = '" + bankNameList.Text + "'", connection);
                SqlDataReader er = cmdAuto1.ExecuteReader();
                while (er.Read())
                {
                    bankID.Text = er["BankID"].ToString();
                    

                }
            }catch(Exception ee)
            {
                MessageBox.Show("loading error", "loading error", MessageBoxButton.OK);
            }
            finally { connection.Close(); }
            

        }*/

        private void userID_SelectionChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                connection.Open();
                SqlCommand cmdAuto2 = new SqlCommand("SELECT * FROM master WHERE userID = '" + userID.Text + "'", connection);
                SqlDataReader er = cmdAuto2.ExecuteReader();
                while (er.Read())
                {
                    userName.Text = er["userName"].ToString();
                    bankName.Text = er["bankName"].ToString();
                    bankID.Text = er["bankID"].ToString();
                    branchName.Text = er["branchName"].ToString();
                    BranchID.Text = er["branchID"].ToString();

                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("loading error", "loading error", MessageBoxButton.OK);
            }
            finally { connection.Close(); }

        }

        
    }
}
