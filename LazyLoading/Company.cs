public class Company
{
    public int Id { get; set; }
    public string? Name { get; set; }   // Название компании
    public virtual List<User> Users { get; set; } = new(); //виртуальное свойство для поддержки ленивой загрузки
}