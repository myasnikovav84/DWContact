using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWContact
{
    [Serializable]
    class Company
    {
        public Company()
        {
        }

        public Company(string name, string adress, string pfone, string info)
        {
            try
            {
                Name = name ?? throw new ArgumentNullException(nameof(name));
                Adress = adress ?? throw new ArgumentNullException(nameof(adress));
                Pfone = pfone ?? throw new ArgumentNullException(nameof(pfone));
                Info = info ?? throw new ArgumentNullException(nameof(info));
            }
            catch (ArgumentNullException e)
            {
                Dialog.Message("Company Add error", e.ToString());
            }
            Dialog.Message("Company Add", name);
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
