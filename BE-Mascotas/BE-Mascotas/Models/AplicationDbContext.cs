using Microsoft.EntityFrameworkCore;


namespace BE_Mascotas.Models
{  //agregamos dos puntos y la clase DbContext he importamos la clase
   //https://www.entityframeworktutorial.net/efcore/entity-framework-core.aspx
   //https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-6.0&tabs=visual-studio
   //estas url tomamos algunos ejemplos ojo
    public class AplicationDbContext : DbContext
    {
        public  AplicationDbContext(DbContextOptions<AplicationDbContext>options): base(options)
        {
         
        }
       public DbSet<Mascota>Mascotas { get; set; }
    }
}
