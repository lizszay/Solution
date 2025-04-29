using YourProject.Models;
using YourProject.Data;
using System.Linq;

namespace YourProject.Data
{
    public static class DataInitializer
    {
        public static void Initialize()
        {
            using (var db = new ApplicationContext())
            {
                // Пересоздаем базу данных
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                // Добавляем начальные данные
                Company microsoft = new Company { Name = "Microsoft" };
                Company google = new Company { Name = "Google" };
                db.Companies.AddRange(microsoft, google);

                User tom = new User { Name = "Tom", Company = microsoft };
                User bob = new User { Name = "Bob", Company = google };
                User alice = new User { Name = "Alice", Company = microsoft };
                User kate = new User { Name = "Kate", Company = google };
                db.Users.AddRange(tom, bob, alice, kate);

                db.SaveChanges();
            }
        }
    }
}