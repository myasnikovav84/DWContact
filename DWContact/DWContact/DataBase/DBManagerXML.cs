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
            //AddCompany(new Company("ООО Три", "Адрес 2", "222-222-222", "Информация об ООО Два"));
            //AddCompany(new Company("ООО Четыре", "Адрес 4", "444-444-444", "Информация об ООО Четыре"));

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
        public void AddCompany(string name, string adress, string pfone, string info)
        {
            if (FindCompany(name) == null)
            {
                Company company = new Company(name, adress, pfone, info);
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
        public void RemoveCompany(Company company)
        {
            Companies.Remove(company);
            SaveDBCompanies();
        }

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
        public void UpdateCompany (string name, string newName, string adress, string pfone, string info)
        {
            Company company = FindCompany(name);
            int indx = Companies.IndexOf(company);
            Companies[indx].Name = newName;
            Companies[indx].Adress = adress;
            Companies[indx].Pfone = pfone;
            Companies[indx].Info = info;

            Console.WriteLine($"Обновленна компания №{indx} {name}");

            SaveDBCompanies();
        }

        public string GetCompanyInfo(string company)
        {
            Company _company = FindCompany(company);

            return _company != null ? $"Название организации: {_company.Name}"
                + $"\nАдрес: {_company.Adress}"
                + $"\nТелефон: {_company.Pfone}"
                + $"\nДополнительная информация: {_company.Info}"
                : "";
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
                            Companies.Add(new Company(e.Company.Name, e.Company.Adress, e.Company.Pfone, e.Company.Info));
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
        /// Добавление сотрудника
        /// </summary>
        public void AddEmployee(string name, string middleName, string surname
                    , string pfone1, string pfone2, string pfone3
                    , string adress, string pozition, string company, string info)
        {
            if (FindEmployee($"{surname} {name.Substring(0, 1)}. {middleName.Substring(0, 1)}.") == null)
            {
                Employee employee = new Employee(name, middleName, surname
                    , pfone1, pfone2, pfone3
                    , adress, pozition, FindCompany(company), info);

                Employees.Add(employee);
                LogEvent.SetMessage($"Сотрудник {employee.ToString()} добавлен");
                SaveDBEmployees();
            }
            else
                LogEvent.SetMessage($"{ surname} { name.Substring(0, 1)}. { middleName.Substring(0, 1)}. уже есть в списке");
        }

        /// <summary>
        ///  проверка наличия тако сотрудника
        /// </summary>
        private bool CheckEmployee(Employee employee) 
            => Employees.Where(e => e.ToString() == employee.ToString()).Count() > 0 ? true : false;

        /// <summary>
        /// Удаление сотрудника
        /// </summary>
        public void RemoveEmployee(Employee employee)
        {
            Employees.Remove(employee);
            SaveDBEmployees();
        }

        /// <summary>
        /// Удаление всех сотрудников в компании
        /// </summary>
        public void RemoveCompanyEmployee(Company company)
        {
            ObservableCollection<Employee> removeEmployee =
                new ObservableCollection<Employee>(Employees.Where(e => e.Company == company).ToList());
            for (int i = 0; i < removeEmployee.Count(); i++)
                Employees.Remove(removeEmployee[i]);
            SaveDBEmployees();
        }

        /// <summary>
        /// поиск сотрудника по ФИО
        /// </summary>
        public Employee FindEmployee(string FIO)
        {
            List<Employee> employees = Employees.Where(e => e.ToString() == FIO).ToList();
            if (employees != null && employees.Count() > 0)
                return employees.ElementAt(employees.Count() - 1);
            else
                return null;
        }

        /// <summary>
        /// Обновление данных сотрудника
        /// </summary>
        public void UpdateEmployee(string fio
                    , string name, string middleName, string surname
                    , string pfone1, string pfone2, string pfone3
                    , string adress, string pozition, string company, string info)
        {
            Employee employee   = FindEmployee(fio);
            int indx = Employees.IndexOf(employee);
            Employees[indx].Name = name;
            Employees[indx].MiddleName = middleName;
            Employees[indx].Surname = surname;
            Employees[indx].Pfone1 = pfone1;
            Employees[indx].Pfone2 = pfone2;
            Employees[indx].Pfone3 = pfone3;
            Employees[indx].Adress = adress;
            Employees[indx].Pozition = pozition;
            Employees[indx].Company = FindCompany(company);
            Employees[indx].Info = info;
            SaveDBEmployees();
        }

        /// <summary>
        /// поиск есть ли сотрудники в этой компании
        /// </summary>
        public bool CheckCompanyEmployee(Company company)
        {
            Console.WriteLine(Employees.Where(e => e.Company == company).ToList().Count());
            return Employees.Where(e => e.Company == company).Count() > 0 ? true : false;
        }

        public string GetEmployeeInfo(string employee)
        {
            Employee _employee  = FindEmployee(employee);

            return _employee != null ? $"Имя: {_employee.Name}"
                + $"\nОтчество: {_employee.MiddleName}"
                + $"\nФамилия: {_employee.Surname}"
                + $"\nДолжность: {_employee.Pozition}"
                + $"\nТелефон: {_employee.Pfone1}"
                + $"\nТелефон: {_employee.Pfone2}"
                + $"\nТелефон: {_employee.Pfone3}"
                + $"\nАдрес: {_employee.Adress}"
                + $"\nДополнительная информация: {_employee.Info}"
                : "";
        }


        #endregion
    }
}
