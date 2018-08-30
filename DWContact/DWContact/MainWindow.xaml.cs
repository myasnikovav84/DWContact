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

namespace DWContact
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DBManagerXML managerXML;
        public MainWindow()
        {
            InitializeComponent();
            managerXML = new DBManagerXML();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            managerXML.SaveDBCompanies();
            managerXML.SaveDBEmployees();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            managerXML.LoadBDCompanies();
            managerXML.LoadBDEmployees();
        }
    }
}
