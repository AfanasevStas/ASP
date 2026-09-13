using Microsoft.EntityFrameworkCore;

public class MyAcademyContext(DbContextOptions<MyAcademyContext> options) : DbContext(options)
{
    public DbSet<MyAcademy.Classes.Groups> Groups { get; set; } = default!;
}
