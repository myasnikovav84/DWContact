using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class MainWindow : Window, IMainView
    {
        MainPresenter mainPresenter;
        public MainWindow()
        {
            InitializeComponent();

            mainPresenter = new MainPresenter(this);
            this.Loaded += delegate { mainPresenter.Load(); };

            lvCompany.SelectionChanged += delegate { mainPresenter.SelectCompany(); };
            lvEmployee.SelectionChanged += delegate { mainPresenter.SelectEmployee(); };

            btnAllEmployee.Click += delegate { mainPresenter.SelectAll(); };

            btnAddCompany.Click += delegate { mainPresenter.AddCompany(); };
            btnSettingsCompany.Click += delegate { mainPresenter.SettingsCompany(); };
            btnRemoveCompany.Click += delegate { mainPresenter.RemoveCompany(); };

            btnAddEmployee.Click += delegate { mainPresenter.AddEmployee(); };
            btnSettingsEmployee.Click += delegate { mainPresenter.SettingsEmployee(); };
            btnRemoveEmployee.Click += delegate { mainPresenter.RemoveEmployee(); };
        }

        public ObservableCollection<string> CompanyList { set => lvCompany.ItemsSource = value; }
        public ObservableCollection<string> EmployeeList { set => lvEmployee.ItemsSource = value; }
        public string Info { set => tbInfo.Text = value; }

        public string EmployeeItems => string.Join("", lvEmployee.SelectedItem);
        public string CompanyItems => string.Join("", lvCompany.SelectedItem);

        public int EmployeeIndex { get => lvEmployee.SelectedIndex; set => lvEmployee.SelectedIndex = value; }
        public int CompanyIndex { get => lvCompany.SelectedIndex; set => lvCompany.SelectedIndex = value; }
    }
}
