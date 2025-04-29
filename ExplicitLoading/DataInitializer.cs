public static class DataInitializer
{
    public static void Initialize()
    {
        //экземпляр контекста базы данных
        using (var db = new ApplicationContext())
        {
            // Пересоздаем базу данных
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            // Добавляем начальные данные
            Company microsoft = new Company { Name = "Microsoft" };
            Company google = new Company { Name = "Google" };
            db.Companies.AddRange(microsoft, google); // Добавляем компании в контекст

            // Создаем пользователей и связываем их с компаниями
            User tom = new User { Name = "Tom", Company = microsoft };
            User bob = new User { Name = "Bob", Company = google };
            User alice = new User { Name = "Alice", Company = microsoft };
            User kate = new User { Name = "Kate", Company = google };
            db.Users.AddRange(tom, bob, alice, kate); // Добавляем пользователей в контекст

            db.SaveChanges(); //сохраняем изменения в бд 
        }
    }
}
