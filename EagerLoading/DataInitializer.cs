// Класс для инициализации данных в базе данных
public static class DataInitializer
{
    public static void Initialize(ApplicationContext db)
    {
        // пересоздаём базу данных
        db.Database.EnsureDeleted();
        db.Database.EnsureCreated();

        //создаём должности 
        Position manager = new Position { Name = "Manager" };
        Position developer = new Position { Name = "Developer" };
        //добавляем в контест бд 
        db.Positions.AddRange(manager, developer);

        //создаем города 
        City washington = new City { Name = "Washington" };
        //добавляем в контест бд 
        db.Cities.Add(washington);

        Country usa = new Country { Name = "USA", Capital = washington };
        //добавляем в контест бд 
        db.Countries.Add(usa);
        //создаём компании
        Company microsoft = new Company { Name = "Microsoft", Country = usa };
        Company google = new Company { Name = "Google", Country = usa };
        //добавляем в контест бд 
        db.Companies.AddRange(microsoft, google);

        //создаём пользователей, указываем компании, должности 
        User tom = new User { Name = "Tom", Company = microsoft, Position = manager };
        User bob = new User { Name = "Bob", Company = google, Position = developer };
        User alice = new User { Name = "Alice", Company = microsoft, Position = developer };
        User kate = new User { Name = "Kate", Company = google, Position = manager };
        db.Users.AddRange(tom, bob, alice, kate); // Добавляем пользователей в контекст

        db.SaveChanges(); //сохраняем изменения
    }
}