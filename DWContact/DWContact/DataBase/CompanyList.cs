using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DWContact
{
    static class CompanyList
    {
        private static ObservableCollection<Company> companies = new ObservableCollection<Company>();
        public static ObservableCollection<Company> Companies => companies;

        public static ObservableCollection<string> GetListCompany() => new ObservableCollection<string>(companies.Select(e => e.ToString()).ToList());

        /// <summary>
        /// Добавление организации
        /// </summary>
        public static void Add(Company company) => companies.Add(company);

        /// <summary>
        /// Удаление организации
        /// </summary>
        public static void Remove(Company company) => companies.Remove(company);

        /// <summary>
        /// Поиск организации по имени организации
        /// </summary>
        public static Company Find(string Name) => (Company)companies.Where(e => e.ToString() == Name);
    }
}
