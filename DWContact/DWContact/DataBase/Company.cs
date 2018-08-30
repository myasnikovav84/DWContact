using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWContact
{
    [Serializable]
    public class Company
    {
        public Company()
        {
        }

        public Company(string name, string adress, string pfone, string info)
        {

            Name = name;
            Adress = adress;
            Pfone = pfone;
            Info = info;

        }

        /// <summary>
        /// Наименование организации
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// адрес организации
        /// </summary>
        public string Adress { get; set; }
        /// <summary>
        /// телефон организации
        /// </summary>
        public string Pfone { get; set; }
        /// <summary>
        /// прочая информация
        /// </summary>
        public string Info { get; set; }

        public override string ToString() => Name;


    }
}
