using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Threading.Tasks;


namespace DWContact
{
    [Serializable]
    public class Employee
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
            Name = name;
            MiddleName = middleName;
            Surname = surname;
            Pfone1 = pfone1;
            Pfone2 = pfone2;
            Pfone3 = pfone3;
            Adress = adress;
            Pozition = pozition;
            Company = company;
            Info = info;
        }

        public override string ToString() => $"{Surname} {Name.Substring(0, 1)}. {MiddleName.Substring(0, 1)}.";
    }


    }
