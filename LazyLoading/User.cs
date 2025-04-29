public class User
{
    public int Id { get; set; }
    public string? Name { get; set; }   //// имя пользователя

    public int? CompanyId { get; set; }
    public virtual Company? Company { get; set; }   //виртуальное свойство для поддержки ленивой загрузки
}