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

namespace InventoryTracker
{
    /// <summary>
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : Window
    {
       
        public Login()
        {
            InitializeComponent();
           
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {

            if (UserName.Text == "username" && Password.Password == "password123")
            {
                ClearForm();
                
                MainWindow main = new MainWindow();
                main.ShowDialog();
               
                
            }
            else
            {
                MessageBox.Show("UserName or Password is wrong", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                ClearForm();
            }

        }
        private void ClearForm()
        {
            UserName.Text = string.Empty;
            Password.Password = null;
           
        }
    }
}