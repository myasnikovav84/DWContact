using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using System.Windows;

namespace DWContact
{
    class DBManagerXML
    {
        public ObservableCollection<Company> Companies { get; set; }
        public ObservableCollection<Employee> Employees { get; set; }


        public DBManagerXML()
        {
            Companies = new ObservableCollection<Company>();
            Employees = new ObservableCollection<Employee>();
            LoadBDCompanies();
            LoadBDEmployees();

        }

        #region Обработчик коллекции организаций
        /// <summary>
        /// загрузка списка компаний
        /// </summary>
        public void LoadBDCompanies()
        {
            // переделать на xml
            //AddCompany(new Company("ООО Один", "Адрес 1", "111-111-111", "Информация об ООО Один"));
            //AddCompany(new Company("ООО Два", "Адрес 2", "222-222-222", "Информация об ООО Два"));
            //AddCompany(new Company("ООО Три", "Адрес 3", "333-333-333", "Информация об ООО Три"));

            XmlSerializer xmlFormatCompany = new XmlSerializer(typeof(ObservableCollection<Company>));
            using (FileStream fStreamCompany = new FileStream("Department.xml", FileMode.OpenOrCreate))
            {
                try
                {
                    Companies = (ObservableCollection<Company>)xmlFormatCompany.Deserialize(fStreamCompany);
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Ошибка загрузки \n" + exception.Message, @"Ошибка");
                }
            }


            for (int i = 0; i < Companies.Count(); i++)
                Console.WriteLine(Companies[i].ToString());
            Console.WriteLine();
        }

        /// <summary>
        /// сохранение списка компаний
        /// </summary>
        public void SaveDBCompanies()
        {
            XmlSerializer xmlFormatCompany = new XmlSerializer(typeof(ObservableCollection<Company>));
            Stream fStreamCompany = new FileStream("Department.xml", FileMode.Create, FileAccess.Write);
            try
            {
                xmlFormatCompany.Serialize(fStreamCompany,Companies);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Ошибка сохранение /n" + exception.Message, @"Ошибка");
            }
            finally
            {
                fStreamCompany.Close();
            }
        }

        /// <summary>
        ///  проверка наличия ораганизации в списке организаций
        /// </summary>
        private bool CheckCompany(Company company) => Companies.Where(e => e.ToString() == company.ToString()).Count() > 0 ? true : false;

        /// <summary>
        /// Добавление организации
        /// </summary>
        public void AddCompany(Company company)
        {
            if (!CheckCompany(company))
            {
                Companies.Add(company);
                LogEvent.SetMessage($"Компания {company.ToString()} добавлена");
                SaveDBCompanies();
            }
            else
                LogEvent.SetMessage($"{Companies.ToString()} уже есть в списке организаций");
        }

        /// <summary>
        /// Удаление организации
        /// </summary>
        public void RemoveCompany(Company company) => Companies.Remove(company);

        /// <summary>
        /// Поиск организации по имени организации
        /// </summary>
        public Company FindCompany(string Name)
        {
            List<Company> companies = Companies.Where(e => e.ToString() == Name).ToList();
            if (companies != null && companies.Count() > 0)
                return companies.ElementAt(companies.Count() - 1);
            else
                return null;
        }

        /// <summary>
        /// Обновление данных компании
        /// </summary>
        public void UpdateCompany (Company company, string name, string adress, string pfone, string info)
        {
            int indx = Companies.IndexOf(company);
            Companies[indx].Name = name;
            Companies[indx].Adress = adress;
            Companies[indx].Pfone = pfone;
            Companies[indx].Info = info;
        }

        #endregion

        #region Обработчик коллекции сотрудников

        /// <summary>
        /// загрузка списка сотрудников
        /// </summary>
        public void LoadBDEmployees()
        {

            //AddEmployee(new Employee("Имя1", "Отчество1", "Фамилия1", "11-11-11", "", "", "Адрес И.О. Фамилия1", "Должность1", FindCompany("ООО Один"), "Информация об И.О. Фамилия1"));
            //AddEmployee(new Employee("Имя2", "Отчество2", "Фамилия2", "11-11-11", "", "", "Адрес И.О. Фамилия2", "Должность2", FindCompany("ООО Один"), "Информация об И.О. Фамилия2"));
            //AddEmployee(new Employee("Имя3", "Отчество3", "Фамилия3", "11-11-11", "", "", "Адрес И.О. Фамилия3", "Должность3", FindCompany("ООО Два"), "Информация об И.О. Фамилия3"));
            //AddEmployee(new Employee("Имя4", "Отчество4", "Фамилия4", "11-11-11", "", "", "Адрес И.О. Фамилия4", "Должность4", FindCompany("ООО Два"), "Информация об И.О. Фамилия4"));
            //AddEmployee(new Employee("Имя5", "Отчество5", "Фамилия5", "11-11-11", "", "", "Адрес И.О. Фамилия5", "Должность5", FindCompany("ООО Два"), "Информация об И.О. Фамилия5"));
            //AddEmployee(new Employee("Имя6", "Отчество6", "Фамилия6", "11-11-11", "", "", "Адрес И.О. Фамилия6", "Должность6", FindCompany("ООО Три"), "Информация об И.О. Фамилия6"));
            //AddEmployee(new Employee("Имя7", "Отчество7", "Фамилия7", "11-11-11", "", "", "Адрес И.О. Фамилия7", "Должность7", FindCompany("ООО Три"), "Информация об И.О. Фамилия7"));
            //AddEmployee(new Employee("Имя8", "Отчество8", "Фамилия8", "11-11-11", "", "", "Адрес И.О. Фамилия8", "Должность8", FindCompany("ООО Два"), "Информация об И.О. Фамилия8"));
            //AddEmployee(new Employee("Имя9", "Отчество9", "Фамилия9", "11-11-11", "", "", "Адрес И.О. Фамилия9", "Должность9", FindCompany("ООО Два"), "Информация об И.О. Фамилия9"));

            XmlSerializer xmlFormatEmployee = new XmlSerializer(typeof(ObservableCollection<Employee>));
           using (FileStream fStreamEmployee = new FileStream("Employee.xml", FileMode.OpenOrCreate))
            {
                try
                {
                    ObservableCollection<Employee> employees = (ObservableCollection<Employee>)xmlFormatEmployee.Deserialize(fStreamEmployee);
                    foreach (var e in employees)
                    {
                        if (FindCompany(e.Company.ToString()) == null)
                        {
                            Companies.Add(new Company(e.Company.Name, e.Company.Adress, e.Company.Pfone, e.Company.Info));
                        }
                        Employees.Add(new Employee(e.Name, e.MiddleName, e.Surname, e.Pfone1, e.Pfone2, e.Pfone3, e.Adress, e.Pozition, FindCompany(e.Company.ToString()), e.Info));
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Ошибка загрузки \n" + exception.Message, @"Ошибка");
                }
            }

            for (int i = 0; i < Employees.Count(); i++)
                Console.WriteLine(Employees[i].ToString());
            Console.WriteLine();
        }

        /// <summary>
        /// сохраненние списка сотрудников
        /// </summary>
        public void SaveDBEmployees()
        {
            XmlSerializer xmlFormatEmployee = new XmlSerializer(typeof(ObservableCollection<Employee>));
            Stream fStreamEmployee = new FileStream("Employee.xml", FileMode.Create, FileAccess.Write);
            try
            {
                xmlFormatEmployee.Serialize(fStreamEmployee, Employees);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Ошибка сохранение /n" + exception.Message, @"Ошибка");
            }
            finally
            {
                fStreamEmployee.Close();
            }
        }

        /// <summary>
        /// Добавление сотрудника
        /// </summary>
        public void AddEmployee(Employee employee)
        {
            if (!CheckEmployee(employee))
            {
                Employees.Add(employee);
                LogEvent.SetMessage($"Сотрудник {employee.ToString()} добавлен");
                SaveDBEmployees();
            }
            else
                LogEvent.SetMessage($"{employee.ToString()} уже есть в списке");
        }

        /// <summary>
        ///  проверка наличия тако сотрудника
        /// </summary>
        private bool CheckEmployee(Employee employee) 
            => Employees.Where(e => e.ToString() == employee.ToString()).Count() > 0 ? true : false;

        /// <summary>
        /// Удаление сотрудника
        /// </summary>
        public void RemoveEmployee(Employee employee) => Employees.Remove(employee);

        /// <summary>
        /// поиск сотрудника по ФИО
        /// </summary>
        public Employee FindEmployee(string FIO)
        {
            Employee employee = (Employee)Employees.Where(e => e.ToString() == FIO);
            return employee != null ? employee : null;
        }

        /// <summary>
        /// Обновление данных сотрудника
        /// </summary>
        public void UpdateEmployee(Employee employee
                    , string name, string middleName, string surname
                    , string pfone1, string pfone2, string pfone3
                    , string adress, string pozition, Company company, string info)
        {
            int indx = Employees.IndexOf(employee);
            Employees[indx].Name = name;
            Employees[indx].MiddleName = middleName;
            Employees[indx].Surname = surname;
            Employees[indx].Pfone1 = pfone1;
            Employees[indx].Pfone2 = pfone2;
            Employees[indx].Pfone3 = pfone3;
            Employees[indx].Adress = adress;
            Employees[indx].Pozition = pozition;
            Employees[indx].Company = company;
            Employees[indx].Info = info;
        }

        /// <summary>
        /// поиск есть ли сотрудники в этой компании
        /// </summary>
        public bool CheckCompanyEmployee(Company company) => Employees.Where(e => e.Company == company).Count() > 0 ? true : false;



        #endregion
    }
}
