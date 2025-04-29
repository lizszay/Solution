class Program
{
    static void Main(string[] args)
    {
        // Создание базы данных 
        using (ApplicationContext db = new ApplicationContext())
        {
            db.Database.EnsureDeleted(); // Удаляем базу данных
            db.Database.EnsureCreated(); // Создаем новую базу данных на основе модели

            // Добавляем начальные данные
            Company microsoft = new Company { Name = "Microsoft" };
            Company google = new Company { Name = "Google" };
            db.Companies.AddRange(microsoft, google); // Добавляем компании в контекст

            User tom = new User { Name = "Tom", Company = microsoft };
            User bob = new User { Name = "Bob", Company = google };
            User alice = new User { Name = "Alice", Company = microsoft };
            User kate = new User { Name = "Kate", Company = google };
            db.Users.AddRange(tom, bob, alice, kate);   // Добавляем пользователей в контекст

            db.SaveChanges(); // Сохраняем изменения в базе данных
        }

        // Извлечение пользователей и связанных с ними компаний
        using (ApplicationContext db = new ApplicationContext())
        {
            //получаем пользователей
            var users = db.Users.ToList();
            //перебираем полученных пользователей,
            foreach (User user in users)
                //обращаемся к навигационному свойству Company для получения связанной компании
                Console.WriteLine($"{user.Name} - {user.Company?.Name}");
        }

        // загрузка компаний и связанных с ними пользователей
        using (ApplicationContext db = new ApplicationContext())
        {
            // Извлекаем все компании из базы данных
            var companies = db.Companies.ToList();

            foreach (Company company in companies)
            {
                Console.Write($"{company.Name}:");
                foreach (User user in company.Users)
                    Console.Write($"{user.Name} ");
                Console.WriteLine();
            }
        }
    }
}