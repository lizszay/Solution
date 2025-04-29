using Microsoft.EntityFrameworkCore;

public class ApplicationContext : DbContext
{
    // Определяем наборы данных (таблицы) для пользователей и компаний
    public DbSet<User> Users { get; set; } = null!; //таблица пользователей
    public DbSet<Company> Companies { get; set; } = null!;  // таблица компаний

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseLazyLoadingProxies()        // подключение lazy loading
            .UseSqlite("Data Source=helloapp.db");
    }
}