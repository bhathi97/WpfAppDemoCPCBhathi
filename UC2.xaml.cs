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
using System.Xml.Linq;

namespace WpfAppDemoCPCBhathi
{
    /// <summary>
    /// Interaction logic for UC2.xaml
    /// </summary>
    public partial class UC2 : UserControl
    {
        public UC2()
        {
            InitializeComponent();
            Fill();
        }

        SqlConnection connection = new SqlConnection(@"Data Source=BHATHIYABANDARA;Initial Catalog=CPC;Integrated Security=True");


        protected void Fill()
        {

            try
            {
                connection.Open();
                SqlCommand c2 = new SqlCommand("SELECT DISTINCT ID, name FROM aData", connection);
                SqlDataAdapter sd = new SqlDataAdapter(c2);
                DataTable dt = new DataTable();
                sd.Fill(dt);
                internData.ItemsSource = dt.DefaultView;
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "error", MessageBoxButton.OK);
            }
            finally
            {
                connection.Close();
            }
        }

        private void internData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid gdc = (DataGrid)sender;
            DataRowView rowSelect = gdc.SelectedItem as DataRowView;
            if (rowSelect != null)
            {
                string select = rowSelect["ID"].ToString();
                try
                {
                    connection.Open();
                    SqlCommand c2 = new SqlCommand("SELECT * FROM aData where ID = '" +select + "' ORDER BY year, CASE WHEN month = 'january' then 1 WHEN month = 'february' then 2 WHEN month = 'march' then 3 WHEN month = 'april' then 4 WHEN month = 'may' then 5 WHEN month = 'june' then 6 WHEN month = 'july' then 7 WHEN month = 'august' then 8 WHEN month = 'september' then 9 WHEN month = 'octomber' then 10 WHEN month = 'november' then 11 WHEN month = 'december' then 12 END ASC", connection);

                    SqlDataAdapter sd = new SqlDataAdapter(c2);
                    DataTable dt = new DataTable();
                    sd.Fill(dt);
                    allData.ItemsSource = dt.DefaultView;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error", MessageBoxButton.OK);
                }
                finally
                {
                    connection.Close();
                }





            }
        }
    }


}
