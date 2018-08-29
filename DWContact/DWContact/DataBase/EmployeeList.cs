using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DWContact
{
    class EmployeeList
    {
        private static ObservableCollection<Employee> employeesList = new ObservableCollection<Employee>();
        public static ObservableCollection<Employee> Employees { get => employeesList; }


        /// <summary>
        /// список всех контактов
        /// </summary>
        public static ObservableCollection<string> GetEmployeesList() 
               => new ObservableCollection<string>(employeesList.Select(e => e.ToString()).ToList());

        /// <summary>
        /// список всех сотрудников по организации
        /// </summary>
        public static ObservableCollection<string> GetEmployeesList(Company company) 
            => new ObservableCollection<string>(employeesList
                            .Where(e => e.Company.Name == company.Name)
                                  .Select(e => e.ToString()).ToList());

        /// <summary>
        /// Добавление сотрудника
        /// </summary>
        public static void Add(Employee employee) => employeesList?.Add(employee);

        /// <summary>
        /// Удаление сотрудника по ФИО 
        /// </summary>
        public static void Remove(Employee employee) => employeesList?.Remove(employee);

        /// <summary>
        /// поиск сотрудника по ФИО
        /// </summary>
        public static Employee FindEmployee (string FIO)
        {
            Employee employee = (Employee)employeesList.Where(e => e.ToString() == FIO);
            return employee != null ? employee : null;
        }

        /// <summary>
        /// Обновление данных сотрудника
        /// </summary>
        public static void UpdateEmployee  (Employee employee
                    , string name, string middleName, string surname
                    , string pfone1, string pfone2, string pfone3
                    , string adress, string pozition, Company company, string info)
        {
            int indx = employeesList.IndexOf(employee);
            employeesList[indx].Name = name;
            employeesList[indx].MiddleName = middleName;
            employeesList[indx].Surname = surname;
            employeesList[indx].Pfone1 = pfone1;
            employeesList[indx].Pfone2 = pfone2;
            employeesList[indx].Pfone3 = pfone3;
            employeesList[indx].Adress = adress;
            employeesList[indx].Pozition = pozition;
            employeesList[indx].Company = company;
            employeesList[indx].Info = info;
        }
        /// <summary>
        /// поиск есть ли сотрудники в этой компании
        /// </summary>
        public static bool CheckDeleteCompany (Company company)
        {
            return employeesList.Where(e => e.Company == company).Count() > 0 ? true : false;
}
            //bool flag = true;

            //for (int i = 0; i < employeesList.Count(); i++)
            //{
            //    if (employeesList[i].Company == company)
            //    {
            //        flag = false;
            //        continue;
            //    }
            //}
            //return flag;

        
        /// <summary>
        /// удаление компании, и сотрудников
        /// </summary>
        public static void DeleteCompany(Company company)
        {

        }
    }
}
