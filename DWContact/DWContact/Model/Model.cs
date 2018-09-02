using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Threading.Tasks;

namespace DWContact
{
    class Model
    {
        public ObservableCollection<string> Companies { get; set; }
        public ObservableCollection<string> Employees { get; set; }
        public string Info;
        DBManagerXML db;
        public Model()
        {
            db = new DBManagerXML();
            SelectAll();
        }
        public void SelectAll()
        {
            Companies = new ObservableCollection<string>(db.Companies.Select(e => e.ToString()));
            Employees = new ObservableCollection<string>(db.Employees.Select(e => e.ToString()));
            Info = "Для отображения дополнительной информации выберите пользователя или организацию";
        }

        public void GetDataCompany(string company)
        {
            Employees = new ObservableCollection<string>(db.Employees.Where(e => e.Company.ToString() == company).Select(e => e.ToString()).ToList());
            Info = db.GetCompanyInfo( company);
        }

        public string GetCompanyInfo(string company) => db.FindCompany(company).Info;
        public string GetCompanyPfone(string company) => db.FindCompany(company).Pfone;
        public string GetCompanyAdress(string company) => db.FindCompany(company).Adress;

        public string GetEmployeeName(string fio) => db.FindEmployee(fio).Name;
        public string GetEmployeeMiddleName(string fio) => db.FindEmployee(fio).MiddleName;
        public string GetEmployeeSurname(string fio) => db.FindEmployee(fio).Surname;
        public string GetEmployeePfone1(string fio) => db.FindEmployee(fio).Pfone1;
        public string GetEmployeePfone2(string fio) => db.FindEmployee(fio).Pfone2;
        public string GetEmployeePfone3(string fio) => db.FindEmployee(fio).Pfone3;
        public string GetEmployeeAdress(string fio) => db.FindEmployee(fio).Adress;
        public string GetEmployeePozition(string fio) => db.FindEmployee(fio).Pozition;
        public string GetEmployeeCompany(string fio) => db.FindEmployee(fio).Company.ToString();
        public string GetEmployeeInfo(string fio) => db.FindEmployee(fio).Info;


        public void GetDataEmployee(string employee) => Info = db.GetEmployeeInfo(employee);

        public void RemoveEmployee (string fio)
        {
            try
            {
                if (MessageBox.Show($"Вы действительно хотите удалить сотрудника {fio}?", "Подтверждение удаления.", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    db.RemoveEmployee(db.FindEmployee(fio));
            }
            catch (Exception e)
            {
                MessageBox.Show($"Не удалось удалить сотрудника {fio}\n{e.ToString()}", "Ошибка удаления.");
            }

           // Employees = new ObservableCollection<string>(db.Employees.Select(e => e.ToString()).ToList());
        }

        public void RemoveCompany(string company)
        {
            bool flagOk = false;
            try
            {
                if (db.CheckCompanyEmployee(db.FindCompany(company)))
                {
                    if (MessageBox.Show($"В организации {company} есть сотрудники,\nвсе равно удалить?", "Подтверждение удаления.", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        db.RemoveCompanyEmployee(db.FindCompany(company));
                        flagOk = true;
                    }
                }
                else
                    flagOk = (MessageBox.Show($"Вы действительно хотеите удалить компанию {company}?", "Подтверждение удаления.", MessageBoxButton.YesNo) == MessageBoxResult.Yes);

                if (flagOk)
                {
                    db.RemoveCompany(db.FindCompany(company));
                    SelectAll();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Не удалось удалить компанию {company}\n{e.ToString()}", "Ошибка удаления.");
            }
        }

        public void AddCompany(string name, string adress, string pfone, string info) => db.AddCompany(name, adress, pfone, info);
        public void AddEmployee(string name, string middleName, string surname, string pfone1, string pfone2, string pfone3, string adress, string pozition, string company, string info) 
            => db.AddEmployee(name, middleName, surname, pfone1, pfone2, pfone3, adress, pozition, company, info);

        public void UpdateCompany(string name, string newName, string adress, string pfone, string info) => db.UpdateCompany(name, newName, adress, pfone, info);
        public void UpdateEmployee(string fio, string name, string middleName, string surname, string pfone1, string pfone2, string pfone3, string adress, string pozition, string company, string info)
            => db.UpdateEmployee(fio, name, middleName, surname, pfone1, pfone2, pfone3, adress, pozition, company, info);
    }
}
