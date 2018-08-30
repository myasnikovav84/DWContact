using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DWContact
{
    static class Dialog
    {
        private static Dictionary<string, string> dictMessage = new Dictionary<string, string>()
        {
             {"Employee Add error", "Ошибка добавления сотрудника, неверно введены данные. " }
            ,{"Employee Add", "Успешно дабавлен сотрудник:" }
            ,{"Company Add error", "Ошибка добавления организации, неверно введены данные. " }
            ,{"Company Add", "Успешно дабавлена организация:" }
        };

        public static void Message(string key) => Message(key, "");
        public  static void Message(string key, string param)
        {
            string message = dictMessage.ContainsKey(key) ? dictMessage[key] : "не известное сообщение";
            //MessageBox.Show(message + " " + param);
            LogEvent.SetMessage(message + " " + param);
        }

    }
}
