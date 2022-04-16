using Microsoft.EntityFrameworkCore;

using TPHExampleDb context = new();
//await context.Students.AddAsync(new() { Name = "Hilmi", School = "Hacı Hüseyin İmam Hatip Lisesi" });
//await context.Students.AddAsync(new() { Name = "Rauf", School = "Laylaylom Galiba Sana Göre Sevmeler Lisesi" });
//await context.Teachers.AddAsync(new() { Name = "Emine", Branch = "Fizik" });
//await context.Teachers.AddAsync(new() { Name = "Muiddin", Branch = "Edebiyat" });
//await context.SaveChangesAsync();


var students =  context.Users.OfType<Student>();
var teachers =  context.Users.OfType<Teacher>();

//Entity Framework Core - Table Per Hierarchy(TPH) 
public class ApplicationUser
{
    public int Id { get; set; }
    public string Name { get; set; }
}
public class Student : ApplicationUser
{
    public string School { get; set; }
}
public class Teacher : ApplicationUser
{
    public string Branch { get; set; }
}
public class TPHExampleDb : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer($"Server=localhost, 1433;User ID=sa;Password=23asjDnsd23'^;Database={nameof(TPHExampleDb)}");
    }
    public DbSet<ApplicationUser> Users { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
}