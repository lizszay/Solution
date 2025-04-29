using Microsoft.EntityFrameworkCore;

public class ApplicationContext : DbContext
{
    /// Определяем таблицы для пользователей, компаний, стран, городов и должностей
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Company> Companies { get; set; } = null!;
    public DbSet<Country> Countries { get; set; } = null!;
    public DbSet<City> Cities { get; set; } = null!;
    public DbSet<Position> Positions { get; set; } = null!;

    // Метод для настройки контекста базы данных
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=helloapp.db");
    }
}