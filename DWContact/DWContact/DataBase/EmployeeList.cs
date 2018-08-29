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

        /*      список ФИО всех сотрудников
         *      список ФИО по организации
         *      добавить сотрудника
         * удалить сотрудник
         * карточка сотрудника
         * Обновить данные сотрудника
         */

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

        public static void Add(Employee employee) => employeesList?.Add(employee);

        /// <summary>
        /// Удаление сотрудника по ФИО 
        /// </summary>
        public static void Remove(Employee employee) => employeesList?.Remove(employee);

        public static Employee FindEmployee (string FIO)
        {
            Employee employee = (Employee)employeesList.Where(e => e.ToString() == FIO);
            return employee != null ? employee : null;
        }


    }
}
