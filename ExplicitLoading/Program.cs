using YourProject.Data;
using System;
using System.Linq;
using YourProject.Models;
using Microsoft.EntityFrameworkCore;

namespace YourProject
{
    class Program
    {
        static void Main(string[] args)
        {
            // Инициализация данных
            DataInitializer.Initialize();

            using (ApplicationContext db = new ApplicationContext())
            {
                // Загрузка первой компании
                Company? company = db.Companies.FirstOrDefault();
                if (company != null)
                {
                    // Явная загрузка пользователей
                    db.Users.Where(u => u.CompanyId == company.Id).Load();

                    Console.WriteLine($"Company: {company.Name}");
                    foreach (var u in company.Users)
                        Console.WriteLine($"User: {u.Name}");
                }

                // Альтернативная загрузка используя метод Collection
                Company? anotherCompany = db.Companies.FirstOrDefault(c => c.Id == 2);
                if (anotherCompany != null)
                {
                    db.Entry(anotherCompany).Collection(c => c.Users).Load();

                    Console.WriteLine($"Company: {anotherCompany.Name}");
                    foreach (var u in anotherCompany.Users)
                        Console.WriteLine($"User: {u.Name}");
                }

                // Загрузка первого пользователя и его компании
                User? user = db.Users.FirstOrDefault();
                if (user != null)
                {
                    db.Entry(user).Reference(u => u.Company).Load();
                    Console.WriteLine($"{user.Name} - {user.Company?.Name}");
                }

                // Загрузка всех сотрудников
                foreach (var u in db.Users.Local)
                {
                    Console.WriteLine($"User: {u.Name}");
                }
            }
        }
    }
}