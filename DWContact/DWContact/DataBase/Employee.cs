using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Threading.Tasks;


namespace DWContact
{
    [Serializable]
    class Employee
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Отчество
        /// </summary>
        public string MiddleName { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Контактный телефон
        /// </summary>
        public string Pfone1 { get; set; }
        /// <summary>
        /// Контактный телефон
        /// </summary>
        public string Pfone2 { get; set; }
        /// <summary>
        /// Контактный телефон
        /// </summary>
        public string Pfone3 { get; set; }

        /// <summary>
        /// Адрес в организации
        /// </summary>
        public string Adress { get; set; }
        /// <summary>
        /// Должность
        /// </summary>
        public string Pozition { get; set; }
        /// <summary>
        /// Организация
        /// </summary>
        public Company Company { get; set; }
        /// <summary>
        /// Дополнительная информация
        /// </summary>
        public string Info { get; set; }

        public Employee()
        {
        }

        public Employee(string name, string middleName, string surname, string pfone1, string pfone2, string pfone3, string adress, string pozition, Company company, string info) 
        {
            try
            {
                Name = name ?? throw new ArgumentNullException(nameof(name));
                MiddleName = middleName ?? throw new ArgumentNullException(nameof(middleName));
                Surname = surname ?? throw new ArgumentNullException(nameof(surname));
                Pfone1 = pfone1 ?? throw new ArgumentNullException(nameof(pfone1));
                Pfone2 = pfone2 ?? throw new ArgumentNullException(nameof(pfone2));
                Pfone3 = pfone3 ?? throw new ArgumentNullException(nameof(pfone3));
                Adress = adress ?? throw new ArgumentNullException(nameof(adress));
                Pozition = pozition ?? throw new ArgumentNullException(nameof(pozition));
                Company = company ?? throw new ArgumentNullException(nameof(company));
                Info = info ?? throw new ArgumentNullException(nameof(info));
            }
            catch (ArgumentNullException e)
            {
                Dialog.Message("Employee Add error", e.ToString());
            }
            Dialog.Message("Employee Add", $"{Name} {MiddleName} {Surname}");
        }

        public override string ToString() => $"{Surname} {Name.Substring(0, 1)}. {MiddleName.Substring(0, 1)}.";
    }


    }
