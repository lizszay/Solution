using Microsoft.EntityFrameworkCore;

public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Company> Companies { get; set; } = null!;

    // Метод для настройки параметров контекста
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //использовать SQLite и задаем имя файла базы данных
        optionsBuilder.UseSqlite("Data Source=helloapp.db");
    }
}
