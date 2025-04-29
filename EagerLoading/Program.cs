using Microsoft.EntityFrameworkCore;

class Program
{
    public static void Main(string[] args)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            DataInitializer.Initialize(db);
        }

        using (ApplicationContext db = new ApplicationContext())
        {
            // получаем пользователей
            var users = db.Users
                .Include(u => u.Company)    // добавляем данные по компаниям
                    .ThenInclude(comp => comp!.Country)  // к компании добавляем страну 
                        .ThenInclude(count => count!.Capital)    // к стране добавляем столицу
                .Include(u => u.Position)   // добавляем данные по должностям
                .ToList();

            foreach (var user in users)
            {
                Console.WriteLine($"{user.Name} - {user.Position?.Name}");
                Console.WriteLine($"{user.Company?.Name} - {user.Company?.Country?.Name} - {user.Company?.Country?.Capital?.Name}");
                Console.WriteLine("----------------------");    // для красоты
            }
        }
    }
}