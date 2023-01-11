using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
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

namespace WpfAppDemoCPCBhathi.Customs
{
    /// <summary>
    /// Interaction logic for BindablePWBox.xaml
    /// </summary>
    public partial class BindablePWBox : UserControl
    {
        public static readonly DependencyProperty pwProperty = DependencyProperty.Register("pw",typeof(SecureString),typeof(BindablePWBox)); 

        public SecureString pw 
        {
            get { return (SecureString)GetValue(pwProperty); }
            set { SetValue(pwProperty, value); }
        }
        public BindablePWBox()
        {
            InitializeComponent();
            userPassWord.PasswordChanged += OnPWChanged;
        }

        private void OnPWChanged(object sender, RoutedEventArgs e)
        {
            pw = userPassWord.SecurePassword;
        }
    }
}
