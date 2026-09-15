using Microsoft.EntityFrameworkCore;

public class MyAcademyContext(DbContextOptions<MyAcademyContext> options) : DbContext(options)
{
    public DbSet<MyAcademy.Classes.Directions> Directions { get; set; } = default!;
}
