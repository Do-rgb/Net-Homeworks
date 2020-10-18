using System;
using System.IO;
using System.Xml.Serialization;
using CUITask2.Entities;

namespace CUITask2
{
    internal static class Program
    {
        public static void Main()
        {
            var filepath = "./PORTAL_USER_INFO.xml";
            while (string.IsNullOrEmpty(filepath) || !File.Exists(filepath))
            {
                Console.Clear();
                Console.WriteLine($"Файл {filepath} не найден.");
                Console.WriteLine("Укажите путь до XML файла:");
                filepath = Console.ReadLine();
            }

            var xmlSerializer = new XmlSerializer(typeof(PortalUserInfo));

            using (var fileStream = new FileStream(filepath, FileMode.Open))
            {
                var portalUserInfo = (PortalUserInfo) xmlSerializer.Deserialize(fileStream);

                Console.WriteLine("Десериализация успешна.");

                Console.Write("Вывести некоторые поля объекта?(n - нет):");
                var key = Console.ReadKey();
                Console.WriteLine();

                if (key.KeyChar.Equals('n') || key.KeyChar.Equals('N')) return;

                Console.WriteLine($"{nameof(portalUserInfo.Company)}: {portalUserInfo.Company}");
                Console.WriteLine($"{nameof(portalUserInfo.IsEmployee)}: {portalUserInfo.IsEmployee}");
                Console.WriteLine($"PostErrors.All: {portalUserInfo.PostErrors.All}");
                Console.WriteLine($"Contacts.SmsPhoneNumber: {portalUserInfo.Contacts.SmsPhoneNumber}");
            }
        }
    }
}